using MazeBuilder.Data;
using MazeBuilder;
using System;
using System.Collections.Generic;
using System.Text;
using MazeBuilder.Core;
using System.Linq;
using MazeBuilder.Core.Contracts;

namespace MazeBuilder.Service
{
    public class RoomService: IRoomService
    {
        private readonly Random _random;
        private readonly IDoorService _doorService;
        public RoomService(IDoorService doorService)
        {
            _random = new Random();
            _doorService = doorService;
        }
    }
}
