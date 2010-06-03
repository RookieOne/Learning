namespace Learning_CSharp.FauxDomain
{
    public class FighterSquadron
    {
        public FighterSquadron(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}