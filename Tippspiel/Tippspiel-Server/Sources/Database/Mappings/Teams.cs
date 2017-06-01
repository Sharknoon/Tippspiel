using FluentNHibernate.Mapping;
using Tippspiel_Server.Models;

namespace Tippspiel_Server.Database.Mappings
{
    public class Teams : ClassMap<Team>
    {
        public Teams()
        {
            Table("Teams");

            Id(team => team.Id);

            Map(team => team.Name).Length(300).Not.Nullable();

            Version(team => team.Version);
        }
    }
}