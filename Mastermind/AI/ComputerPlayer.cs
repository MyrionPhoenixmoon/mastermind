using System;
using System.Collections;

namespace Mastermind
{
        public class ComputerPlayer : Player
        {
                private Guess guess;
                private int[] solution = new int[Mastermind.nrOfSecrets];

                Random r = new Random();

                public ComputerPlayer ()
                {

                }

                public Guess Play ()
                {
                        if (guess == null) {
                                guess = new Guess();
                        }
                        return guess;
                }

                public void ParseResponse (ArrayList al)
                {
                        int wrongPos = 0;
                        bool usedBuffer = false;
                        int index = 0;
                        IEnumerator e = al.GetEnumerator();
                        while (e.MoveNext()) {
                                switch ((int)e.Current) {
                                case 0: 
                                        solution[index] = (int)guess.guesses[index];
                                        index++;
                                        break;
                                case 1:
                                        if (usedBuffer) {
                                                solution[index] = wrongPos;
                                                wrongPos = (int)guess.guesses[index];
                                                index++;
                                        } else {
                                                wrongPos = (int)guess.guesses[index];
                                                usedBuffer = true;
                                                solution[index] = r.Next(3);
                                                index++;
                                        }
                                        break;
                                case 2:
                                default:
                                        if (usedBuffer) {
                                                solution[index] = wrongPos;
                                                usedBuffer = false;
                                                index++;
                                        } else {
                                                solution[index] = r.Next(3);
                                                index++;
                                        }
                                        break;
                                }
                        }
                        usedBuffer = false;
                        guess = new Guess(solution);
                }
        }
}

