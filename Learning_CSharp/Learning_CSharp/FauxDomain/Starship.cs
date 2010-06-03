using System.Collections.Generic;

namespace Learning_CSharp.FauxDomain
{
    public class Starship
    {
        public Starship(string name)
        {
            Name = name;
            Fighters = new List<FighterSquadron>();
        }

        public string Name { get; set; }

        public List<FighterSquadron> Fighters { get; set; }
    }
}