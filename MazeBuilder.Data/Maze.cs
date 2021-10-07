using System;
using System.Collections.Generic;
using System.Text;

namespace MazeBuilder.Data
{
    public class Maze
    {
        public Room[,] RoomGrid { get; set; } 
        public Room StartRoom { get; set; } = new Room();
        public Room EndRoom { get; set; } = new Room();
    }
}
