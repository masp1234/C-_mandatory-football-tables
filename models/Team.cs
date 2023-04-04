using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_tables.models
{
    internal class Team
    {
        public Team(string abbreviation, string fullName, string specialRanking, string leagueName)
        {
            Abbreviation = abbreviation;
            FullName = fullName;
            SpecialRanking = specialRanking;
            LeagueName = leagueName;
        }

        public string Abbreviation { get; set; }
        public string FullName { get; set; }
        
        public string SpecialRanking { get; set; }
        public string LeagueName { get; set; }
    }
}
