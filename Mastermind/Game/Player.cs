using System;
using System.Collections;

namespace Mastermind
{
        public interface Player
        {
                Guess Play();

                void ParseResponse(ArrayList al);
        }
}

