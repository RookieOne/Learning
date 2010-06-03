using System.Linq;
using Learning_CSharp.FauxDomain;
using NUnit.Framework;

namespace Learning_CSharp.Linq.Aggregate
{
    [TestFixture]
    public class aggregate_tests
    {
        [SetUp]
        public void setup()
        {
            _starship = new Starship("Chimera");
            _starship.Fighters.AddRange(new[]
                                            {
                                                new FighterSquadron("Red"),
                                                new FighterSquadron("Gold"),
                                                new FighterSquadron("Blue"),
                                            });
        }

        Starship _starship;

        [Test]
        public void should_make_comma_delimited_string_of_fighters()
        {
            string fighters = _starship.Fighters.Aggregate(string.Empty, (s, f) => s + ", " + f.Name);

            if (fighters.Length > 0)
                fighters = fighters.Remove(0, 2); // remove extra comma

            fighters.ShouldBe("Red, Gold, Blue");
        }
    }
}