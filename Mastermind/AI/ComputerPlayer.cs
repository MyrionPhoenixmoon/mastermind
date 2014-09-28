using System;
using System.Collections;

namespace Mastermind
{
        public class ComputerPlayer : Player
        {
                private Guess guess;

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
                        int index = 0;
                        int[] guess = new int[Mastermind.nrOfSecrets];
                        IEnumerator e = al.GetEnumerator();
                        while (e.MoveNext()) {
                                switch (e.Current){
                                case 0: guess[index] = 
                                }
                        }
                }
        }
}

