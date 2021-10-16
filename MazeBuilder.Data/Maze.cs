using System;
using System.Collections.Generic;
using System.Drawing;
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
        public Point StartingPoint { get; set; } = new Point();
        public Point EndingPoint { get; set; } = new Point();
        public int RoomLimt { get; private set; }
    }
}
