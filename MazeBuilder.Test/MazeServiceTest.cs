using MazeBuilder.Data;
using MazeBuilder.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MazeBuilder.Test
{
    public class MazeServiceTest
    {
        private readonly MazeService _mazeService;
        private readonly RoomService _roomService;

        public MazeServiceTest()
        {
            var doorService = new DoorService();
            _roomService = new RoomService(doorService);
            _mazeService = new MazeService(_roomService);
        }
        [Fact]
        public void ShouldCreateMazeOfAtleast20Rooms()
        {
            var rooms = _mazeService.CreateMaze();
            Assert.IsType<Room>(rooms.First());
            Assert.Equal(20, rooms.Count());
        }

        [Fact]
        public void ShouldHaveMazeWhereEachRoomIsConnected()
        {
            var maze = _mazeService.CreateMaze();
            var linkedRoomCount = 0;
            for(var i = 0; i < maze.Count()-1; i++)
            {
                foreach(var door in maze[i].Doors)
                {
                    var oppositeDoor = FindOppositeDirection(door.Direction);
                    if (!maze[i + 1].Doors.Any(door => door.Direction == oppositeDoor))
                        continue;
                    else
                    {
                        linkedRoomCount++;
                        break;
                    }
                }
            }
             Assert.Equal(maze.Count()-1, linkedRoomCount);
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
                default:
                    return "East";
            }
        }
    }
}
