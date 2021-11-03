using MapBuilder.Data;
using MapBuilder.Service;
using MapBuilder.Service.Helpers;
using System.Drawing;
using System.Linq;
using Xunit;

namespace MapBuilder.Test
{
    public class MapServiceTest
    {
        private readonly MapService mapService;
        private readonly RoomService roomService;
        public MapServiceTest()
        {
            this.roomService = new RoomService();
            this.mapService = new MapService(this.roomService);
        }
        [Fact]
        public void ShouldCreateAMap()
        {
            var map = mapService.CreateMap();
            Assert.IsType<Map>(map);
        }


        [Fact]
        public void ShouldBeAbleToProvideRoomLimit()
        {
            var map = mapService.CreateMap(10);
            Assert.Equal(10, map.RoomLimit);
        }

        [Fact]
        public void ShouldHaveADefaultOf5RoomsForRoomLimit()
        {
            var map = mapService.CreateMap();
            Assert.Equal(5, map.RoomLimit);
        }

        [Fact]
        public void ShouldContainARoomGrid()
        {
            var map = mapService.CreateMap();
            Assert.IsType<Room[,]>(map.RoomGrid);
        }

        [Fact]
        public void ShouldContainGridWithSidesGreaterThanSizeOfRoomLimitByHalfOfRoomLimit()
        {
            var map = mapService.CreateMap(7);
            
            var halvedLimt = map.RoomLimit / 2;
            var side = map.RoomLimit + halvedLimt;

            var width = map.RoomGrid.GetLength(0);
            var height = map.RoomGrid.GetLength(1);

            Assert.True(width == side && height == side);
        }

        [Fact]
        public void ShouldHaveStartPoint()
        {
            var map = mapService.CreateMap();
            Assert.IsType<Point>(map.StartingPoint);
        }


        [Fact]
        public void ShouldContainStartRoomAtMiddleOfTheRoom()
        {
            var map = mapService.CreateMap(7);

            var halvedSide = map.RoomGrid.GetLength(0) / 2;

            Assert.True(map.StartingPoint.X == halvedSide && map.StartingPoint.Y == halvedSide);
        }

        [Fact]
        public void ShouldHaveEndingPoint()
        {
            var map = mapService.CreateMap();
            Assert.IsType<Point>(map.EndingPoint);
        }

        [Fact]
        public void ShouldReturnARoomWhenRoomEntered()
        {
            var map = mapService.CreateMap();

            var startingPoint = map.StartingPoint;
            var startRoom = map.RoomGrid[startingPoint.X, startingPoint.Y];

            var nextRoomPoint = DoorHelper.FindPointAfterEnteringDoor(startingPoint, startRoom.Doors.First());

            Assert.IsType<Room>(roomService.EnterRoom(map, nextRoomPoint));
        }

        [Fact]
        public void ShouldHaveConnectedRooms()
        {
            var map = mapService.CreateMap();

            var startingPoint = map.StartingPoint;
            var startRoom = map.RoomGrid[startingPoint.X, startingPoint.Y];
            var startDoor = startRoom.Doors.First();

            var currentRoomPoint = DoorHelper.FindPointAfterEnteringDoor(startingPoint, startDoor);

            var previousDoor = DoorHelper.OppositeDoorDirection(startDoor);
            var previousPoint = DoorHelper.FindPointAfterEnteringDoor(currentRoomPoint, previousDoor);

            Assert.Equal(startRoom, roomService.EnterRoom(map, previousPoint));
        }

        [Fact]
        public void ShouldHaveBlueStartRoom()
        {
            var map = mapService.CreateMap();
            var color = Color.Blue;

            var startingPoint = map.StartingPoint;
            var startRoom = map.RoomGrid[startingPoint.X, startingPoint.Y];

            Assert.Equal(color, startRoom.Brush.Color);
        }

        [Fact]
        public void ShouldHaveYellowEndRoom()
        {
            var map = mapService.CreateMap();
            var color = Color.Yellow;

            var endingPoint = map.EndingPoint;
            var endRoom = map.RoomGrid[endingPoint.X, endingPoint.Y];

            Assert.Equal(color, endRoom.Brush.Color);
        }
    }
}
