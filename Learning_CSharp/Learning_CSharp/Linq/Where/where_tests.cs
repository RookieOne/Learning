using System.Collections.Generic;
using System.Linq;
using Learning_CSharp.FauxDomain;
using NUnit.Framework;

namespace Learning_CSharp.Linq.Where
{
    [TestFixture]
    public class where_tests
    {
        [SetUp]
        public void setup()
        {
            _jedi = new List<Jedi>
                        {
                            new Jedi("Luke Skywalker"),
                            new Jedi("Yoda"),
                            new Jedi("Anakin Skywalker"),
                            new Jedi("Mace Windu"),
                            new Jedi("Obi-wan Kenobi")
                        };
        }

        List<Jedi> _jedi;

        [Test]
        public void proper_use_of_where()
        {
            IEnumerable<Jedi> skywalkers = _jedi
                .Where(j => j.Name.EndsWith("Skywalker"));

            skywalkers.Count().ShouldBe(2);
        }

        [Test]
        public void redundant_select()
        {
            IEnumerable<Jedi> skywalkers = _jedi
                .Where(j => j.Name.EndsWith("Skywalker"))
                .Select(j => j);

            skywalkers.Count().ShouldBe(2);
        }

        [Test]
        public void redundant_first()
        {
            Jedi skywalker = _jedi
                .Where(j => j.Name.EndsWith("Skywalker"))
                .FirstOrDefault();

            skywalker.ShouldNotBe(null);
        }

        [Test]
        public void first()
        {
            Jedi skywalker = _jedi
                .FirstOrDefault(j => j.Name.EndsWith("Skywalker"));

            skywalker.ShouldNotBe(null);
        }

        [Test]
        public void counts_vs_any()
        {
            var isEmpty = _jedi.Count() != 0;

            var isEmpty2 = _jedi.Any();
        }
    }
}