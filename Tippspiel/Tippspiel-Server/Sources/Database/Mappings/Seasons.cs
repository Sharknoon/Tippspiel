using FluentNHibernate.Mapping;
using Tippspiel_Server.Models;

namespace Tippspiel_Server.Database.Mappings
{
    public class Seasons : ClassMap<Season>
    {
        public Seasons()
        {
            Table("Seasons");

            Id(season => season.Id);

            Map(team => team.Name).Length(300).Not.Nullable().Unique();
            Map(season => season.Description).Length(1000);
            Map(season => season.Sequence).Not.Nullable().Unique();

            Version(season => season.Version);
        }   
    }
}