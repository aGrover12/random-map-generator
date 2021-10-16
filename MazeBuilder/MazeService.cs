using MazeBuilder.Data;
using MazeBuilder.Service.Enums;
using MazeBuilder.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MazeBuilder.Service
{
    public class MazeService
    {
        private readonly RoomService roomService;

        public MazeService(RoomService roomService)
        {
            this.roomService = roomService;
        }
        public Maze CreateMaze(int roomLimit = 5)
        {
            var maze = InitializeMaze(roomLimit);
            var mazeWithRooms = CreateRooms(maze);
            return mazeWithRooms;
        }

        private Maze InitializeMaze(int roomLimit)
        {
            var side = roomLimit + roomLimit / 2;
            var maze = new Maze(roomLimit, side, side);
            maze.StartingPoint = AssignStartPoint(side / 2);
            return maze;
        }

        private Maze CreateRooms(Maze maze)
        {
            var completedMaze = maze;
            var startingPoint = completedMaze.StartingPoint;
            var random = new Random();
            var direction = Enum.GetName(typeof(DirectionsEnum.Directions), random.Next(0, 4));

            completedMaze.RoomGrid[startingPoint.X, startingPoint.Y] = AddMazeRoom(direction);
            return completedMaze;
        }

        private Point AssignStartPoint(int side)
            => new Point(side, side);

        private void ConnectNewRoom(Maze maze, Point point, string doorDirection)
        {
            var newPoint = DoorHelper.FindPointAfterEnteringDoor(point, doorDirection);
            maze.RoomGrid[newPoint.X, newPoint.Y] = AddMazeRoom(doorDirection);
        }

        private Room AddMazeRoom(string doorDirection)
        {
            var random = new Random();
            var room = new Room();
            room.Doors = roomService.AddDoors(doorDirection, random.Next(1,4));
            return room;
        }
    }
}
