using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02_01
{
    public class Program
    {
        public static void Main()
        {
            BoardUI game = new BoardUI();
            game.StartGame();
            Console.ReadLine();
        }
    }
}
