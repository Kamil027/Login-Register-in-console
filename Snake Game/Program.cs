using Snake_Game.Models;
using Snake_Game.Models.ForUsers;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Threading.Channels;

namespace Snake_Game
{
    internal class Program
	{
		static void Main()
		{

			Console.CursorVisible = false;


			Console.WriteLine("			Sign in");
			Console.WriteLine("			Sign up");

            Console.WriteLine(@"


	 @@@@@@   @@@  @@@   @@@@@@   @@@  @@@  @@@@@@@@      @@@@@@@@   @@@@@@   @@@@@@@@@@   @@@@@@@@  
	@@@@@@@   @@@@ @@@  @@@@@@@@  @@@  @@@  @@@@@@@@     @@@@@@@@@  @@@@@@@@  @@@@@@@@@@@  @@@@@@@@  
	!@@       @@!@!@@@  @@!  @@@  @@!  !@@  @@!          !@@        @@!  @@@  @@! @@! @@!  @@!       
	!@!       !@!!@!@!  !@!  @!@  !@!  @!!  !@!          !@!        !@!  @!@  !@! !@! !@!  !@!       
	!!@@!!    @!@ !!@!  @!@!@!@!  @!@@!@!   @!!!:!       !@! @!@!@  @!@!@!@!  @!! !!@ @!@  @!!!:!    
	 !!@!!!   !@!  !!!  !!!@!!!!  !!@!!!    !!!!!:       !!! !!@!!  !!!@!!!!  !@!   ! !@!  !!!!!:    
	     !:!  !!:  !!!  !!:  !!!  !!: :!!   !!:          :!!   !!:  !!:  !!!  !!:     !!:  !!:       
	    !:!   :!:  !:!  :!:  !:!  :!:  !:!  :!:          :!:   !::  :!:  !:!  :!:     :!:  :!:       
	:::: ::    ::   ::  ::   :::   ::  :::   :: ::::      ::: ::::  ::   :::  :::     ::    :: ::::  
	:: : :    ::    :    :   : :   :   :::  : :: ::       :: :: :    :   : :   :      :    : :: ::   
                                                                                                 



");



            ExtensionMethod.CursorMoveForMenu(0, 0, 1, 0);
			Console.Clear();
			Console.ResetColor();


			if (CursorPosition.Y == 1) 
				Account.Register();
			
			else if(CursorPosition.Y == 0)
				Account.Login();
			


		}
	}
}