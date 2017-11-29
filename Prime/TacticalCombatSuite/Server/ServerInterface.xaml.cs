using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.ServiceModel;
using System.ServiceModel.Description;

using System.Runtime.Serialization;
using System.CodeDom;
using System.Threading;

namespace TCS.Server
{
    /// <summary>
    /// Interaction logic for ServerInterface.xaml
    /// </summary>
    public partial class ServerInterface : Window
    {
        private static ServerHost server = new ServerHost();

        

        public ServerInterface()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var t = new Thread(server.Start);
            t.Start();
            //server.Start();
            btnStartServer.IsEnabled = false;
            btnStopServer.IsEnabled = true;
        }

        private void btnStopServer_Click(object sender, RoutedEventArgs e)
        {
            server.Stop();
            btnStartServer.IsEnabled = true;
            btnStopServer.IsEnabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            server.Stop();
        }

        private void btnCreateClient_Click(object sender, RoutedEventArgs e)
        {
            // Start each client on its own thread
            var t = new Thread(CreateClient);
            t.Start();
        }

        private void CreateClient()
        {

        }

        private void btnWSDL_Click(object sender, RoutedEventArgs e)
        {
            GenerateCSCodeForService();
        }

        private static void GenerateCSCodeForService()
        {
            //Must run on it's own thread: cannot be accessed from same thread the server runs on (apparently)
            var t = new Thread(GenerateCSCodeForServiceThread);
            t.Start();
        }

        private static void GenerateCSCodeForServiceThread()
        {
            try
            {
                string outputFile = "WSDL-Output";

                MetadataExchangeClient mexClient = new MetadataExchangeClient(server.metaAddress, MetadataExchangeClientMode.HttpGet);
                mexClient.ResolveMetadataReferences = true;
                mexClient.OperationTimeout = TimeSpan.FromSeconds(60);
                mexClient.MaximumResolvedReferences = 1000;

                MetadataSet metaDocs = mexClient.GetMetadata();

                WsdlImporter importer = new WsdlImporter(metaDocs);
                ServiceContractGenerator generator = new ServiceContractGenerator();

                // Add our custom DCAnnotationSurrogate 
                // to write XSD annotations into the comments.
                object dataContractImporter;

                XsdDataContractImporter xsdDCImporter;
                if (!importer.State.TryGetValue(typeof(XsdDataContractImporter), out dataContractImporter))
                {
                    Console.WriteLine("Couldn't find the XsdDataContractImporter! Adding custom importer.");
                    xsdDCImporter = new XsdDataContractImporter();
                    xsdDCImporter.Options = new ImportOptions();
                    importer.State.Add(typeof(XsdDataContractImporter), xsdDCImporter);
                }
                else
                {
                    xsdDCImporter = (XsdDataContractImporter)dataContractImporter;
                    if (xsdDCImporter.Options == null)
                    {
                        Console.WriteLine("There were no ImportOptions on the importer.");
                        xsdDCImporter.Options = new ImportOptions();
                    }
                }
                ////TODO: This is a customer implementation using the IDataContractSurrogate interface
                // xsdDCImporter.Options.DataContractSurrogate = new DCAnnotationSurrogate();

                // Uncomment the following code if you are going to do your work programmatically rather than add 
                // the WsdlDocumentationImporters through a configuration file. 
                /*
                // The following code inserts a custom WsdlImporter without removing the other 
                // importers already in the collection.
                System.Collections.Generic.IEnumerable<IWsdlImportExtension> exts = importer.WsdlImportExtensions;
                System.Collections.Generic.List<IWsdlImportExtension> newExts 
                  = new System.Collections.Generic.List<IWsdlImportExtension>();
                foreach (IWsdlImportExtension ext in exts)
                {
                  Console.WriteLine("Default WSDL import extensions: {0}", ext.GetType().Name);
                  newExts.Add(ext);
                }
                newExts.Add(new WsdlDocumentationImporter());
                System.Collections.Generic.IEnumerable<IPolicyImportExtension> polExts = importer.PolicyImportExtensions;
                importer = new WsdlImporter(metaDocs, polExts, newExts);
                */

                System.Collections.ObjectModel.Collection<ContractDescription> contracts = importer.ImportAllContracts();

                importer.ImportAllEndpoints();

                foreach (ContractDescription contract in contracts)
                {
                    generator.GenerateServiceContractType(contract);
                }

                if (generator.Errors.Count != 0)
                    throw new Exception("There were errors during code compilation.");

                // Write the code dom
                System.CodeDom.Compiler.CodeGeneratorOptions options = new System.CodeDom.Compiler.CodeGeneratorOptions();
                options.BracingStyle = "C";
                System.CodeDom.Compiler.CodeDomProvider codeDomProvider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("C#");
                System.CodeDom.Compiler.IndentedTextWriter textWriter = new System.CodeDom.Compiler.IndentedTextWriter(new System.IO.StreamWriter(outputFile));

                codeDomProvider.GenerateCodeFromCompileUnit(generator.TargetCompileUnit, textWriter, options);

                textWriter.Close();
            }
            catch(FaultException fx)
            {
                MessageBox.Show(fx.Message + " > " + fx.Reason + " > " + fx.Action + " > " + fx.Data + " > " + fx.Code + " > " + fx.InnerException);
            }
            catch(TimeoutException tx)
            {
                MessageBox.Show(tx.Message + " > " + tx.Data + " > " + tx.InnerException);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

       
    }
}
