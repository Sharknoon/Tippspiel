using FluentNHibernate.Mapping;
using Tippspiel_Server.Sources.Models;

namespace Tippspiel_Server.Sources.Database.Mappings
{
    public class Seasons : ClassMap<Season>
    {
        public Seasons()
        {
            Table("Seasons");

            Id(season => season.Id).GeneratedBy.Native();

            Map(season => season.Name).Length(300).Not.Nullable();
            Map(season => season.Description).Length(1000);
            Map(season => season.Sequence).Not.Nullable();

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