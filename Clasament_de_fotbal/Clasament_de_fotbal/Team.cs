using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clasament_de_fotbal
{
    internal class Team
    {
        private string name;
        private int score;

        public Team(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public bool HasBiggerScoreThan(Team that)
        {
            return this.score > that.score;
        }

        public void AddToScore(int x)
        {
            this.score += x;
        }
    }
}
