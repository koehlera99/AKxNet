using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Core.Effects
{
    public class Effect : Object
    {
        private static long TotalCount = 0;
        private static long CurrentEffects = 0;

        //public long Id { get; } = -1;
        public Guid EID { get; }
        public string Name { get; } = string.Empty;
        public int Value { get; } = 0;
        public string Description { get; } = string.Empty;
        public string Source { get; } = string.Empty;
        public int TTL = 0;
        public readonly int OriginalTTL;

        private DateTime Created;
        public TimeSpan Duration;
        public bool IsActive = true;

        public Effect()
        { }

        public Effect(string name, int value, string description = "", string source = "", int timeToLive = 0)
        {
            TotalCount++;
            CurrentEffects++;

            EID = Guid.NewGuid();

            //Id = TotalCount;
            Name = name;
            Value = value;
            Description = description;
            Source = source;
            TTL = timeToLive;
            OriginalTTL = timeToLive;
            Duration = new TimeSpan(0, 0, timeToLive);
            Created = DateTime.Now;
        }

        public void Refresh()
        {
            TimeSpan t = DateTime.Now - Created;
            TTL = OriginalTTL - t.Seconds;

            if (t.Seconds > Duration.Seconds)
            {
                IsActive = false;
            }
        }
    }
}
