using FluentNHibernate.Mapping;
using Tippspiel_Server.Sources.Models;

namespace Tippspiel_Server.Sources.Database.Mappings
{
    public class Seasons : ClassMap<Season>
    {
        public Seasons()
        {
            Table("Seasons");

            Id(season => season.Id);

            Map(season => season.Name).Length(300).Not.Nullable().Unique();
            Map(season => season.Description).Length(1000);
            Map(season => season.Sequence).Not.Nullable().Unique();

            HasManyToMany(season => season.Teams)
                .Table("SeasonsToTeamsRelation")
                .ParentKeyColumn("SeasonId")
                .ChildKeyColumn("TeamId")
                .Cascade
                .SaveUpdate();

            Version(season => season.Version);
        }   
    }
}