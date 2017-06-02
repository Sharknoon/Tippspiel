using FluentNHibernate.Mapping;
using Tippspiel_Server.Sources.Models;

namespace Tippspiel_Server.Sources.Database.Mappings
{
    public class Bets : ClassMap<Bet>
    {
        public Bets()
        {
            Table("Bets");

            Id(bet => bet.Id);

            Map(bet => bet.DateTime).Not.Nullable();
            Map(bet => bet.HomeTeamScore).Not.Nullable();
            Map(bet => bet.AwayTeamScore).Not.Nullable();

            References(bet => bet.Match).Column("MatchId").Unique().Not.Nullable().Cascade.All();
            References(bet => bet.Bettor).Column("BettorId").Unique().Not.Nullable().Cascade.All();

            Version(bet => bet.Version);
        }
    }
}