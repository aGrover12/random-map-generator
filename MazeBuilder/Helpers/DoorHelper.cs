using MazeBuilder.Service.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MazeBuilder.Service.Helpers
{
    public static class DoorHelper
    {
        public static string OppositeDoorDirection(string direction)
        {
            var oppositeDirection = "";
            switch (direction)
            {
                case "North":
                    oppositeDirection = "South";
                    break;
                case "South":
                    oppositeDirection = "North";
                    break;
                case "East":
                    oppositeDirection = "West";
                    break;
                case "West":
                    oppositeDirection = "East";
                    break;
            }

            return oppositeDirection;
        }

        public static Point FindPointAfterEnteringDoor(Point point, string doorDirection)
        {
            var newPoint = new Point();
            switch (doorDirection)
            {
                case "North":
                    newPoint = new Point(point.X, point.Y + 1);
                    break;
                case "South":
                    newPoint = new Point(point.X, point.Y - 1);
                    break;
                case "East":
                    newPoint = new Point(point.X + 1, point.Y);
                    break;
                case "West":
                    newPoint = new Point(point.X - 1 , point.Y);
                    break;
            }

            return newPoint;
        }

        public static string FindDoorDirection()
        {
            var random = new Random();
            return Enum.GetName(typeof(DirectionsEnum.Directions), random.Next(0, 4));
        }
    }
}
