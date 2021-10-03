using MazeBuilder.Data;
using MazeBuilder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MazeBuilder.Test
{
    public class RoomServiceTest
    {
        private readonly RoomService _roomService;
        private readonly DoorService _doorService;
        public RoomServiceTest()
        {
            _doorService = new DoorService();
            _roomService = new RoomService(_doorService);
        }

        [Fact]
        public void ShouldCreateRoom()
        {
            Assert.IsType<Room>(_roomService.CreateRoom());
        }

        [Fact]
        public void ShouldCreateRoomsWithAtleastFourWalls()
        {
            var room = _roomService.CreateRoom();
            Assert.True(room.Walls >= 4);
        }

        [Fact]
        public void ShouldCreateRoomsWithAtleastOneDoor()
        {
            var room = _roomService.CreateRoom();
            Assert.True(room.Doors.Count >= 1);
        }

        [Fact]
        public void ShouldCreateRoomsWithNoMoreThanFourDoors()
        {
            var room = _roomService.CreateRoom();
            Assert.True(room.Doors.Count() < 4);
        }

        [Fact]
        public void ShouldBeAbleToRetrieveAListOfDoors()
        {
            var room = _roomService.CreateRoom();
            var doors = room.Doors;
            Assert.IsType<List<Door>>(doors);
        }

        [Fact]
        public void ShouldBeAbleToSelectADoor()
        {
            var room = _roomService.CreateRoom();
            var direction = room.Doors.First().Direction;
            var door = _roomService.SelectDoor(room, direction);
            Assert.IsType<Door>(door);
        }

        [Fact]
        public void ShouldBeAbleToOpenDoorAfterItIsSelected()
        {
            var room = _roomService.CreateRoom();
            var direction = room.Doors.First().Direction;
            var door = _roomService.SelectDoor(room, direction);
            Assert.True(door.CanOpen);
        }

        [Fact]
        public void ShouldBeAbleToSelectDoorByDirection()
        {
            var room = _roomService.CreateRoom();
            var door = room.Doors.First();
            var selectedDoor = _roomService.SelectDoor(room, door.Direction);
            Assert.True(selectedDoor.Direction == door.Direction);
        }

        [Fact]
        public void ShouldOnlyBeAbleToEnterRoomWhenDoorIsSelected()
        {
            var room = _roomService.CreateRoom();
            var direction = room.Doors.First().Direction;
            var door = _roomService.SelectDoor(room, direction);
            var newRoom = _roomService.OpenDoor(door);
            Assert.NotEqual(room, newRoom);
        }

        [Fact]
        public void ShouldThrowInvalidOperationExceptionIfDoorOpenedBeforeSelected()
        {
            var room = _roomService.CreateRoom();
            Assert.Throws<InvalidOperationException>(() => _roomService.OpenDoor(room.Doors.First()));
        }
        
        [Fact]
        public void ShouldAssignDoorDirectionWhenCreated()
        {
            var room = _roomService.CreateRoom();
            Assert.Contains(room.Doors.First().Direction, new List<string>() { 
            "North", "South", "East", "West"
            });
        }

        [Fact]
        public void ShouldContainDoorOfOpositeDirectionOfOneEntered()
        {
            var newRoom = _roomService.OpenDoor(new Door()
            {
                Direction = "North",
                CanOpen = true
            });

            var result = newRoom.Doors.Any(door => door.Direction == "South");
            Assert.True(result);
        }

        [Fact] 
        public void ShouldNotContainAnotherDoorOfTheSameDirection()
        {
            var newRoom = _roomService.OpenDoor(new Door()
            {
                Direction = "North",
                CanOpen = true
            });

            var southDoorCount = newRoom.Doors.Where(door => door.Direction == "South").Count();

            Assert.Equal(1, southDoorCount);
        }

        [Fact]
        public void ShouldHaveRoomsWithDoorsConnectedToAnotherRoom()
        {
            Assert.True(false);
        }
    }
}
