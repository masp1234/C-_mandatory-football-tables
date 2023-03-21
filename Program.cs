using FootBall.File;

namespace Football_tables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileHandler fileHandler = new FileHandler();
            fileHandler.readFile();
        }
    }

}