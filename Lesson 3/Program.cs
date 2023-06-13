using System;
using System.Linq;
using System.Threading;
using System.Timers;


namespace Lesson_3
{
	internal class Program
	{
		static void Main(string[] args)
		{

			int cursorTopPosition;
			Console.CursorVisible = false; // cursor -> hidden 
		Menu:
			#region Menu
			Console.Clear();
			Console.ResetColor();
			Console.WriteLine("\n		Play");
			Console.WriteLine("		About the game");
			Console.WriteLine("		Exit");



			cursorTopPosition = CursorMove();

			#endregion
		
			#region Game
			if (cursorTopPosition == 1)
			{
				Random random = new Random();

				string[,] Questions = new string[11, 4]
				{
				{"What is the largest continent in the world?", "Asia", "Europe" , "Africa" },
				{"Which is the longest river in the world?", "Nile River" , "Amazon River" , "Mississippi River" },
				{"What is the highest mountain in Africa?",  "Kilimanjaro", "Mount Everest" , "Mount McKinley" },
				{"Which country is known as the \"Land of the Rising Sun\"?", "Japan" ,"China" , "Australia" },
				{"What is the largest ocean on Earth?", "Pacific Ocean" , "Atlantic Ocean" , "Indian Ocean" },
				{"Which city is located on two continents?", "Istanbul" , "Rome" , "Moscow" },
				{"Which country is known as the \"Land Down Under\"?", "Australia" , "New Zealand" , "Brazil" },
				{"What is the capital of Canada?", "Ottawa" , "Toronto" , "Vancouver" },
				{"Which desert is the largest in the world?", "Sahara Desert" , "Gobi Desert" , "Arabian Desert" },
				{"What is the largest lake in Africa?", "Lake Victoria" , "Lake Tanganyika" , "Lake Malawi" },
				{"What is the capital of Azerbaijan", "Baku", "Gence", "Khacmaz" }

				};  //List easier than array :)

				int[] selectedQuestionsIndex = new int[0];

				int randomQuestionIndex;
				int randomAnswerIndexC;
				int randomAnswerIndexB;
				int randomAnswerIndexA;
				int count = 0;
				int totalRow = Questions.GetLength(1);
				int totalColumn = Questions.GetLength(0);
				int userScore = 0;


				#region Identifying questions and answers

				do
				{
					while (Console.KeyAvailable) // This is waiting for the sleep time to end.and it does not save the keys or print them on the screen.
					{
						Console.ReadKey(true);
					}

					randomAnswerIndexA = random.Next(1, totalRow);

					do
					{
						randomQuestionIndex = random.Next(0, totalColumn);
					} while (selectedQuestionsIndex.Contains(randomQuestionIndex));

					do
					{
						randomAnswerIndexB = random.Next(1, totalRow);
					} while (randomAnswerIndexB == randomAnswerIndexA);

					do
					{
						randomAnswerIndexC = random.Next(1, totalRow);
					} while (randomAnswerIndexC == randomAnswerIndexA || randomAnswerIndexC == randomAnswerIndexB);

					AddElementInArray(ref selectedQuestionsIndex, randomQuestionIndex);


					Console.WriteLine($" {++count}. {Questions[randomQuestionIndex, 0]}", Console.ForegroundColor = ConsoleColor.DarkYellow);
					Console.WriteLine($"	a) {Questions[randomQuestionIndex, randomAnswerIndexA]}", Console.ForegroundColor = ConsoleColor.Blue);
					Console.WriteLine($"	b) {Questions[randomQuestionIndex, randomAnswerIndexB]}", Console.ForegroundColor = ConsoleColor.DarkRed);
					Console.WriteLine($"	c) {Questions[randomQuestionIndex, randomAnswerIndexC]}", Console.ForegroundColor = ConsoleColor.DarkGreen);

					#endregion

					Console.SetCursorPosition(110, 0);
					Console.WriteLine($"Score: {userScore}");



					cursorTopPosition = CursorMove();
					#region check

					if ((cursorTopPosition == 1 && randomAnswerIndexA == 1) || (cursorTopPosition == 2 && randomAnswerIndexB == 1) || (cursorTopPosition == 3 && randomAnswerIndexC == 1))
					{
						Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
						Console.WriteLine("Congratulations, your answer is correct!", Console.ForegroundColor = ConsoleColor.Green);
						userScore += 10;
					}
					else
					{
						Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
						Console.WriteLine("Opps   :/", Console.ForegroundColor = ConsoleColor.Red);
						userScore = (userScore == 0) ? 0 : userScore - 10;
					}



					Thread.Sleep(700);
					Console.ResetColor();
					Console.Clear();





				} while (count < 10); //Identifying questions and answers
				#endregion

				Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
				Console.WriteLine($"The End :/			Your Score: {userScore}", Console.ForegroundColor = ConsoleColor.Red);
				Thread.Sleep(1000);
				Console.ResetColor();
				Console.Clear();
			}

			#endregion

			#region Info
			else if (cursorTopPosition == 2)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("\r\n .----------------.  .-----------------. .----------------.  .----------------. \r\n| .--------------. || .--------------. || .--------------. || .--------------. |\r\n| |     _____    | || | ____  _____  | || |  _________   | || |     ____     | |\r\n| |    |_   _|   | || ||_   \\|_   _| | || | |_   ___  |  | || |   .'    `.   | |\r\n| |      | |     | || |  |   \\ | |   | || |   | |_  \\_|  | || |  /  .--.  \\  | |\r\n| |      | |     | || |  | |\\ \\| |   | || |   |  _|      | || |  | |    | |  | |\r\n| |     _| |_    | || | _| |_\\   |_  | || |  _| |_       | || |  \\  `--'  /  | |\r\n| |    |_____|   | || ||_____|\\____| | || | |_____|      | || |   `.____.'   | |\r\n| |              | || |              | || |              | || |              | |\r\n| '--------------' || '--------------' || '--------------' || '--------------' |\r\n '----------------'  '----------------'  '----------------'  '----------------' \r\n");

				string text = "In this game, the user is asked various geography questions and is required to guess the correct answers. It is a console-based game.\r\n\r\nHere is how the game is played:\r\n\r\n1. When the game starts, the user is presented with a menu. The menu options include \"Play\", \"About the game\", and \"Exit\".\r\n2. The user can navigate through the menu options using the up and down arrow keys and select an option by pressing the Enter key.\r\n3. If the user selects the \"Play\" option, the game begins.\r\n4. The game presents the user with 10 geography questions.\r\n5. Each question has 3 answer options, represented as \"a)\", \"b)\", and \"c)\".\r\n6. The user can make a selection by pressing the \"a\", \"b\", or \"c\" keys to choose the corresponding answer option.\r\n7. When the user provides the correct answer, a congratulatory message is displayed, and the user's score increases.\r\n8. If the user provides the wrong answer, an error message is displayed, and the user's score decreases.\r\n9. After each question, the displayed score is updated.\r\n10. The game ends after 10 questions, and the user's total score is shown.\r\n11.The game is played with up and down buttons.\r\n\r\nThis game is designed to test the user's geography knowledge and provide an enjoyable experience. The user tries to increase their score by guessing the correct answers while being cautious not to decrease their score with incorrect answers. The objective of the game is to achieve the highest score possible.\r\n\r\nYou can modify the code of the game to customize the questions, answers, and rules according to your preferences.\n";

				foreach (char c in text)
				{
					Console.Write(c);
					Thread.Sleep(60);
				}

				while (Console.KeyAvailable) // This is waiting for the sleep time to end.and it does not save the keys or print them on the screen.
				{
					Console.ReadKey(true);
				}

				Console.WriteLine("Press any key to get to menu . . ." , Console.ForegroundColor = ConsoleColor.Red);
				Console.ReadKey();

				goto Menu;
			}
			#endregion

			else
			{
				Console.WriteLine("Bye bye :/ ");
			}


		}




		static void AddElementInArray(ref int[] array, int element)
		{
			Array.Resize(ref array, array.Length + 1);
			array[array.Length - 1] = element;
		}


		static int CursorMove()
		{
			ConsoleKey keyInfo;
			int cursorTopPosition = 1;

			Console.SetCursorPosition(0, 1);
			Console.Write(" >>>", Console.ForegroundColor = ConsoleColor.Cyan);

			do
			{
				keyInfo = Console.ReadKey().Key;

				if(keyInfo == ConsoleKey.Escape)
				{
					Console.Clear();
					Console.WriteLine("BBye bye", Console.ForegroundColor = ConsoleColor.DarkRed);
					Thread.Sleep(500);
					Console.ResetColor();
					Environment.Exit(0);
				}

				if (keyInfo == ConsoleKey.DownArrow)
				{
					for (int j = 1; j < 4; j++)
					{
						Console.SetCursorPosition(0, j);
						Console.Write("    ");
					}

					cursorTopPosition++;
					cursorTopPosition = (cursorTopPosition == 4) ? 1 : cursorTopPosition;
					Console.SetCursorPosition(0, cursorTopPosition);

					Console.Write(" >>>", Console.ForegroundColor = ConsoleColor.Cyan);
				}
				else if (keyInfo == ConsoleKey.UpArrow)
				{
					for (int j = 1; j < 4; j++)
					{
						Console.SetCursorPosition(0, j);
						Console.Write("    ");
					}

					cursorTopPosition--;
					cursorTopPosition = (cursorTopPosition == 0) ? 3 : cursorTopPosition;
					Console.SetCursorPosition(0, cursorTopPosition);

					Console.Write(" >>>", Console.ForegroundColor = ConsoleColor.Cyan);
				}

				

			} while (keyInfo != ConsoleKey.Enter );

			Console.Clear();
			Console.ResetColor();
			return cursorTopPosition;

		}


	}






}
