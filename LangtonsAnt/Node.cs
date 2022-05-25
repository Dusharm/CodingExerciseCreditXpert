namespace CodingExerciseCreditXpert.LangtonsAnt
{
    /// <summary>
    /// Simple node structure for Langton's ant
    /// </summary>
    internal class Node
    {
        // Color is enum in case of other behaviors
        public Color color { get; set; }
        
        // keep track of ant state
        public Boolean has_ant { get; set; }

        public Node()
        {
            color = Color.WHITE;
            has_ant = false;
        }

        /// <summary>
        /// Swap the color of the node based on behavior. Right now this only supports
        /// the behavior from the original test case
        /// </summary>
        public void swapColor()
        {
            switch (color)
            {
                case Color.WHITE:
                    color = Color.BLACK;
                    break;
                case Color.BLACK:
                    color = Color.WHITE;
                    break;
                default:
                    break;
            }
        }

        public override String ToString()
        {
            if (has_ant)
            {
                return " [ 8 ] ";
            }
            switch (color)
            {
                case Color.WHITE:
                    return " [   ] ";
                default:
                    return " [ X ] ";
            }
        }
    }
}
