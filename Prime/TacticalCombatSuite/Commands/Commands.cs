using System.Collections.Generic;
using TCS.RPG.Items;
using TCS.RPG.Units;


namespace TCS.Commands
{
    enum Commands
    {
       

    }

    class CommandList
    {
        public List<CommandOld> Commands { get; set; } = new List<CommandOld>();
    }

    partial class CommandOld
    {


        string Text { get; set; }
        List<string> Parameters { get; set; } = new List<string>();

        public CommandOld() { }
        public CommandOld(string command)
        {
            Text = command;
        }
        public CommandOld(string command, params string[] param)
        {
            Text = command;

            foreach (string s in param)
                Parameters.Add(s);
        }

        public override string ToString()
        {
            string param = string.Empty;

            foreach (string s in Parameters)
                param += " -" + s;

            return Text + ' ' + param;
        }

        public static partial class Basic
        {
            
        }

        public static class Execute
        {
            public static void Attack(Unit attackingUnit, Unit defendingUnit, Weapon weapon)
            {

            }
        }
    }

    enum Direction
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }
    
    enum CommandType
    {
        Offense,
        Defense,
        Basic
    }

    class TextList
    {
        string Command;
        List<string> Switches;
        System.Windows.Media.Color TextColor;

        public override string ToString()
        {
            string switches = string.Empty;

            foreach (string s in Switches)
                switches += s;

            return Command + ' ' + switches;
        }
    }

    struct ListOfText
    {
        string Command;
        List<string> Switches;
        System.Windows.Media.Color TextColor;
    }

    public static class CmdExct
    {
        //public static bool Execute(ServerCommand command)
        //{


        //    return true;
        //}

        public static bool Execute(string command)
        {


            return true;
        }


    }

    public class ListOfCommands
    {
        private List<string> cmd = new List<string>();

        public ListOfCommands()
        {
            cmd.Add("Say");
            cmd.Add("Move");
            cmd.Add("Attack");
        }

        public void DecipherCommand(string command)
        {
            string[] commandSplit = command.Split(' ');

            switch(command)
            {
                case "Move":
                    break;

            }

        }
    }





    
}
