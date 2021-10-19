using System.Drawing;

namespace MapBuilder.Data
{
    public class Map
    {
        public Map(
            int roomLimit,
            int gridWidth,
            int gridHeight)
        {
            RoomLimit = roomLimit;
            RoomGrid = new Room[gridWidth, gridHeight];
        }

        public Room[,] RoomGrid { get; private set; }
        public Point StartingPoint { get; set; } = new Point();
        public Point EndingPoint { get; set; } = new Point();
        public int RoomLimit { get; private set; }
    }
}
