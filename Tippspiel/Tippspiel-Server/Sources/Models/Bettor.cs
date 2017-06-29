namespace Tippspiel_Server.Sources.Models
{
    public class Bettor
    {
        //DB Identifier and Locking
        public int Id { get; set; }

        public int Version { get; set; }

        //Informations from the DB
        public string Nickname { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}