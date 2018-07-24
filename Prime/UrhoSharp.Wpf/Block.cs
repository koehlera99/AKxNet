using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urho;
using Urho.Shapes;

namespace UrhoSharp.Wpf
{
    class Block : IEquatable<Block>
    {
        public Vector3 Location
        {
            get
            {
                if (BlockNode.Position.X % 5f != 0 || BlockNode.Position.Y % 5f != 0 || BlockNode.Position.Z % 5f != 0)
                {
                    int r = 4;
                }

                return BlockNode.Position;
            }

            set
            {
                if (value.X % 5f != 0 || value.Y % 5f != 0 || value.Z % 5f != 0)
                {
                    int r = 4;
                }

                BlockNode.Position = value;
            }
        }

        public Material Material { get; set; }
        public Shape Shape { get; set; }
        public Node BlockNode { get; private set; }

        public Block(Node node)
        {
            SetNode(node, 5f);
        }

        public Block(Node node, float scale)
        {
            SetNode(node, scale);
        }

        public void SetNode(Node node, float scale)
        {
            BlockNode = node;
            BlockNode.SetScale(scale);
        }

        public override bool Equals(object obj)
        {
            return obj != null && Equals(obj as Block);
        }

        public bool Equals(Block obj)
        {
            return Location.Equals(obj.Location);
        }

        public override int GetHashCode()
        {
            return Location.GetHashCode();
        }

        public int GetDistance(Block block)
        {
            return (int)Vector3.Distance(this.Location, block.Location);
        }
    }
}
