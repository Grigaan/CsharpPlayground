using Microsoft.VisualStudio.TestTools.UnitTesting;
using TreasureHunt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace TreasureHunt.Tests
{
    [TestClass()]
    public class AdventurerTest
    {
        private static readonly IMock<Map> _mapMock;

        //[TestMethod()]
        //public void Adventurer_Move_Orientation_Is_North_Should_Be_East()
        //{
        //    var adventurer = new Adventurer();

        //    // Setup
        //    adventurer.Name = "TestBoi";
        //    adventurer.CurrentTurn = 0;
        //    adventurer.MoveSequence = "D";
        //    adventurer.Orientation = Orientation.NORTH;
        //    adventurer.Move();
        //    Assert.AreEqual(adventurer.Orientation, Orientation.EAST);
        //    Assert.IsTrue(adventurer.IsDone);
        //}

        //[TestMethod()]
        //public void Adventurer_Move_Orientation_Is_East_Should_Be_South()
        //{
        //    var adventurer = new Adventurer();

        //    // Setup
        //    adventurer.Name = "TestBoi";
        //    adventurer.CurrentTurn = 0;
        //    adventurer.MoveSequence = "D";
        //    adventurer.Orientation = Orientation.EAST;
        //    adventurer.Move();
        //    Assert.AreEqual(adventurer.Orientation, Orientation.SOUTH);
        //    Assert.IsTrue(adventurer.IsDone);
        //}

        [TestMethod()]
        [DataRow(Orientation.NORTH, Orientation.EAST)]
        [DataRow(Orientation.EAST, Orientation.SOUTH)]
        [DataRow(Orientation.SOUTH, Orientation.WEST)]
        [DataRow(Orientation.WEST, Orientation.NORTH)]
        public void Adventurer_Move_Sequence_D(Orientation baseOrientation, Orientation expectedOrientation)
        {
            // Setup
            var adventurer = new Adventurer();
            adventurer.Name = "TestBoi";
            adventurer.CurrentTurn = 0;
            adventurer.MoveSequence = "D";
            adventurer.Orientation = baseOrientation;

            // Act
            adventurer.Move();
            
            // Assertions 
            Assert.AreEqual(adventurer.Orientation, expectedOrientation);
            Assert.IsTrue(adventurer.IsDone);
        }

        [TestMethod()]
        [DataRow(Orientation.NORTH, Orientation.WEST)]
        [DataRow(Orientation.EAST, Orientation.NORTH)]
        [DataRow(Orientation.SOUTH, Orientation.EAST)]
        [DataRow(Orientation.WEST, Orientation.SOUTH)]
        public void Adventurer_Move_Sequence_G(Orientation baseOrientation, Orientation expectedOrientation)
        {
            // Setup
            var adventurer = new Adventurer();
            adventurer.Name = "TestBoi";
            adventurer.CurrentTurn = 0;
            adventurer.MoveSequence = "G";
            adventurer.Orientation = baseOrientation;

            // Act
            adventurer.Move();

            // Assertions 
            Assert.AreEqual(adventurer.Orientation, expectedOrientation);
            Assert.IsTrue(adventurer.IsDone);
        }

        [TestMethod()]        
        public void Adventurer_Move_Forward()
        {
            // Setup
            var mapMock = new Mock<IMap>();
            var adventurerTile = new Tile(0, 1);
            var nextTile = new Tile(0, 0);
            var adventurer = new Adventurer("Testboi", "0", "0", Orientation.NORTH, "A", mapMock.Object)
            {
                CurrentTurn = 0,
                CurrentTile = adventurerTile
            };
            

            mapMock.Setup(mock => mock.IsValidMoveLocation(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            mapMock.Setup(mock => mock.GetTile(It.IsAny<int>(), It.IsAny<int>())).Returns(nextTile);

            // Act
            adventurer.Move();

            // Assertions 
            Assert.AreEqual(adventurer.Orientation, Orientation.NORTH);
            Assert.IsTrue(adventurer.IsDone);
            Assert.AreEqual(adventurer.CurrentTile, nextTile);
        }



        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            //_mapMock = new Map();
        }

        [TestInitialize]
        public void TestInitialize()
        {

        }
    }
}