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
            var room = new Room(0,0);
            Assert.True(room.Doors.Count <= 4);
        }

        [Fact]
        public void ShouldHaveDirectionOfDoors()
        {
            var room = new Room(0,0);
            var directions = new List<string>() { "North", "South", "East", "West" };

            Assert.True(room.Doors.All(door => directions.Contains(door)));
        }

        [Fact]
        public void ShouldContainRandomNumberOfDoors()
        {
            var random = new Random();
            var room = new Room(0, 0);
            var amount = random.Next(1, 4);

            room.Doors = roomService.AddDoors(amount);

            Assert.Equal(amount, room.Doors.Count);
        }

        [Fact]
        public void ShouldNotContainDuplicateDoorDirections()
        {
            var random = new Random();
            var room = new Room(0, 0);
            var amount = random.Next(1, 4);

            room.Doors = roomService.AddDoors(amount);

            Assert.True(room.Doors.GroupBy(doors => doors).All(door => door.Count() == 1));
        }
    }
}
