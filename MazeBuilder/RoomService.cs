using MazeBuilder.Data;
using MazeBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
                var num = random.Next(1, 5);
                var direction = Enum.GetName(typeof(Directions), random.Next(1, 5));
                if (doors.Contains(direction))
                    continue;
                doors.Add(direction);
                amount--;
            }    
            return doors;
        }

        private enum Directions { North = 1, South, West, East }
    }
}
