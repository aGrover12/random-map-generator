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
        public RoomService roomService;
        public RoomServiceTest()
        {
            roomService = new RoomService();
        }

        [Fact]
        public void ShouldHaveLessthan4Doors()
        {
            var room = new Room();
            Assert.True(room.Doors.Count <= 4);
        }

        [Fact]
        public void ShouldHaveDirectionOfDoors()
        {
            var room = new Room();
            var directions = new List<string>() { "North", "South", "East", "West" };

            Assert.True(room.Doors.All(door => directions.Contains(door)));
        }

        [Fact]
        public void ShouldContainRandomNumberOfDoors()
        {
            var random = new Random();
            var room = new Room();
            var amount = random.Next(1, 4);

            room.Doors = roomService.AddDoors("North", amount);

            Assert.Equal(amount+1, room.Doors.Count);
        }

        [Fact]
        public void ShouldNotContainDuplicateDoorDirections()
        {
            var random = new Random();
            var room = new Room();
            var amount = random.Next(1, 4);

            room.Doors = roomService.AddDoors("North", amount);

            Assert.True(room.Doors.GroupBy(doors => doors).All(door => door.Count() == 1));
        }

        [Fact]
        public void ShouldContainOppositeDoorOfEntrance()
        {
            var room = new Room();

            room.Doors = roomService.AddDoors("North", 1);
            Assert.Contains("South", room.Doors);
        }

        [Fact]
        public void ShouldDefaultRoomToLevel1()
        {
            var room = new Room();
            Assert.Equal(1, room.Level);
        }

        [Fact]
        public void ShouldReturnARoomWhenRoomEntered()
        {
            Assert.IsType<Room>(roomService.EnterRoom());
        }
    }
}
