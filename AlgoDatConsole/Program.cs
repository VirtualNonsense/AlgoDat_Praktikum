using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDatConsole
{
    static class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode; 
            Dictionary<ConsoleKey, Control> _keymap = null;
            Controller controller = _keymap == null? new Controller() : new Controller(_keymap);
            Demonstrator demonstrator = new Demonstrator(controller);
            demonstrator.Start();
        }
    }
}