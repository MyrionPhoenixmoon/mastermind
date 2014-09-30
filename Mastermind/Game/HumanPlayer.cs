using System;
using System.Linq;

namespace Mastermind
{
        public class HumanPlayer : Player
        {
                private int[] solution = new int[Mastermind.nrOfSecrets];

                public HumanPlayer ()
                {
                }

                #region Player implementation

                public Guess Play ()
                {
                        for (int i = 0; i < Mastermind.nrOfSecrets; i++){
                                while (true) {
                                        if (int.TryParse((Convert.ToChar(Console.Read())).ToString(), out solution[i])) {
                                                break;
                                        }
                                }
                        }
                        Console.WriteLine("");
                        return new Guess(solution);
                }

                public void ParseResponse (System.Collections.ArrayList al)
                {
                        // Do nothing for now
                }

                #endregion
        }
}

