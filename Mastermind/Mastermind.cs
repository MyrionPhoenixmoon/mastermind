using System;
using System.Collections;

namespace Mastermind
{
        public class Mastermind
        {
                public static int nrOfSecrets, gameLength;
                private Secret secret;
                public static bool victory = false;
                public Player p;

                public Mastermind ()
                {
                        nrOfSecrets = 4;
                        gameLength = 10;
                        p = new ComputerPlayer();
                        secret = new Secret();
                }

                public Mastermind (int secretSize = 4, int gl = 10, int nrOfPlayers = 0)
                {
                        nrOfSecrets = secretSize;
                        gameLength = gl;
                        if (nrOfPlayers == 0) {
                                p = new ComputerPlayer();
                        } else {
                                p = new HumanPlayer();
                        }
                        secret = new Secret();
                }

                public String AnalyzeResponse (ArrayList al)
                {
                        String retval = "The response to your guess is: ";
                        int correct = 0;
                        foreach (int val in al) {
                                if (val == 0) {
                                        retval += "O ";
                                        correct++;
                                } else if (val == 1) {
                                        retval += "# ";
                                } else {
                                        retval += "X ";
                                }
                        }
                        if (correct == Mastermind.nrOfSecrets){
                                retval = "You got everything right, congratulations!";
                                victory = true;                                     
                        }
                        return retval;
                }

                public void run ()
                {
                        int gameTurn = 0;
                        while (!victory && gameTurn < gameLength) {
                                Console.WriteLine("Make a guess:");
                                Guess g = p.Play();
                                Console.WriteLine(AnalyzeResponse(secret.TestGuess(g)));
                                p.ParseResponse(secret.TestGuess(g));
                                gameTurn++;
                        }
                        Console.WriteLine(secret.Reveal());
                }

                public static void Main (string[] args)
                {
                        Console.WriteLine("Welcome to Mastermind!");
                        Console.WriteLine("O's will represent correct numbers, #'s will represent present but wrongly placed numbers and X's wrong ones");
                       
                        Console.WriteLine("How many numbers do you want to guess?");
                        int input1;
                        while (true) {
                                if (int.TryParse(Console.ReadLine(), out input1) && input1 > 0) {
                                        Console.WriteLine("You want to guess " + input1.ToString() + " numbers.");
                                        break;
                                } else {
                                        Console.WriteLine("That was illegal input. Try again.");
                                }
                        }

                        Console.WriteLine("How many turns should the game run for at most?");
                        int input2;
                        while (true) {
                                if (int.TryParse(Console.ReadLine(), out input2) && input2 > 0) {
                                        Console.WriteLine("You want the game to run " + input2.ToString() + " turns.");
                                        break;
                                } else {
                                        Console.WriteLine("That was illegal input. Try again.");
                                }
                        }

                        Console.WriteLine("How many players are there?");
                        Console.WriteLine("0 - Let the CPU play, 1 - Play against the CPU yourself");
                        int input3;
                        while (true) {
                                if (int.TryParse(Console.ReadLine(), out input3)) {
                                        if (input3 == 0){
                                                Console.WriteLine("You want the CPU to play against itself.");
                                                break;
                                        } else if (input3 == 1) {
                                                Console.WriteLine("You want to play against the CPU yourself.");
                                                break;
                                        } else {
                                                Console.WriteLine("That was illegal input. Try again.");
                                        }                                           
                                } else {
                                        Console.WriteLine("That was illegal input. Try again.");
                                }
                        }

                        Mastermind m = new Mastermind(input1, input2, input3);
                        m.run();

                        Console.WriteLine("Press any key to quit");
                        Console.Read();
                }
        }
}

