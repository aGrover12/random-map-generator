using MazeBuilder.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeBuilder.Service
{
    public class MazeService
    {
        public Maze CreateMaze(int roomLimit = 5)
        {
            var side = roomLimit + roomLimit / 2;
            var maze = new Maze(roomLimit, side, side);
            maze.StartRoom = AssignStartRoom(side / 2);
            return maze;
        }

        private Room AddMazeRoom(int latitude, int longitude)
            => new Room(latitude, longitude);

        private Room AssignStartRoom(int side)
            => AddMazeRoom(side, side);
    }
}
