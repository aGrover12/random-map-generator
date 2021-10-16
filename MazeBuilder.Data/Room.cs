using System;
using System.Collections.Generic;

namespace MazeBuilder.Data
{
    public class Room
    {
        public Room(int level = 1)
        {
            Level = level;
        }
        public int Level { get; set; }
        public List<string> Doors { get; set; } = new List<string>() { "North"};
    }
}