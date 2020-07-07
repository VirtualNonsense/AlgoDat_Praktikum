

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoDatConsole
{
    public enum Control
    {
        Up,
        Down,
        Enter,
        Escape,
        Unknown
    }
    

    public class Controller
    {
        private readonly Dictionary<ConsoleKey, Control> _keymap;

        public Controller(Dictionary<ConsoleKey, Control> keymap)
        {
            _keymap = keymap;
        }

        public Controller()
        {
            _keymap = new Dictionary<ConsoleKey, Control>()
            {
                {ConsoleKey.UpArrow, Control.Up},
                {ConsoleKey.DownArrow, Control.Down},
                {ConsoleKey.Enter, Control.Enter},
                {ConsoleKey.Backspace, Control.Escape},
                {ConsoleKey.Escape, Control.Escape}
            };
        }
        
        public Control AwaitInput()
        {
            try
            {
                return _keymap[Console.ReadKey().Key];
            }
            catch (KeyNotFoundException)
            {
                return Control.Unknown;
            }
        }

        public int? AwaitIntInput()
        {
            int input;
            string tmp;
            do
            {
                
                tmp = Console.ReadLine() ?? "";
                if (tmp == "")
                    return null;
                try
                {
                    input = int.Parse(tmp);
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input, please enter a valid integer or hit" +
                                      " enter on an empty field to have more options");
                }
            } while (true);

            return input;
        }

        public ConsoleKey? GetKey(Control control)
        {
            foreach (KeyValuePair<ConsoleKey,Control> keyValuePair in _keymap)
            {
                if (control == keyValuePair.Value)
                    return keyValuePair.Key;
            }

            return null;
        }

        public string GetControls()
        {
            return _keymap.Aggregate("", (current, kvp) 
                => current + $"{kvp.Key} is assigned to {kvp.Value}\n");
        }
    }
}