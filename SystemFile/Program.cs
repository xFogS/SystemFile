namespace SystemFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "System Verse";
            AppVerse appVerse = new();
            appVerse.Menu();
        }
    }
}
