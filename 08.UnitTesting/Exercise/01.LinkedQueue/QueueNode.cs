﻿namespace _01.LinkedQueue
{
    public class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public QueueNode<T> NextNode { get; set; }
    }
}
