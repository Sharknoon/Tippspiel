using FluentNHibernate.Mapping;
using Tippspiel_Server.Sources.Models;

namespace Tippspiel_Server.Sources.Database.Mappings
{
    public class Bettors : ClassMap<Bettor>
    {
        public Bettors()
        {
            Table("Bettors");

            Id(bettor => bettor.Id);

            Map(bet => bet.Nickname).Not.Nullable();
            Map(bet => bet.Firstname).Not.Nullable();
            Map(bet => bet.Lastname).Not.Nullable();

            Version(bettor => bettor.Version);
        }
    }
}