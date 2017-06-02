using FluentNHibernate.Mapping;
using Tippspiel_Server.Sources.Models;

namespace Tippspiel_Server.Sources.Database.Mappings
{
    public class Matches : ClassMap<Match>
    {
        public Matches()
        {
            Table("Matches");

            Id(match => match.Id);

            Map(match => match.MatchDay).Not.Nullable();
            Map(match => match.DateTime).Not.Nullable();
            Map(match => match.HomeTeamScore).Not.Nullable();
            Map(match => match.AwayTeamScore).Not.Nullable();
            
            References(match => match.HomeTeam).Column("HomeTeamId").Unique().Not.Nullable().Cascade.All();
            References(match => match.AwayTeam).Column("AwayTeamId").Unique().Not.Nullable().Cascade.All();
            References(match => match.Season).Column("SeasonId").Unique().Not.Nullable().Cascade.All();

            Version(season => season.Version);
        }
    }
}