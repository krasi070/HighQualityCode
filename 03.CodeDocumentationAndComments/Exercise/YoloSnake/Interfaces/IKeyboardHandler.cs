namespace YoloSnake.Interfaces
{
    using System;

    public interface IKeyboardHandler
    {
        /// <summary>
        /// Gets the pressed key.
        /// </summary>
        ConsoleKey PressedKey { get; }

        /// <summary>
        /// Gets a value that shows if the key is available in the current input stream.
        /// </summary>
        bool IsKeyAvailable { get; }
    }
}