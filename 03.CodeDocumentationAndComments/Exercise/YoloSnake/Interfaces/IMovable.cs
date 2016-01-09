namespace YoloSnake.Interfaces
{
    using Enums;

    public interface IMovable
    {
        /// <summary>
        /// Gets the movable object's direction.
        /// </summary>
        Direction Direction { get; }

        /// <summary>
        /// Moves the specified object.
        /// </summary>
        void Move();

        /// <summary>
        /// Changes a movable object's direction to another direction.
        /// </summary>
        /// <param name="newDirection"></param>
        void ChangeDirection(Direction newDirection);
    }
}