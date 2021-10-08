using System;
using System.Collections.Generic;
using System.Text;

namespace MazeBuilder.Data
{
    public class Maze
    {
        public Maze(
            int roomLimit,
            int gridWidth,
            int gridHeight)
        {
            RoomLimt = roomLimit;
            RoomGrid = new Room[gridWidth, gridHeight];
        }

        public Room[,] RoomGrid { get; private set; }
        public Room StartRoom { get; set; } = new Room(0,0);
        public Room EndRoom { get; set; } = new Room(0,0);
        public int RoomLimt { get; private set; }
    }
}
