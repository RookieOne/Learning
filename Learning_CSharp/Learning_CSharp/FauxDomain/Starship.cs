using System.Collections.Generic;

namespace Learning_CSharp.FauxDomain
{
    public class Starship
    {
        public Starship(string name)
        {
            Name = name;
            Fighters = new List<Fighter>();
        }

        public string Name { get; set; }

        public List<Fighter> Fighters { get; set; }
    }
}