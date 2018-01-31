namespace DnD.Core
{
    public abstract class Object
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        protected Object() { }
        protected Object(int id)
        {
            id = Id;
        }

        protected Object(string name)
        {
            Name = name;
        }

        protected Object(string name, string description)
        {
            Name = name;
            Description = description;
        }

        protected Object(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
