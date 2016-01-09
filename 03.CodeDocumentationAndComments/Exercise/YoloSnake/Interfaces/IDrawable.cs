namespace YoloSnake.Interfaces
{
    public interface IDrawable
    {
        /// <summary>
        /// Draws an object using a specific drawer.
        /// </summary>
        /// <param name="drawer"></param>
        void Draw(IDrawer drawer);
    }
}