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
        public RoomServiceTest()
        {
        }

        [Fact]
        public void ShouldHaveNoMorethan4Doors()
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
    }
}
