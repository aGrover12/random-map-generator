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
            _mazeService = new MazeService();
        }


        [Fact]
        public void ShouldReturnAGrid()
        {
            var maze = new Maze();
            Assert.IsType<Room[,]>(maze);
        }

        [Fact]
        public void ShouldHaveAStartingRoom()
        {
            var maze = new Maze();
            Assert.IsType<Room>(maze.StartRoom);
        }

        [Fact]
        public void ShouldHaveAnEndRoom()
        {
            var maze = new Maze();
            Assert.IsType<Room>(maze.EndRoom);
        }
    }
}
