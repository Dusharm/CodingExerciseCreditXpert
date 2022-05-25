using System.Text;

namespace CodingExerciseCreditXpert.WordTransformer
{
    /// <summary>
    /// Given two words of equal length that are in a dictionary, write a C# program to transform 
    /// one word into another word by changing only one letter at a time. The new word in each step 
    /// must be in the dictionary
    /// 
    /// ---
    /// 
    /// Since this is finding a path between words in the dictionary this is a search problem. 
    /// I attempted this using BFS utilizing queues
    /// 
    /// </summary>
    internal class WordTransformer
    {
        /// <summary>
        /// Set of words for traversal
        /// </summary>
        private ISet<String> dictionary;

        /// <summary>
        /// Initailize WordTransformer with dictionary
        /// </summary>
        /// <param name="dictionary">List of words to traverse. This will be modified in most cases</param>
        public WordTransformer(ISet<String> dictionary)
        {
            this.dictionary = dictionary;
        }

        /// <summary>
        /// Hook into the word search program
        /// Assumes both inputs are in dictionary
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>String of shortest path between start and end in dictionary</returns>
        public String Transform(String start, String end)
        {
            // Check inputs
            if (!(dictionary.Contains(start) && dictionary.Contains(end)))
            {
                return "Inputs are not in dictionary";
            }

            if (start.Length != end.Length)
            {
                return "Words are not of the same length";
            }

            if (start.Equals(end))
            {
                return start;
            }

            StringBuilder output_string = new StringBuilder();
            Queue<String> queue = new Queue<String>();
            ISet<String> visited = new HashSet<String>();


            // initialize output
            output_string.Append(start);
            dictionary.Remove(start);

            queue.Enqueue(start);
            visited.Add(start);

            // BFS
            while (queue.Count != 0)
            {
                // Next queue once first is handled
                var next_queue = new Queue<String>();
                foreach (var word in queue)
                {
                    if (AreConnected(end, word))
                    {
                        output_string.Append(" -> " + end);
                        return output_string.ToString();
                    }

                    //Trade off between size of dictionary, or length of words
                    // A different approach could be to cycle each character position to check
                    // if it's in the dictionary
                    foreach (String dict_word in dictionary)
                    {
                        // If the word isn't off by one character, ignore it
                        if (!AreConnected(word, dict_word))
                        {
                            continue;
                        }

                        // we found a connected word in the dictionary so we're going to take it
                        next_queue.Enqueue(dict_word);
                        // reduce cycles by removing dictionary
                        dictionary.Remove(dict_word);
                    }
                }
                // If we don't have any where else to go we exit
                if (next_queue.Count == 0) break;

                // replace working queue
                queue = next_queue;

                // output handling
                String confirmed_word = queue.Last();

                if (!visited.Contains(confirmed_word))
                {
                    output_string.Append(" -> " + queue.Last());
                    visited.Add(confirmed_word);
                }
            }

            // if we get this far we didn't find a path
            return "There are no paths between words";
        }

        /// <summary>
        /// Checks if words connected
        /// Assumes str1 and str2 are the same length
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns>True if str1 and str2 differ by one character</returns>
        private static bool AreConnected(String str1, String str2)
        {
            int diff_counter = 0;

            for (int i = 0; i < str1.Length; ++i)
            {
                if (str1[i] != str2[i])
                {
                    diff_counter++;
                }
            }
            return diff_counter == 1;
        }
    }
}
