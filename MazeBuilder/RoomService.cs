using MazeBuilder.Data;
using MazeBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using MazeBuilder.Core;
using System.Linq;
using MazeBuilder.Core.Contracts;

namespace MazeBuilder.Service
{
    public class RoomService: IRoomService
    {
        private readonly Random _random;
        private readonly IDoorService _doorService;
        public RoomService(IDoorService doorService)
        {
            _random = new Random();
            _doorService = doorService;
        }
        public Room CreateRoom(string roomDirection = "")
        {
            var doors = new List<Door>();
            for(var i = 0; i < _random.Next(1,4); i++)
            {
                var door = CreateOriginalDoor(roomDirection);
                roomDirection = door.Direction;
                doors.Add(door);
            }

            var room = new Room()
            {
                Doors = doors
            };
            
            return room;
        }

        private Door CreateOriginalDoor(string direction)
        {
            var door = _doorService.CreateDoor();
            while (door.Direction == direction)
                door = _doorService.CreateDoor();
            return door;
        }

        public Door SelectDoor(Room room, string direction)
        {
            var selectedDoor = room.Doors.First(door => door.Direction == direction);
            selectedDoor.CanOpen = true;

            return selectedDoor;
        }

        public Room OpenDoor(Door door)
        {
            if (!door.CanOpen)
                throw new InvalidOperationException("Cannot open door if not selected");
            var newDoor = new Door() { Direction = FindOppositeDirection(door.Direction) };
            var newRoom = CreateRoom(newDoor.Direction);
            newRoom.Doors.Add(newDoor);
            return newRoom;
        }

        private string FindOppositeDirection(string direction)
        {
            switch (direction)
            {
                case "North":
                    return "South";
                case "South":
                    return "North";
                case "East":
                    return "West";
                case "West":
                    return "East";
            }
        throw new ArgumentException("Invalid Direction");
        }
    }
}
