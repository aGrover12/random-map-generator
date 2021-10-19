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
        private int availableRooms;

        public MazeService(RoomService roomService)
        {
            this.roomService = roomService;
        }
        public Maze CreateMaze(int roomLimit = 5)
        {
            var maze = InitializeMaze(roomLimit);
            availableRooms = roomLimit - 2;

            var mazeWithRooms = AddRoomsToMaze(maze);
            return mazeWithRooms;
        }

        private Maze InitializeMaze(int roomLimit)
        {
            var side = roomLimit + roomLimit / 2;
            var maze = new Maze(roomLimit, side, side);
            maze.StartingPoint = AssignPoint(side / 2);
            return maze;
        }

        private Maze AddRoomsToMaze(Maze maze)
        {
            var initiaLizedMaze = maze;
            var startingPoint = initiaLizedMaze.StartingPoint;

            initiaLizedMaze.RoomGrid[startingPoint.X, startingPoint.Y] = CreateMazeRoom(1);
            var completedMaze =  ConnectMazeRooms(initiaLizedMaze);
            return completedMaze;
        }

        private Maze ConnectMazeRooms(Maze maze)
        {
            var completedMaze = maze;
            var roomLevel = 1;
            var random = new Random();

            while (availableRooms > 0)
            {
             for(var i = 0; i < completedMaze.RoomGrid.GetLength(0); i++)
                for(var j = 0; j < completedMaze.RoomGrid.GetLength(1); j++)
                {
                    var currentRoom = completedMaze.RoomGrid[i, j];

                        if (currentRoom?.Level == roomLevel)
                        {
                            var roomPoint = new Point(i, j);
                            var maxDoors = availableRooms > 4 ? 4 : availableRooms;

                            if (maxDoors == 1)
                            {
                                CreateEndingRoom(maze, roomPoint, roomLevel);
                                continue;
                            }
                            else if (maxDoors == 0)
                                continue;

                            currentRoom.Doors = roomService.AddDoors(random.Next(2, maxDoors));
                            currentRoom.Doors.ForEach(door => AddMazeRoom(completedMaze, roomPoint, door, roomLevel + 1));
                        }
                }
                roomLevel++;
            }

            return completedMaze;
        }

        private void CreateEndingRoom(Maze maze, Point point, int level)
        {
            while(true)
            {
                var direction = DoorHelper.FindDoorDirection();
                var newPoint = DoorHelper.FindPointAfterEnteringDoor(point, direction);
                if (maze.RoomGrid[newPoint.X, newPoint.Y] != null)
                    continue;
                maze.EndingPoint = newPoint;
                maze.RoomGrid[newPoint.X, newPoint.Y] = CreateMazeRoom(level);
                availableRooms--;
                return;
            }
        }

        private Point AssignPoint(int side)
            => new Point(side, side);

        private void AddMazeRoom(Maze maze, Point point, string doorDirection, int level)
        {
            var newPoint = DoorHelper.FindPointAfterEnteringDoor(point, doorDirection);
            if (maze.RoomGrid[newPoint.X, newPoint.Y] == null)
            {
                maze.RoomGrid[newPoint.X, newPoint.Y] = CreateMazeRoom(level); 
                maze.RoomGrid[newPoint.X, newPoint.Y].Doors.Add(DoorHelper.OppositeDoorDirection(doorDirection));
                availableRooms--;
                return;
            }

            AddDoorToExistingRoom(maze.RoomGrid[newPoint.X, newPoint.Y], doorDirection);
        }

        private void AddDoorToExistingRoom(Room room, string direction)
            => room.Doors.Add(DoorHelper.OppositeDoorDirection(direction));

        private Room CreateMazeRoom(int level)
            => new Room(level);
    }
}
