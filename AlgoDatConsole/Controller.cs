

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
            catch (KeyNotFoundException e)
            {
                return Control.Unknown;
            }
        }

        public string GetControls()
        {
            return _keymap.Aggregate("", (current, kvp) 
                => current + $"{kvp.Key} is assigned to {kvp.Value}\n");
        }
    }
}