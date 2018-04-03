using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            screen screen = new screen(600, 500);
            screen.Title = "Renderin";
            screen.Run();

        }
    }
}
