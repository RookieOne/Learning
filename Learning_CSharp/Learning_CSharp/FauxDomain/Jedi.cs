namespace Learning_CSharp.FauxDomain
{
    public class Jedi
    {
        public Jedi(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}