namespace _03.Minesweeper
{
    using System;

    public class LeaderBoardRanking
    {
        private string name;
        private int points;

        public LeaderBoardRanking(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name", "Name cannot be empty or null!");
                }

                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Points", "Points cannot be negative!");
                }

                this.points = value;
            }
        }
    }
}
