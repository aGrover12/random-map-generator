using System;
using System.Collections.Generic;

namespace MazeBuilder.Data
{
    public class Room
    {
        public Room()
        {
        }

        public List<string> Doors { get; set; } = new List<string>() { "North"};
    }
}