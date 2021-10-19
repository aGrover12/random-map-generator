using MapBuilder.Data;
using MapBuilder.Service.Helpers;
using System;
using System.Drawing;

namespace MapBuilder.Service
{
    public class MapService
    {
        private readonly RoomService roomService;
        private int availableRooms;

        public MapService(RoomService roomService)
        {
            this.roomService = roomService;
        }
        public Map CreateMap(int roomLimit = 5)
        {
            var map = InitializeMap(roomLimit);
            availableRooms = roomLimit - 2;

            var mapWithRooms = AddRoomsToMap(map);
            return mapWithRooms;
        }

        private Map InitializeMap(int roomLimit)
        {
            var side = roomLimit + roomLimit / 2;
            var map = new Map(roomLimit, side, side);
            map.StartingPoint = AssignPoint(side / 2);
            return map;
        }

        private Map AddRoomsToMap(Map map)
        {
            var initiaLizedMap = map;
            var startingPoint = initiaLizedMap.StartingPoint;

            initiaLizedMap.RoomGrid[startingPoint.X, startingPoint.Y] = CreateMapRoom();
            var completedMap =  ConnectMapRooms(initiaLizedMap);
            return completedMap;
        }

        private Map ConnectMapRooms(Map map)
        {
            var completedMap = map;
            var roomLevel = 1;
            var random = new Random();

            while (availableRooms > 0)
            {
             for(var i = 0; i < completedMap.RoomGrid.GetLength(0); i++)
                for(var j = 0; j < completedMap.RoomGrid.GetLength(1); j++)
                {
                    var currentRoom = completedMap.RoomGrid[i, j];

                        if (currentRoom != null)
                        {
                            var roomPoint = new Point(i, j);
                            var maxDoors = availableRooms > 4 ? 4 : availableRooms;

                            if (maxDoors == 1)
                            {
                                CreateEndingRoom(map, roomPoint);
                                continue;
                            }
                            else if (maxDoors == 0)
                                continue;

                            currentRoom.Doors = roomService.AddDoors(random.Next(2, maxDoors));
                            currentRoom.Doors.ForEach(door => AddMapRoom(completedMap, roomPoint, door));
                        }
                }
            }

            return completedMap;
        }

        private void CreateEndingRoom(Map map, Point point)
        {
            while(true)
            {
                var direction = DoorHelper.FindDoorDirection();
                var newPoint = DoorHelper.FindPointAfterEnteringDoor(point, direction);
                if (map.RoomGrid[newPoint.X, newPoint.Y] != null)
                    continue;
                map.EndingPoint = newPoint;
                map.RoomGrid[newPoint.X, newPoint.Y] = CreateMapRoom();
                availableRooms--;
                return;
            }
        }

        private Point AssignPoint(int side)
            => new Point(side, side);

        private void AddMapRoom(Map map, Point point, string doorDirection)
        {
            var newPoint = DoorHelper.FindPointAfterEnteringDoor(point, doorDirection);
            if (map.RoomGrid[newPoint.X, newPoint.Y] == null)
            {
                map.RoomGrid[newPoint.X, newPoint.Y] = CreateMapRoom(); 
                map.RoomGrid[newPoint.X, newPoint.Y].Doors.Add(DoorHelper.OppositeDoorDirection(doorDirection));
                availableRooms--;
                return;
            }

            AddDoorToExistingRoom(map.RoomGrid[newPoint.X, newPoint.Y], doorDirection);
        }

        private void AddDoorToExistingRoom(Room room, string direction)
            => room.Doors.Add(DoorHelper.OppositeDoorDirection(direction));

        private Room CreateMapRoom()
            => new Room();
    }
}
