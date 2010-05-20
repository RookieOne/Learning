using System.Collections.Generic;
using System.Linq;
using Learning_CSharp.FauxDomain;
using NUnit.Framework;

namespace Learning_CSharp.Linq.Select
{
    [TestFixture]
    public class select_tests
    {
        [Test]
        public void returns_enumerable_of_different_type()
        {
            List<string> names = new[] {"Luke", "Yoda", "Anakin"}.ToList();

            IEnumerable<Jedi> jedi = names.Select(n => new Jedi(n));

            jedi.Count().ShouldBe(3);
            jedi.ElementAt(0).Name.ShouldBe("Luke");
            jedi.ElementAt(1).Name.ShouldBe("Yoda");
            jedi.ElementAt(2).Name.ShouldBe("Anakin");
        }
    }
}