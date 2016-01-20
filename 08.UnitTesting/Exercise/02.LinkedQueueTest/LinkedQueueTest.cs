namespace _02.LinkedQueueTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using _01.LinkedQueue;

    [TestClass]
    public class LinkedQueueTest
    {
        private LinkedQueue<int> queue;

        [TestInitialize]
        public void SetUp()
        {
            this.queue = new LinkedQueue<int>();
        }

        [TestMethod]
        public void TestDequeue_EnqueueOne_ExpectedElement()
        {
            this.queue.Enqueue(10);
            var element = this.queue.Dequeue();

            Assert.AreEqual(10, element, "Dequeued element was wrong. Expected 10");
        }

        [TestMethod]
        public void TestDequeue_EnqueueSeveral_ReturnInOrder()
        {
            queue.Enqueue(10);
            queue.Enqueue(1);
            queue.Enqueue(241);

            var firstElement = queue.Dequeue();
            var secondElement = queue.Dequeue();
            var thirdElement = queue.Dequeue();

            Assert.AreEqual(10, firstElement, "First dequeued element was wrong. Expected 10");
            Assert.AreEqual(1, secondElement, "Second dequeued element was wrong. Expected 1");
            Assert.AreEqual(241, thirdElement, "Third dequeued element was wrong. Expected 241");
        }

        [TestMethod]
        public void TestCount_EnqueueSeveral_CountSeveral()
        {
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.AreEqual(2, queue.Count, "Count was wrong. Expected 2");
        }

        [TestMethod]
        public void TestCount_EnqueueSeveralDequeue_CountRemaining()
        {
            queue.Enqueue(1341);
            queue.Enqueue(415);
            queue.Enqueue(1);

            queue.Dequeue();

            Assert.AreEqual(2, queue.Count, "Count was wrong. Expected 2");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDequeue_DequeueEmpty_ExpectedInvalidOperationException()
        {
            queue.Dequeue();
        }
    }
}
