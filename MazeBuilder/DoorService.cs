using MazeBuilder.Core;
using MazeBuilder.Core.Contracts;
using MazeBuilder.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeBuilder.Service
{
    public class DoorService: IDoorService
    {
        private readonly Random _random;

        public DoorService()
        {
            _random = new Random();
        }
            
        public Door CreateDoor()
        {
            return new Door()   
            {
                Direction = RandomlyAssignDoorDirection()
            };
        }

        private string RandomlyAssignDoorDirection()
        {
            return RetrieveDirection(_random.Next(1, 5));
        }

        private string RetrieveDirection(int selector)
        {
            switch (selector)
            {
                case 1:
                    return "North";
                case 2:
                    return "South";
                case 3:
                    return "East";
                case 4:
                    return "West";
                default:
                    return "";
            }
        }   
    }
}
