using System;
using System.Collections.Generic;

namespace MazeBuilder.Data
{
    public class Room
    {
        public Room()
        {
        }

        public int Walls { get; set; } = 4;
        public List<Door> Doors { get; set; }
    }
}