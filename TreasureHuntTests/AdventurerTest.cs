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

        [TestMethod()]
        [DataRow(Orientation.NORTH, Orientation.EAST)]
        [DataRow(Orientation.EAST, Orientation.SOUTH)]
        [DataRow(Orientation.SOUTH, Orientation.WEST)]
        [DataRow(Orientation.WEST, Orientation.NORTH)]
        public void Adventurer_Move_Sequence_D(Orientation baseOrientation, Orientation expectedOrientation)
        {
            // Setup
            var adventurer = new Adventurer
            {
                Name = "TestBoi",
                CurrentTurn = 0,
                MoveSequence = "D",
                Orientation = baseOrientation
            };

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
       
    }
}