using MazeBuilder.Data;
using MazeBuilder.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xunit;

namespace MazeBuilder.Test
{
    public class MazeServiceTest
    {
        private readonly MazeService mazeService;
        private readonly RoomService roomService;
        public MazeServiceTest()
        {
            this.roomService = new RoomService();
            this.mazeService = new MazeService(this.roomService);
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
        public void ShouldHaveStartPoint()
        {
            var maze = mazeService.CreateMaze();
            Assert.IsType<Point>(maze.StartingPoint);
        }

        [Fact]
        public void StartRoomShouldHaveOneDoor()
        {
            var maze = mazeService.CreateMaze();
            var startPoint = maze.StartingPoint;
            var startRoom = maze.RoomGrid[startPoint.X, startPoint.Y];
            Assert.Single(startRoom.Doors); 
        }

        [Fact]
        public void ShouldContainStartRoomAtMiddleOfTheRoom()
        {
            var maze = mazeService.CreateMaze(7);

            var halvedSide = maze.RoomGrid.GetLength(0) / 2;

            Assert.True(maze.StartingPoint.X == halvedSide && maze.StartingPoint.Y == halvedSide);
        }

        [Fact]
        public void ShouldHaveEndingPoint()
        {
            var maze = mazeService.CreateMaze();
            Assert.IsType<Point>(maze.EndingPoint);
        }

        [Fact]
        public void ShouldHaveConnectedRooms()
        {
            Assert.True(false);
        }
    }
}
