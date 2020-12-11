using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tank_Battle.Object;

namespace Tank_Battle.UI
{
    public static class Render
    {
        readonly static int ConsoleWidth = 64; //Lines, not pixels
        readonly static int ConsoleHeight = 20; //Lines, not pixels
        public static void Initialize()
        {

            Console.WindowWidth = Math.Clamp(ConsoleWidth, 0, Console.LargestWindowWidth);
            Console.WindowHeight = Math.Clamp(ConsoleHeight, 0, Console.LargestWindowHeight);
            Console.BufferWidth = Math.Clamp(ConsoleWidth, 0, Console.LargestWindowWidth);
            Console.BufferHeight = Math.Clamp(ConsoleHeight, 0, Console.LargestWindowHeight);
            Console.WindowWidth = Math.Clamp(ConsoleWidth, 0, Console.LargestWindowWidth);
            Console.WindowHeight = Math.Clamp(ConsoleHeight, 0, Console.LargestWindowHeight);




            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
        }

        public static void Reset()
        {
            Console.Clear();
        }

        public static void DrawBorder(string Title)
        {
            Title = ' ' + Title.Trim() + ' ';
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

            if (Title.Length > 0)
            {
                int StartTextIndex = (Console.WindowWidth / 2) - (Title.Length / 2);
                Console.SetCursorPosition(StartTextIndex, 1);
                Console.Write(Title);

                Console.SetCursorPosition(StartTextIndex - 1, 0);
                Console.Write((char)ConsoleChar.WallThreewayDown);
                Console.SetCursorPosition(StartTextIndex - 1, 1);
                Console.Write((char)ConsoleChar.WallVertical);
                Console.SetCursorPosition(StartTextIndex - 1, 2);
                Console.Write((char)ConsoleChar.CornerBottomLeft);

                Console.SetCursorPosition(StartTextIndex + Title.Length, 0);
                Console.Write((char)ConsoleChar.WallThreewayDown);
                Console.SetCursorPosition(StartTextIndex + Title.Length, 1);
                Console.Write((char)ConsoleChar.WallVertical);
                Console.SetCursorPosition(StartTextIndex + Title.Length, 2);
                Console.Write((char)ConsoleChar.CornerBottomRight);

                for (int i = 0; i < Title.Length; i++)
                {
                    Console.SetCursorPosition(StartTextIndex + i, 2);
                    Console.Write((char)ConsoleChar.WallHorizontal);
                    Console.SetCursorPosition(StartTextIndex + i, 0);
                    Console.Write((char)ConsoleChar.WallHorizontal);
                }
            }

        }

        public static void DisplayMessage(string Message, bool Permanent = false)
        {
            if (Permanent)
            {
                Console.SetCursorPosition(0, Console.WindowHeight - 3);
                Console.Write((char)ConsoleChar.WallVerticalLeftThreeWay);
                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 3);
                Console.Write((char)ConsoleChar.WallVerticalRightThreeWay);
                for (int j = 1; j < Console.WindowWidth - 1; j++)
                {
                    Console.SetCursorPosition(j, Console.WindowHeight - 3);
                    Console.Write((char)ConsoleChar.WallHorizontal);
                }

                Console.SetCursorPosition((Console.WindowWidth / 2) - (Message.Length / 2), Console.WindowHeight - 2);
                Console.Write(Message);
            }
            else
            {
                ConsoleColor[] Colors = new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.DarkGray, ConsoleColor.Yellow };
                for (int i = 0; i < Colors.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(0, Console.WindowHeight - 3);
                    Console.Write((char)ConsoleChar.WallVerticalLeftThreeWay);
                    Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 3);
                    Console.Write((char)ConsoleChar.WallVerticalRightThreeWay);
                    for (int j = 1; j < Console.WindowWidth - 1; j++)
                    {
                        Console.SetCursorPosition(j, Console.WindowHeight - 3);
                        Console.Write((char)ConsoleChar.WallHorizontal);
                    }

                    Console.SetCursorPosition((Console.WindowWidth / 2) - (Message.Length / 2), Console.WindowHeight - 2);
                    Console.ForegroundColor = Colors[i];
                    Console.Write(Message);
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (i == 0)
                    {
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Thread.Sleep(250);
                    }
                }
            }
        }

        public static void DrawOptions(Option[] Options, Action<int> Callback)
        {
            while (Console.KeyAvailable) Console.ReadKey(true);
            int IndexX = 3; //Padding to not interfere with borders
            int IndexY = 11; //Padding to not interfere with borders and avoid tanks
            int MaxIndexX = Console.WindowWidth - 2;
            int MaxIndexY = Console.WindowHeight - 3;

            int Padding = 2;
            foreach (var Option in Options)
            {
                int PositionX = Math.Clamp(Option.X, IndexX, MaxIndexX);
                int PositionY = Math.Clamp(Option.Y, IndexY, MaxIndexY);
                Option.SetRealPosition(PositionX, PositionY);

                Console.SetCursorPosition(PositionX, PositionY);
                if (Options[0] == Option)
                {
                    Console.Write("> " + Option.Title);
                }
                else
                {
                    Console.Write(Option.Title);
                }


                IndexY += Padding; // Space out options
            }

            int SelectedIndex = 0;
            if (Options.Length > 0)
            {
                while (Console.KeyAvailable) Console.ReadKey(true);
                while (true)
                {
                    var key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter) break;
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (SelectedIndex > 0)
                        {
                            SelectedIndex--;
                            foreach (var Option in Options)
                            {
                                Console.SetCursorPosition(1, Option.RealPositionY);
                                Console.Write(new string(' ', Console.WindowWidth - 2));
                                Console.SetCursorPosition(Option.RealPositionX, Option.RealPositionY);
                                if (Options[SelectedIndex] == Option)
                                {
                                    Console.Write("> " + Option.Title);
                                }
                                else
                                {
                                    Console.Write(Option.Title);
                                }
                            }
                        }
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (SelectedIndex < Options.Length - 1)
                        {
                            SelectedIndex++;
                            foreach (var Option in Options)
                            {
                                Console.SetCursorPosition(1, Option.RealPositionY);
                                Console.Write(new string(' ', Console.WindowWidth - 2));
                                Console.SetCursorPosition(Option.RealPositionX, Option.RealPositionY);
                                if (Options[SelectedIndex] == Option)
                                {
                                    Console.Write("> " + Option.Title);
                                }
                                else
                                {
                                    Console.Write(Option.Title);
                                }
                            }
                        }
                    }
                }
                Callback(SelectedIndex);
            }
        }

        public static void DrawTank(TankFacingDirection Direction, Tank Tank)
        {
            int YLevel = 5;
            int YLevelTank = 5;
            int XLevel = (Direction == TankFacingDirection.EAST) ? 3 : ConsoleWidth - 18; //Align Tank '3' from edge
            int XHealthLevel = (Direction == TankFacingDirection.EAST) ? 3 : ConsoleWidth - 15;
            int XTextLevel = (Direction == TankFacingDirection.EAST) ? 3 : ConsoleWidth - 3 - (Tank.Driver.Name.Length);


            string[] TankStringArray = GetTank(Direction);
            if (Tank.Health == 0)
            {
                TankStringArray = GetDestroyedTank();
                YLevelTank = YLevelTank - 1;
                XLevel = (Direction == TankFacingDirection.EAST) ? 1 : ConsoleWidth - 19;
            }

            Console.SetCursorPosition(XTextLevel, YLevel - 2);
            Console.Write(Tank.Driver.Name);

            string tankText = "[" + new string('=', Tank.Health) + new string(' ', Tank.MaxHealth - Tank.Health) + "]";
            Console.SetCursorPosition(XHealthLevel, YLevel - 1);
            Console.Write(tankText);

            Console.SetCursorPosition(XLevel, YLevelTank);
            foreach (string TankPart in TankStringArray)
            {
                Console.CursorLeft = XLevel;
                Console.Write(TankPart);
                Console.CursorTop++;
            }
        }

        public static void RenderTanks(Tank AllyTank, Tank EnemyTank)
        {
            Render.DrawTank(TankFacingDirection.EAST, AllyTank);
            Render.DrawTank(TankFacingDirection.WEST, EnemyTank);
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

        private static string[] GetDestroyedTank()
        {
            return new string[]
               {
                    " ,;,'.`,''.`.':.",
                    ".'.` ; ;. `'` .``.",
                    " ':,`:`.`:~..`.;'",
                    "      :.:.|",
                    "    `-|___:-'",
                    "     _:..:|_",
                    "__.=~'=___=`~=.__"
               };
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

