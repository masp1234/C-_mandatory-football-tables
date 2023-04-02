using Football_tables.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_tables.models
{
    internal class Round
    {
        public int Number { get; set; }
        public List<Match> Matches { get; set; }

        public Round(int number)
        {
            Number = number;
            Matches = new List<Match>();
        }

        public void AddMatch(Match match)
        {
            Matches.Add(match);
        }
    }
}
