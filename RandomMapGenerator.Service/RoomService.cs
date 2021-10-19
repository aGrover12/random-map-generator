using System.Collections.Generic;
using MapBuilder.Service.Helpers;
using System.Drawing;
using MapBuilder.Data;

namespace MapBuilder.Service
{
    public class RoomService
    {
        public List<string> AddDoors(int amount)
            => AssignDoors(amount);

        private List<string> AssignDoors(int amount)
        {
            var doors = new List<string>();

            while (amount > 0)
            {
                var direction = DoorHelper.FindDoorDirection();
                if (doors.Contains(direction))
                    continue;
                doors.Add(direction);
                amount--;
            }    
            return doors;
        }

        public Room EnterRoom(Map map, Point point)
            => map.RoomGrid[point.X, point.Y];
    }
}
