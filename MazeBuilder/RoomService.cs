using MazeBuilder.Data;
using MazeBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MazeBuilder.Service.Helpers;
using MazeBuilder.Service.Enums;
using System.Drawing;

namespace MazeBuilder.Service
{
    public class RoomService
    {
        public List<string> AddDoors(int amount)
            => AssignDoors(amount);

        private List<string> AssignDoors(int amount)
        {
            var random = new Random();
            var doors = new List<string>();

            while (amount > 0)
            {
                var direction = Enum.GetName(typeof(DirectionsEnum.Directions), random.Next(0, 4));
                if (doors.Contains(direction))
                    continue;
                doors.Add(direction);
                amount--;
            }    
            return doors;
        }

        public Room EnterRoom(Maze maze, Point point)
            => maze.RoomGrid[point.X, point.Y];
    }
}
