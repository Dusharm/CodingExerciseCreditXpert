namespace CodingExerciseCreditXpert.LangtonsAnt
{
    /// <summary>
    /// Ant starts off oriented to the RIGHT
    /// </summary>
    internal class Ant
    {
        Direction direction = Direction.RIGHT;
        public int x { get; set; }
        public int y { get; set; }


        /// <summary>
        /// Move the ant's position values based on direction
        /// </summary>
        public void Move()
        {
            switch (direction)
            {
                case Direction.UP:
                    y++;
                    break;
                case Direction.DOWN:
                    y--;
                    break;
                case Direction.LEFT:
                    x--;
                    break;
                case Direction.RIGHT:
                    x++;
                    break;
            }
        }

        /// <summary>
        /// Verbose functionality for turning
        /// </summary>
        public void TurnLeft()
        {
            switch (direction)
            {
                case Direction.UP:
                    direction = Direction.LEFT;
                    break;
                case Direction.DOWN:
                    direction = Direction.RIGHT;
                    break;
                case Direction.LEFT:
                    direction = Direction.DOWN;
                    break;
                case Direction.RIGHT:
                    direction = Direction.UP;
                    break;
            }
        }

        /// <summary>
        /// Verbose functionality for turning
        /// </summary>
        public void TurnRight()
        {
            switch (direction)
            {
                case Direction.UP:
                    direction = Direction.RIGHT;
                    break;
                case Direction.DOWN:
                    direction = Direction.LEFT;
                    break;
                case Direction.LEFT:
                    direction = Direction.UP;
                    break;
                case Direction.RIGHT:
                    direction = Direction.DOWN;
                    break;
            }
        }
    }
}
