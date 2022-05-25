namespace CodingExerciseCreditXpert
{
    /// <summary>
    /// Daniel Dusharm
    /// Coding Exercise for CreditXpert
    /// Phone: (609)481-9840
    /// Email: djdusharm@outlook.com
    /// 
    /// While I realize this submission has little of either, I try to be weary of overusing inheritance
    /// and tend to favor composition.
    /// 
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            LangtonsAnt();
            WordTransform();
        }


        static void LangtonsAnt()
        {
            LangtonsAnt.LangtonsAnt ant = new LangtonsAnt.LangtonsAnt(30, 30);
            ant.Ant(1200);
        }

        static void WordTransform()
        {
            ISet<String> dictionary = new HashSet<String>();

            dictionary.Add("damp");
            dictionary.Add("like");
            dictionary.Add("lime");
            dictionary.Add("limp");
            dictionary.Add("lamp");

            WordTransformer.WordTransformer word = new WordTransformer.WordTransformer(dictionary);
            Console.WriteLine(word.Transform("damp", "like"));
        }
    }
}