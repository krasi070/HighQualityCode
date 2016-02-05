namespace DynamicListTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CustomLinkedList;

    [TestClass]
    public class DynamicListTest
    {
        private DynamicList<int> dynamicList;

        [TestInitialize]
        public void SetUp()
        {
            this.dynamicList = new DynamicList<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndex_NegativeIndex_ExpectedArgumentOutOfRangeException()
        {
            int number = dynamicList[-3];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIndex_IndexBiggerThanCount_ExpectedArgumentOutOfRangeException()
        {
            AddFiveIntegers(dynamicList);
            int number = dynamicList[6];
        }

        [TestMethod]
        public void TestIndex_PositiveIndexLowerThanCount_ExpectedElementValue()
        {
            const int ExpectedValue = 2;

            AddFiveIntegers(dynamicList);

            Assert.AreEqual(ExpectedValue, dynamicList[1], "Index didn't return correct element. Expected " + ExpectedValue);
        }

        [TestMethod]
        public void TestIndex_SeveralNonNegativeValidIndexes_ExpectedCorrespondingValues()
        {
            const int FirstExpectedValue = 378;
            const int SecondExpectedValue = 6;
            const int ThirdExpectedValue = 1;

            AddFiveIntegers(dynamicList);

            Assert.AreEqual(FirstExpectedValue, dynamicList[4], "First expected value was incorrect. Expected " + FirstExpectedValue);
            Assert.AreEqual(SecondExpectedValue, dynamicList[3], "Second expected value was incorrect. Expected " + SecondExpectedValue);
            Assert.AreEqual(ThirdExpectedValue, dynamicList[0], "Third expected value was incorrect. Expected " + ThirdExpectedValue);
        }

        [TestMethod]
        public void TestAdd_OneAdd_ExpectedCountOne()
        {
            const int ExpectedCount = 1;

            dynamicList.Add(3781);

            Assert.AreEqual(ExpectedCount, dynamicList.Count, "Count was incorrect. Expected " + ExpectedCount);
        }

        [TestMethod]
        public void TestAdd_AddSeveral_ExpectedCountSeveral()
        {
            const int ExpectedCount = 5;

            AddFiveIntegers(dynamicList);

            Assert.AreEqual(ExpectedCount, dynamicList.Count, "Count was incorrect. Expected " + ExpectedCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveAt_AddSeveralNegativeIndex_ExpectedArgumentoutOfRange()
        {
            AddFiveIntegers(dynamicList);
            dynamicList.RemoveAt(-3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveAt_AddSeveralIndexBiggerThanCount_ExpectedArgumentOutOfRangeException()
        {
            AddFiveIntegers(dynamicList);
            dynamicList.RemoveAt(10);
        }

        [TestMethod]
        public void TestRemoveAt_RemoveOneElement_ExpectedElementValue()
        {
            const int ExpectedValue = 6;

            AddFiveIntegers(dynamicList);
            int removedElement = dynamicList.RemoveAt(3);

            Assert.AreEqual(ExpectedValue, removedElement, "Removed element was incorrect. Expected " + ExpectedValue);
        }

        [TestMethod]
        public void TestRemoveAt_RemoveSeveralElements_ExpectedCorrespondingValues()
        {
            const int FirstExpectedValue = 1;
            const int SecondEpectedValue = 6;
            const int ThirdExpectedValue = 378;

            AddFiveIntegers(dynamicList);
            int firstRemoved = dynamicList.RemoveAt(0);
            int secondRemoved = dynamicList.RemoveAt(2);
            int thirdRemoved = dynamicList.RemoveAt(2);

            Assert.AreEqual(FirstExpectedValue, firstRemoved, "First element removed was incorrect. Expected " + FirstExpectedValue);
            Assert.AreEqual(SecondEpectedValue, secondRemoved, "Second element removed was incorrect. Expected " + SecondEpectedValue);
            Assert.AreEqual(ThirdExpectedValue, thirdRemoved, "Third element removed was incorect. Expected " + ThirdExpectedValue);
        }

        [TestMethod]
        public void TestRemove_RemoveNotContainedElement_ExpectedNegativeOne()
        {
            AddFiveIntegers(dynamicList);
            int indexOfRemovedElement = dynamicList.Remove(3);

            Assert.AreEqual(-1, indexOfRemovedElement, "Index of removed element is incorrect. Expected -1");
        }

        [TestMethod]
        public void TestRemove_RemoveOneElement_ExpectedIndexOfElement()
        {
            const int ExpectedIndex = 1;

            AddFiveIntegers(dynamicList);
            int indexOfRemovedElement = dynamicList.Remove(2);

            Assert.AreEqual(ExpectedIndex, indexOfRemovedElement, "Index of removed element was incorrect. Expected " + ExpectedIndex);
        }

        [TestMethod]
        public void TestRemove_RemoveSeveralElements_ExpectedCorrespondingIndexes()
        {
            const int FirstExpectedIndex = 0;
            const int SecondExpectedIndex = 0;
            const int ThirdExpectedIndex = 1;

            AddFiveIntegers(dynamicList);
            int firstIndex = dynamicList.Remove(1);
            int secondIndex = dynamicList.Remove(2);
            int thirdIndex = dynamicList.Remove(6);

            Assert.AreEqual(FirstExpectedIndex, firstIndex, "First index of removed element was incorrect. Expected " + FirstExpectedIndex);
            Assert.AreEqual(SecondExpectedIndex, secondIndex, "Second index of removed element was incorrect. Expected " + SecondExpectedIndex);
            Assert.AreEqual(ThirdExpectedIndex, thirdIndex, "Third index of removed element was incorrect. Expected " + ThirdExpectedIndex);
        }

        [TestMethod]
        public void TestIndexOf_NotContainedElement_ExpectedNegativeOne()
        {
            AddFiveIntegers(dynamicList);
            int index = dynamicList.IndexOf(5);

            Assert.AreEqual(-1, index, "Index was incorrect. Expected -1");
        }

        [TestMethod]
        public void TestIndexOf_OneElement_ExpectedCorrespondingIndex()
        {
            dynamicList.Add(100);
            int index = dynamicList.IndexOf(100);

            Assert.AreEqual(0, index, "Index was incorrect. Expected 0");
        }

        [TestMethod]
        public void TestIndexOf_SeveralElements_ExpectedCorrespondingIndexes()
        {
            const int FirstExpectedIndex = 3;
            const int SecondExpectedIndex = 4;

            AddFiveIntegers(dynamicList);
            int firstIndex = dynamicList.IndexOf(6);
            int secondIndex = dynamicList.IndexOf(378);
            // Element not contained in list
            int thirdIndex = dynamicList.IndexOf(1738);

            Assert.AreEqual(FirstExpectedIndex, firstIndex, "First index was incorrect. Expected " + FirstExpectedIndex);
            Assert.AreEqual(SecondExpectedIndex, secondIndex, "Second index was incorrect. Expected " + SecondExpectedIndex);
            Assert.AreEqual(-1, thirdIndex, "Third index was incorrect. Expected -1");
        }

        [TestMethod]
        public void TestContains_ContainedElement_ExpectedTrue()
        {
            AddFiveIntegers(dynamicList);
            bool contains = dynamicList.Contains(2);

            Assert.IsTrue(contains, "Element is contained in dynamic list");
        }

        [TestMethod]
        public void TestContains_NotContainedElement_ExpectedFalse()
        {
            AddFiveIntegers(dynamicList);
            bool contains = dynamicList.Contains(3);

            Assert.IsFalse(contains, "Element is not contained in dynamic list");
        }

        private DynamicList<int> AddFiveIntegers(DynamicList<int> list)
        {
            list.Add(1);
            list.Add(2);
            list.Add(-3);
            list.Add(6);
            list.Add(378);

            return list;
        }
    }
}
