using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_tables.models
{
    internal struct LeagueInfo
    {
        public string Name;
        public int PositionsPromotedToChampionsLeague;
        public int PositionsPromotedToEuropaLeague;
        public int PositionsPromotedToConferenceLeague;
        public int PositionsPromotedToUpperLeague;
        public int PositionsRelegatedToLowerLeague;
        
    
        public LeagueInfo(
            string name,
            int positionsPromotedToChampionsLeague,
            int positionsPromotedToEuropaLeague,
            int positionsPromotedToConferenceLeague,
            int positionsPromotedToUpperLeague,
            int positionsRelegatedToLowerLeague)
        {
            this.Name = name;
            this.PositionsPromotedToChampionsLeague = positionsPromotedToChampionsLeague;
            this.PositionsPromotedToEuropaLeague = positionsPromotedToEuropaLeague;
            this.PositionsPromotedToConferenceLeague = positionsPromotedToConferenceLeague;
            this.PositionsPromotedToUpperLeague = positionsPromotedToUpperLeague;
            this.PositionsRelegatedToLowerLeague = positionsRelegatedToLowerLeague;
        }
    }
}
