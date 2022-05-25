using System.Text;

namespace CodingExerciseCreditXpert.LangtonsAnt
{
    internal class AntMap
    {
        public int max_x_size = 25;
        public int max_y_size = 25;

        // This choice of a data structure was supposed to be for resizing but I ran out of time.
        IDictionary<int, IList<Node>> map = new Dictionary<int, IList<Node>>();

        public AntMap()
        {
            BuildMap();
        }

        public AntMap(int x, int y)
        {
            max_x_size = x;
            max_y_size = y;
            BuildMap();
        }

        /// <summary>
        /// Move an ant and keep state of the nodes.
        /// Ant is a parameter as a means to test indexes for map growth. not implemented
        /// </summary>
        /// <param name="ant"></param>
        /// <returns></returns>
        public Node MoveAnt(Ant ant)
        {
            Node initial_node = map[ant.y][ant.x];
            ant.Move();

            /**
             * if( !inMap(ant.x, ant.y) {
             *  GrowMap()
             */
            Node next_node = map[ant.y][ant.x];
            initial_node.has_ant = false;
            next_node.has_ant = true;

            return next_node;
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int row in map.Keys)
            {
                foreach (Node node in map[row])
                {
                    sb.Append(node);
                }

                sb.Append('\n');
            }

            return sb.ToString();
        }

        public Node GetNode(int x, int y)
        {
            try
            {
                return map[y][x];
            }
            catch (Exception)
            {
                throw new NotImplementedException("Map resizing is not complete");
            }
        }

        private void BuildMap()
        {
            for (int i = 0; i < max_y_size; ++i)
            {
                map.Add(i, BuildList());
            }
        }

        private IList<Node> BuildList()
        {
            IList<Node> return_list = new List<Node>();

            for (int i = 0; i < max_x_size; ++i)
            {
                return_list.Add(new Node());
            }
            return return_list;
        }

        /// <summary>
        /// Sorry started late so I ran out of time. This would have resized the map
        /// </summary>
        private void GrowMap()
        {
            throw new NotImplementedException("Map resizing is not complete");
        }
    }
}
