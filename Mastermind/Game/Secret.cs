using System;
using System.Collections;

namespace Mastermind
{
        public class Secret
        {
                private Guess secret;

                public Secret ()
                {
                        Random r = new Random ();
                        int[] arr = new int[Mastermind.nrOfSecrets];
                        for (int i = 0; i < Mastermind.nrOfSecrets; i++){
                                arr[i] = r.Next(3);
                        }
                        secret = new Guess(arr);
                }

                public Secret (int[] arr)
                {
                        secret = new Guess(arr);
                }

                public String Reveal ()
                {
                        return "The Secret was: " + secret.ToString();
                }

                public ArrayList TestGuess (Guess g)
                {
                        ArrayList retVal = new ArrayList();
                        for (int i = 0; i < g.guesses.Count; i++){
                                if (g.guesses[i].Equals(secret.guesses[i])){
                                        retVal.Add(0);
                                } else if (secret.guesses.Contains(g.guesses[i])){
                                        retVal.Add(1);
                                } else {
                                        retVal.Add(2);
                                }

                        }
                        return retVal;
                }
        }
}

