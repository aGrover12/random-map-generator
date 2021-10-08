using MazeBuilder.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeBuilder.Service
{
    public class MazeService
    {
        public MazeService()
        {
        }

        public Maze CreateMaze(int roomLimit = 5)
        {
            var halvedLimit = roomLimit / 2;
            var side = roomLimit + halvedLimit;

            var maze = new Maze(roomLimit, side, side);
            maze.StartRoom = AddMazeRoom(halvedLimit, halvedLimit);
            return maze;
        }

        private Room AddMazeRoom(int latitude, int longitude)
        {
            return new Room(latitude, longitude);
        }
    }
}
