using System;
using System.Collections.Generic;
using System.Text;
using Tank_Battle.Object;

namespace Tank_Battle.UI
{
    public static class Render
    {
        readonly static int consoleWidth = 64; //Lines, not pixels
        readonly static int consoleHeight = 32; //Lines, not pixels
        public static void Initialize()
        {
            
            Console.WindowWidth = Math.Clamp(consoleWidth, 0, Console.LargestWindowWidth);
            Console.WindowHeight = Math.Clamp(consoleHeight, 0, Console.LargestWindowHeight);
            Console.BufferWidth = Math.Clamp(consoleWidth, 0, Console.LargestWindowWidth);
            Console.BufferHeight = Math.Clamp(consoleHeight, 0, Console.LargestWindowHeight);
            Console.WindowWidth = Math.Clamp(consoleWidth, 0, Console.LargestWindowWidth);
            Console.WindowHeight = Math.Clamp(consoleHeight, 0, Console.LargestWindowHeight);




            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public static void Reset()
        {
            Console.Clear();
        }

        public static void DrawBorder(string title = "", string subtitle = "")
        {
            title = ' ' + title.Trim() + ' ';
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write((char)ConsoleChar.WallHorizontal);
                Console.SetCursorPosition(i, Console.WindowHeight - 1);
                Console.Write((char)ConsoleChar.WallHorizontal);
            }

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write((char)ConsoleChar.WallVertical);
                Console.SetCursorPosition(Console.WindowWidth - 1, i);
                Console.Write((char)ConsoleChar.WallVertical);
            }

            Console.SetCursorPosition(0, 0);
            Console.Write((char)ConsoleChar.CornerTopLeft);
            Console.SetCursorPosition(Console.WindowWidth - 1, 0);
            Console.Write((char)ConsoleChar.CornerTopRight);
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write((char)ConsoleChar.CornerBottomLeft);
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
            Console.Write((char)ConsoleChar.CornerBottomRight);

            if (title.Length > 0)
            {
                int startTextIndex = (Console.WindowWidth / 2) - (title.Length / 2);
                Console.SetCursorPosition(startTextIndex, 1);
                Console.Write(title);

                Console.SetCursorPosition(startTextIndex - 1, 0);
                Console.Write((char)ConsoleChar.WallThreewayDown);
                Console.SetCursorPosition(startTextIndex - 1, 1);
                Console.Write((char)ConsoleChar.WallVertical);
                Console.SetCursorPosition(startTextIndex - 1, 2);
                Console.Write((char)ConsoleChar.CornerBottomLeft);

                Console.SetCursorPosition(startTextIndex + title.Length, 0);
                Console.Write((char)ConsoleChar.WallThreewayDown);
                Console.SetCursorPosition(startTextIndex + title.Length, 1);
                Console.Write((char)ConsoleChar.WallVertical);
                Console.SetCursorPosition(startTextIndex + title.Length, 2);
                Console.Write((char)ConsoleChar.CornerBottomRight);

                for (int i = 0; i < title.Length; i++)
                {
                    Console.SetCursorPosition(startTextIndex + i, 2);
                    Console.Write((char)ConsoleChar.WallHorizontal);
                    Console.SetCursorPosition(startTextIndex + i, 0);
                    Console.Write((char)ConsoleChar.WallHorizontal);
                }
            }

            if (subtitle.Length > 0)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 3);
                Console.Write((char)ConsoleChar.WallVerticalLeftThreeWay);
                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 3);
                Console.Write((char)ConsoleChar.WallVerticalRightThreeWay);
                for (int i = 1; i < Console.WindowWidth - 1; i++)
                {
                    Console.SetCursorPosition(i, Console.WindowHeight - 3);
                    Console.Write((char)ConsoleChar.WallHorizontal);
                }

                Console.SetCursorPosition((Console.WindowWidth / 2) - (subtitle.Length / 2), Console.WindowHeight - 2);
                Console.Write(subtitle);
            }
        }

        public static void DrawOptions(Option[] options, Action<int> callback)
        {
            while (Console.KeyAvailable) Console.ReadKey(true);
            int indexX = 3; //Padding to not interfere with borders
            int indexY = 15; //Padding to not interfere with borders and avoid tanks
            int maxIndexX = Console.WindowWidth - 2;
            int maxIndexY = Console.WindowHeight - 5;

            int padding = 2;
            foreach (var option in options)
            {
                int positionX = Math.Clamp(option.x, indexX, maxIndexX);
                int positionY = Math.Clamp(option.y, indexY, maxIndexY);
                option.SetRealPosition(positionX, positionY);

                Console.SetCursorPosition(positionX, positionY);
                if (options[0] == option)
                {
                    Console.Write("> " + option.title);
                }
                else
                {
                    Console.Write(option.title);
                }


                indexY += padding; // Space out options
            }

            int selectedIndex = 0;
            if (options.Length > 0)
            {
                while (Console.KeyAvailable) Console.ReadKey(true);
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter) break;
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (selectedIndex > 0)
                        {
                            selectedIndex--;
                            foreach (var option in options)
                            {
                                Console.SetCursorPosition(1, option.realPositionY);
                                Console.Write(new string(' ', Console.WindowWidth - 2));
                                Console.SetCursorPosition(option.realPositionX, option.realPositionY);
                                if (options[selectedIndex] == option)
                                {
                                    Console.Write("> " + option.title);
                                }
                                else
                                {
                                    Console.Write(option.title);
                                }
                            }
                        }
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (selectedIndex < options.Length - 1)
                        {
                            selectedIndex++;
                            foreach (var option in options)
                            {
                                Console.SetCursorPosition(1, option.realPositionY);
                                Console.Write(new string(' ', Console.WindowWidth - 2));
                                Console.SetCursorPosition(option.realPositionX, option.realPositionY);
                                if (options[selectedIndex] == option)
                                {
                                    Console.Write("> " + option.title);
                                }
                                else
                                {
                                    Console.Write(option.title);
                                }
                            }
                        }
                    }
                }
                callback(selectedIndex);
            }
        }

        public static void DrawTank(TankFacingDirection direction, Tank tank)
        {
            int yLevel = 5;
            int xLevel = (direction == TankFacingDirection.EAST) ? 3 : consoleWidth - 18; //Align Tank '3' from edge


            string[] tankStringArray = GetTank(direction);
            Console.SetCursorPosition(xLevel, yLevel);
            foreach (string tankPart in tankStringArray)
            {
                Console.CursorLeft = xLevel;
                Console.Write(tankPart);
                Console.CursorTop++;
            }
        }

        private static string[] GetTank(TankFacingDirection direction)
        {
            if (direction == TankFacingDirection.EAST)
            {
                return new string[] {
                    "    ___",
                    " __(   )====::",
                    "/~~~~~~~~~\\",
                    "\\O.O.O.O.O/"
                };
            }
            else
            {
                return new string[] {
                    "       ___",
                    "::====(   )__",
                    "   /~~~~~~~~~\\",
                    "   \\O.O.O.O.O/"
                };
            }
        }
    }

}

enum ConsoleChar
{
    CornerTopLeft = '╔',
    CornerTopRight = '╗',
    CornerBottomRight = '╝',
    CornerBottomLeft = '╚',
    WallHorizontal = '═',
    WallVertical = '║',
    WallVerticalRightThreeWay = '╣',
    WallVerticalLeftThreeWay = '╠',
    WallThreewayDown = '╦'
}

public enum TankFacingDirection
{
    WEST,
    EAST
}

