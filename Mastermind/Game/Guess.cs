using System;
using System.Collections;

namespace Mastermind
{
        public class Guess
        {
                public ArrayList guesses = new ArrayList();

                public Guess ()
                {
                        int now = DateTime.Now.Millisecond;
                        while (DateTime.Now.Millisecond == now) { // Enforce a different seed when generating guesses in a loop
                        }
                        Random r = new Random(DateTime.Now.Millisecond);
                        for (int i = 0; i < Mastermind.nrOfSecrets; i++) {
                                guesses.Add(r.Next(3));
                        }
                }

                public Guess (int[] arr)
                {
                        if (arr.Length != Mastermind.nrOfSecrets) {
                                throw new ArgumentException("You guessed too many or too few numbers!");
                        }
                        foreach (int i in arr) {
                                guesses.Add(i);
                        }
                }

                public override string ToString ()
                {
                        String s = "";
                        foreach (int i in guesses) {
                                s += i + " ";
                        }
                        return s;
                }
        }
}

