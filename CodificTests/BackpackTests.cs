using System;
using System.Linq;
using Codific;
using Codific.Exceptions;
using Codific.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodificTests
{
    [TestClass]
    public class BackpackTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CanPickUpItemThrowsExceptionWhenItemIsNull()
        {
            var backpack = new Backpack();
            backpack.CanPickupItem(null);
        }

        [TestMethod]
        public void CanPickUpItemReturnsFalseWhenThereIsntEnoughWeightCapacityLeft()
        {
            var backpack = new Backpack();
            var item = new Mock<IItem>();
            item.Setup(i => i.Weight).Returns(80);
            var canPickup = backpack.CanPickupItem(item.Object);
            Assert.IsFalse(canPickup);
        }

        [TestMethod]
        public void CanPickItemReturnsTrueWhenThereIsEnoughWeightCapacityLeft()
        {
            var backpack = new Backpack();
            var item = new Mock<IItem>();
            item.Setup(i => i.Weight).Returns(20);
            var canPickup = backpack.CanPickupItem(item.Object);
            Assert.IsTrue(canPickup);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PickupItemThrowsExceptionWhenItemIsNull()
        {
            var backpack = new Backpack();
            backpack.PickupItem(null);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NotEnoughWeightCapacityForItemException))]
        public void PickupItemThrowsExceptionWhenNotEnoughWeightCapacity()
        {
            var backpack = new Backpack();
            var item = new Mock<IItem>();
            item.Setup(i => i.Weight).Returns(100);
            backpack.PickupItem(item.Object);
            
        }

        [TestMethod]
        public void SuccessfullyPickedUpItem()
        {
            var backpack = new Backpack();
            var item = new Mock<IItem>();
            item.Setup(i => i.Weight).Returns(10);
            backpack.PickupItem(item.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundItemInBackpackException))]
        public void DropItemThrowsExceptionWhenItemIsntInTheBackpack()
        {
            var backpack = new Backpack();
            var item = new Mock<IItem>();
            item.Setup(i => i.Weight).Returns(100);
            backpack.DropItem(item.Object);
        }

        [TestMethod]
        public void SuccessfullyRemovesItemFromBackpack()
        {
            var backpack = new Backpack();
            var item = new Mock<IItem>();
            item.Setup(i => i.Weight).Returns(10);
            backpack.PickupItem(item.Object);
            var isItemInBackpack = backpack.CurrentHoldingItems.Contains(item.Object);
            Assert.IsTrue(isItemInBackpack);
        }

        [TestMethod]
        public void RemainingCapacityUpdatesWhenAddedOrRemovedItem()
        {
            var backpack = new Backpack();
            var item = new Mock<IItem>();
            var item2 = new Mock<IItem>();
            item.Setup(i => i.Weight).Returns(10);
            item2.Setup(i => i.Weight).Returns(30);
            backpack.PickupItem(item.Object);
        }
    }
}
