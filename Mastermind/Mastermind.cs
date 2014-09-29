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

                public Mastermind (int secretSize = 4, int gl = 10)
                {
                        nrOfSecrets = secretSize;
                        gameLength = gl;
                        p = new ComputerPlayer();
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
                                Console.WriteLine("You guessed: " + g.ToString());
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
                        Console.WriteLine("How many turns should the game run for at most?");

                        Mastermind m = new Mastermind();
                        m.run();

                        Console.WriteLine("Press any key to quit");
                        Console.Read();
                }
        }
}

