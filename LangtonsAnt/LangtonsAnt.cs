namespace CodingExerciseCreditXpert.LangtonsAnt
{
    /// <summary>
    /// This seemed like a fun one so I wanted to give it a shot.
    /// Unfortunately I did not get to the "infinite space" portion of the problem yet
    /// the goal was to resize the map if the ant tried to move out of it (hence the data structure)
    /// </summary>
    internal class LangtonsAnt
    {
        AntMap map;
        Ant ant;
        public LangtonsAnt()
        {
            map = new AntMap();
            ant = new Ant();
            setupGame();
        }

        /// <summary>
        /// Creates Langton's Ant using provided map
        /// inputs
        /// </summary>
        /// <param name="max_x"></param>
        /// <param name="max_y"></param>
        public LangtonsAnt(int max_x, int max_y)
        {
            map = new AntMap(max_x, max_y);
            ant = new Ant();
            setupGame();
        }

        /// <summary>
        /// Main hook into the program
        /// </summary>
        /// <param name="k"></param>
        public void Ant(int k)
        {
            for (int i = 0; i < k; ++i)
            {
                moveAnt();
            }
            Console.WriteLine(map.ToString());
        }

        private void setupGame()
        {

            // Center Ant
            ant.x = map.max_x_size / 2;
            ant.y = map.max_x_size / 2;

            map.GetNode(ant.x, ant.y).has_ant = true;
        }

        private void moveAnt()
        {
            Node curr_node = map.GetNode(ant.x, ant.y);

            //Swap current color
            curr_node.swapColor();

            //Turn before moving forward
            if (curr_node.color == Color.WHITE)
            {
                ant.TurnRight();
            }
            else
            {
                ant.TurnLeft();
            }

            // Map probably doesn't need to know about the Ant here.
            // I did this initially to prepare for resizing the map.
            map.MoveAnt(ant);
        }
    }
}
