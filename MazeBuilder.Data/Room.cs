using System;
using System.Collections.Generic;

namespace MazeBuilder.Data
{
    public class Room
    {
        public Room(int latitude, int longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public int Latitude { get; private set; }
        public int Longitude { get; private set; }

        public List<string> Doors { get; set; } = new List<string>() { "North"};
    }
}