using MazeBuilder.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeBuilder.Service
{
    public class MazeService
    {
        private readonly RoomService _roomService;

        public MazeService(RoomService roomService)
        {
            _roomService = roomService;
        }

        public List<Room> CreateMaze()
        {
            var maze = new List<Room>() 
            { 
                _roomService.CreateRoom()
            };  

            for(int i = 0; i < 19; i++)
            {
                var room = maze[i];
                var door = room.Doors[0];
                var direction = door.Direction;
                var selectedDoor = _roomService.SelectDoor(room, direction);
                maze.Add(_roomService.OpenDoor(selectedDoor));
            }

            return maze;        
        }
    }
}
