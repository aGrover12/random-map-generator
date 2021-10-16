using MazeBuilder.Data;
using MazeBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MazeBuilder.Service.Helpers;
using MazeBuilder.Service.Enums;

namespace MazeBuilder.Service
{
    public class RoomService
    {
        public List<string> AddDoors(string entrance, int amount)
         => AssignDoors(entrance, amount);

        private List<string> AssignDoors(string entrance, int amount)
        {
            var random = new Random();
            var doors = new List<string>();

            doors.Add(DoorHelper.OppositeDoorDirection(entrance));

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
        public Room EnterRoom()
        {
            return new Room();
        }

    }
}
