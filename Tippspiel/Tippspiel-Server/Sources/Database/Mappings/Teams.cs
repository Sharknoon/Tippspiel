using FluentNHibernate.Mapping;
using Tippspiel_Server.Sources.Models;

namespace Tippspiel_Server.Sources.Database.Mappings
{
    public class Teams : ClassMap<Team>
    {
        public Teams()
        {
            Table("Teams");

            Id(team => team.Id);

            Map(team => team.Name).Length(300).Not.Nullable();

            HasManyToMany(team => team.Seasons)
                .Table("SeasonsToTeamsRelation")
                .ParentKeyColumn("TeamId")
                .ChildKeyColumn("SeasonId")
                .Cascade
                .SaveUpdate();

            Version(team => team.Version);
        }
    }
}