namespace Learning_CSharp.FauxDomain
{
    public class Jedi
    {
        public Jedi(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public int MidichlorianCount { get; set; }

        public Jedi MidichlorianCountIs(int count)
        {
            MidichlorianCount = count;
            return this;
        }
    }
}