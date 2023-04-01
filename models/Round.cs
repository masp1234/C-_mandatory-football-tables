using Football_tables.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_tables.Models
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
