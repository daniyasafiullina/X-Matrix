using System.Globalization;
using System.Threading;

namespace Matrix
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("X matrix");

            Menu menu = new Menu();
            menu.Run();
        }
    }
}

