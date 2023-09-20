using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

#nullable disable

namespace Snake_Game.Models.ForUsers
{
	internal static class Account
	{
		public static void Register()
		{
			string password = "" ;
			string e_mail = ""; //string builder olmalidi cunki cox deyisir amma ilk once fikir vermdiyim ucun bele qaldi :/
			List<User> users;

			string faylYolu = @"C:\Users\ASUS Vivobook\Desktop\SnakeGame.json";

			if (File.Exists(faylYolu))
			{
				// Faylı aç və JSON məzmununu oxu
				using (FileStream fayl = new FileStream(faylYolu, FileMode.Open))
				using (StreamReader reader = new StreamReader(fayl))
				{
					string mövcudJsonMassivi = reader.ReadToEnd();
					users = JsonConvert.DeserializeObject<List<User>>(mövcudJsonMassivi);
				}
			}
			else
			{
				users = new List<User>();
			}

			#region check email and password

			//email ve passwordun yoxlandiqdan sonra qebulu

			while (true) 
			{	
				Console.Write("Email: ");
				string emptyString = new string(' ', Console.WindowWidth);
				bool check;


				ConsoleKeyInfo keyInfo;
				do
				{
					check = true;
					keyInfo = Console.ReadKey(true); 
					
				
					
					if (keyInfo.Key == ConsoleKey.Backspace)
					{
						if(e_mail.Length-1 >=0)
							e_mail = e_mail.Substring(0, e_mail.Length - 1);
						Console.SetCursorPosition(7, 0);
						Console.Write(emptyString);  // Clear the line
						Console.SetCursorPosition(7, 0);
						Console.Write(e_mail); 

					}
					
					else if (keyInfo.Key != ConsoleKey.Enter)
					{
						e_mail += keyInfo.KeyChar;
						Console.SetCursorPosition(7, 0);
						Console.Write(e_mail); 

					}

					if (keyInfo.Key == ConsoleKey.Escape)
						Environment.Exit(0);

						

					if (e_mail.Length <= 11)
					{
						Console.WriteLine($"\n{emptyString}");
						Console.SetCursorPosition(0, 1);
						Console.Write("E-mail uzunlugu en azi 11 olmalidir!", Console.ForegroundColor = ConsoleColor.DarkRed);
						Console.SetCursorPosition(7 + e_mail.Length, 0);
						check = false;
					}

					else if (e_mail.Contains(' '))
					{
						Console.WriteLine($"\n{emptyString}");
						Console.SetCursorPosition(0, 1);
						Console.Write("E-mail yazarken bosluq qoymaq olmaz!", Console.ForegroundColor = ConsoleColor.DarkRed);
						Console.SetCursorPosition(7 + e_mail.Length, 0);
						check = false;
					}

					else if (!e_mail.Contains('@'))
					{
						Console.WriteLine($"\n{emptyString}");
						Console.SetCursorPosition(0, 1);
						Console.Write("E-mail'de @- isaresinden istifade mutleqdir!", Console.ForegroundColor = ConsoleColor.DarkRed);
						Console.SetCursorPosition(7 + e_mail.Length, 0);
						check = false;
					}

					else if (check)
					{
						Console.WriteLine($"\n{emptyString}");
						Console.SetCursorPosition(7 + e_mail.Length, 0);
					}

					Console.ResetColor();

					if(keyInfo.Key == ConsoleKey.Enter && check)
					{
						break;
					}


				} while (true); //email



				//elave yoxlanis

				if (e_mail.Contains('@') && e_mail.Length >= 11 && !e_mail.Contains(' '))
				{
					User findedUser = users.FirstOrDefault(x => x.Email == e_mail);
					if (findedUser != null)
					{
						Console.WriteLine("Bu e-mail artiq qediyyatdan kecib!", Console.ForegroundColor = ConsoleColor.Red);
					}
						

                    else
						break;
				}
				else
				{
					Console.Clear();
					Console.WriteLine("E-mail yazma qaydalarina emel edilmeyib!", Console.ForegroundColor = ConsoleColor.Red);
					ExtensionMethod.Wait(2000);
					Console.ResetColor();
				}


			}

			#endregion



			while (true)
			{
				Console.Write("\nPassword: ");
				string emptyString = new string(' ', Console.WindowWidth);
				bool check;


				ConsoleKeyInfo keyInfo;

				do
				{
					check = true;
					keyInfo = Console.ReadKey(true);



					if (keyInfo.Key == ConsoleKey.Backspace)
					{
						if (password.Length - 1 >= 0)
							password = password.Substring(0, password.Length - 1);
						Console.SetCursorPosition(11, 1);
						Console.Write(emptyString);  // Clear the line
						Console.SetCursorPosition(11, 1);
						Console.Write(password);

					}

					else if (keyInfo.Key != ConsoleKey.Enter)
					{
						password += keyInfo.KeyChar;
						Console.SetCursorPosition(11, 1);
						Console.Write(password);

					}

					if (keyInfo.Key == ConsoleKey.Escape)
						Environment.Exit(0);



					if (password.Length < 8)
					{
						Console.WriteLine($"\n{emptyString}");
						Console.SetCursorPosition(0, 2);
						Console.Write("Password uzunlugu en azi 8 olmalidir!", Console.ForegroundColor = ConsoleColor.DarkRed);
						Console.SetCursorPosition(11 + password.Length, 2);
						check = false;
					}

					else if (password.Contains(' '))
					{
						Console.WriteLine($"\n{emptyString}");
						Console.SetCursorPosition(0, 2);
						Console.Write("Password yazarken bosluq qoymaq olmaz!", Console.ForegroundColor = ConsoleColor.DarkRed);
						Console.SetCursorPosition(8 + password.Length, 2);
						check = false;
					}

					

					else if (check)
					{
						Console.WriteLine($"\n{emptyString}");
						Console.SetCursorPosition(11 + password.Length, 0);
					}

					Console.ResetColor();

					if (keyInfo.Key == ConsoleKey.Enter && check)
					{
						break;
					}


				} while (true);



				// elave yoxlanis password

				if (password.Length >= 8 && !password.Contains(' '))
				{
					break;
				}
				else
				{
					Console.Clear();
					Console.WriteLine("Password yazarken qaydalara riayet edin!", Console.ForegroundColor = ConsoleColor.Red);
					ExtensionMethod.Wait(2000);
					Console.ResetColor();
				}



			}


			User user = new User(e_mail, password);
			users.Add(user);

			string yenilənmişJsonMassivi = JsonConvert.SerializeObject(users, Formatting.Indented);
			using (FileStream fayl = new FileStream(faylYolu, FileMode.Create))
			using (StreamWriter writer = new StreamWriter(fayl))
			{
				writer.Write(yenilənmişJsonMassivi);
			}

			CursorPosition.CursorReset();
			Console.Clear();
			Console.WriteLine(@"                                                                                                   
 _____             _                  _ _             _     _            _             _ _     _       
|  |  |___ _ _ ___| |___    ___ ___ _| |_|_ _ _ _ ___| |_ _| |___ ___   | |_ ___ ___ _| |_|___|_|___   
|  |  | . | | |  _| | .'|  | . | -_| . | | | | | | .'|  _| . | .'|   |  | '_| -_|  _| . | |   | |- _|_ 
|_____|_  |___|_| |_|__,|  |_  |___|___|_|_  |_  |__,|_| |___|__,|_|_|  |_,_|___|___|___|_|_|_|_|___|_|
      |___|                  |_|         |___|___|                                                     

", Console.ForegroundColor = ConsoleColor.Green) ;

			ExtensionMethod.Wait(2000);
			Console.ResetColor();
		}

		public static bool Login()
		{
			List<User> users = new List<User>();

			while (true)
			{



				Console.Write("E-mail: ");
				string email = Console.ReadLine();

				Console.Write("Password: ");


				string password = "";
				ConsoleKeyInfo keyInfo;

				string emptyString = new string(' ', Console.WindowWidth);











				do
				{
					keyInfo = Console.ReadKey(true); // Hide the pressed key




					if (keyInfo.Key == ConsoleKey.Backspace)
					{
						if(password.Length -1 >=0)
							password = password.Substring(0, password.Length - 1);
						Console.SetCursorPosition(10, 1);
						Console.Write(emptyString);  // Clear the line
						Console.SetCursorPosition(10, 1);
						Console.Write(new string('*',password.Length));

					}
					
					else if (keyInfo.Key == ConsoleKey.Escape)
						return false;

					else if (keyInfo.Key != ConsoleKey.Enter)
					{
						password += keyInfo.KeyChar;
						Console.Write("*"); // Display a masking character
					}

				






				} while (keyInfo.Key != ConsoleKey.Enter);


				string faylYolu = @"C:\Users\ASUS Vivobook\Desktop\SnakeGame.json";

				if (File.Exists(faylYolu))
				{
					// Faylı aç və JSON məzmununu oxu
					using (FileStream fayl = new FileStream(faylYolu, FileMode.Open))
					using (StreamReader reader = new StreamReader(fayl))
					{
						string mövcudJsonMassivi = reader.ReadToEnd();
						users = JsonConvert.DeserializeObject<List<User>>(mövcudJsonMassivi);
					}
				}


				User user = users.FirstOrDefault(x => x.Email == email);

				if (user == null)
				{
					Console.WriteLine("\nInvalid password or E-mail !", Console.ForegroundColor = ConsoleColor.Red);
					ExtensionMethod.Wait(3000);
					Console.ResetColor();
				}
				else
				{
					if (user.Password != password)
					{
						Console.WriteLine("\nInvalid password or E-mail !", Console.ForegroundColor = ConsoleColor.Red);
						ExtensionMethod.Wait(2000);
						Console.ResetColor();
					}
					else
					{
						Console.WriteLine("\nCongratulations, you have successfully entered.", Console.ForegroundColor = ConsoleColor.Green);
						ExtensionMethod.Wait(2000);
						Console.ResetColor();
						return true;
					}
				}
				Console.Clear();

            }




		}

	}
}
