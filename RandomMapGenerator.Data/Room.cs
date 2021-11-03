using System.Collections.Generic;
using System.Drawing;

namespace MapBuilder.Data
{
    public class Room
    {
        public Room(string roomColor = "red")
        {
            Brush = new SolidBrush(DetermineRoomColor(roomColor));
        }
        public SolidBrush Brush { get; set; }
        public List<string> Doors { get; set; } = new List<string>();

        private Color DetermineRoomColor(string color)
        {
            switch (color)
            {
                case "yellow":
                    return Color.Yellow;
                case "blue":
                    return Color.Blue;
                default:
                    return Color.Red;
            }
        }
    }
}