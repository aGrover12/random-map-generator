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
        private readonly MazeService mazeService;
        public MazeServiceTest()
        {
            this.mazeService = new MazeService();
        }
        [Fact]
        public void ShouldCreateAMaze()
        {
            var maze = mazeService.CreateMaze();
            Assert.IsType<Maze>(maze);
        }


        [Fact]
        public void ShouldBeAbleToProvideRoomLimit()
        {
            var maze = mazeService.CreateMaze(10);
            Assert.Equal(10, maze.RoomLimt);
        }

        [Fact]
        public void ShouldHaveADefaultOf5RoomsForRoomLimit()
        {
            var maze = mazeService.CreateMaze();
            Assert.Equal(5, maze.RoomLimt);
        }

        [Fact]
        public void ShouldContainARoomGrid()
        {
            var maze = mazeService.CreateMaze();
            Assert.IsType<Room[,]>(maze.RoomGrid);
        }

        [Fact]
        public void ShouldContainGridWithSidesGreaterThanSizeOfRoomLimitByHalfOfRoomLimit()
        {
            var maze = mazeService.CreateMaze(7);
            
            var halvedLimt = maze.RoomLimt / 2;
            var side = maze.RoomLimt + halvedLimt;

            var width = maze.RoomGrid.GetLength(0);
            var height = maze.RoomGrid.GetLength(1);

            Assert.True(width == side && height == side);
        }

        [Fact]
        public void ShouldHaveAStartingRoom()
        {
            var maze = mazeService.CreateMaze();
            Assert.IsType<Room>(maze.StartRoom);
        }

        [Fact]
        public void ShouldContainStartRoomAtLongitudeAndLatitudeEqualToHalfTheSizeOfTheRoomLimit()
        {
            var maze = mazeService.CreateMaze(7);

            var halvedLimt = maze.RoomLimt / 2;

            Assert.True(maze.StartRoom.Latitude == halvedLimt && maze.StartRoom.Longitude == halvedLimt);
        }

        [Fact]
        public void ShouldHaveAnEndRoom()
        {
            var maze = mazeService.CreateMaze();
            Assert.IsType<Room>(maze.EndRoom);
        }
    }
}
