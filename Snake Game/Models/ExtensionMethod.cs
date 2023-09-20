using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Snake_Game.Models.ForUsers;

namespace Snake_Game.Models
{
    internal static class ExtensionMethod
	{
		public static void CursorMoveForMenu(int max_x = 0, int min_x = 0, int max_y = 0, int min_y = 0)
		{
			CursorPosition.Min_Y = min_y;
			CursorPosition.Max_Y = max_y;
			CursorPosition.Min_X = min_x;
			CursorPosition.Max_X = max_x;
			Console.SetCursorPosition(min_x, min_y);
			Console.Write("-->>", Console.ForegroundColor = ConsoleColor.Cyan);

			while (true)
			{
				ConsoleKey consoleKey = Console.ReadKey(true).Key;


				if (consoleKey == ConsoleKey.UpArrow)
				{
					CursorPosition.MoveToUp();
					Console.Write("-->>", Console.ForegroundColor = ConsoleColor.Cyan);
				}

				else if (consoleKey == ConsoleKey.DownArrow)
				{
					CursorPosition.MoveToDown();
					Console.Write("-->>", Console.ForegroundColor = ConsoleColor.Cyan);
				}

				else if (consoleKey == ConsoleKey.LeftArrow)
				{
					CursorPosition.MoveToLeft();
					Console.Write("-->>", Console.ForegroundColor = ConsoleColor.Cyan);
				}

				else if (consoleKey == ConsoleKey.RightArrow)
				{
					CursorPosition.MoveToRight();
					Console.Write("-->>", Console.ForegroundColor = ConsoleColor.Cyan);
				}

				else if (consoleKey == ConsoleKey.Escape)
					Environment.Exit(0);

				else if (consoleKey == ConsoleKey.Enter)
					break;

				

			}
		}

		public static void Wait(int second)
		{
			Thread.Sleep(second);
			while (Console.KeyAvailable) // This is waiting for the sleep time to end.and it does not save the keys or print them on the screen.
			{
				Console.ReadKey(true);
			}
		}

	}
}
