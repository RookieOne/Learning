using System.Collections.Generic;
using System.Linq;
using Learning_CSharp.FauxDomain;
using NUnit.Framework;

namespace Learning_CSharp._yield
{
    [TestFixture]
    public class yielding_jedis
    {
        IEnumerable<Jedi> GetJedis()
        {
            return new List<Jedi>
                       {
                           new Jedi {Name = "Obi-wan Kenobi"},
                           new Jedi {Name = "Mace Windu"},
                           new Jedi {Name = "Yoda"},
                           new Jedi {Name = "Luke Skywalker"},
                           new Jedi {Name = "Kyle Katarn"},
                       };
        }

        IEnumerable<Jedi> GetJedisWithYield()
        {
            yield return new Jedi {Name = "Obi-wan Kenobi"};
            yield return new Jedi {Name = "Mace Windu"};
            yield return new Jedi {Name = "Yoda"};
            yield return new Jedi {Name = "Luke Skywalker"};
            yield return new Jedi {Name = "Kyle Katarn"};
        }

        [Test]
        public void get_customers_without_yield()
        {
            GetJedis().Count().ShouldBe(5);
        }

        [Test]
        public void get_customers_with_yield()
        {
            GetJedis().Count().ShouldBe(5);
        }
    }
}