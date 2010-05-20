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
                           new Jedi("Obi-wan Kenobi"),
                           new Jedi("Mace Windu"),
                           new Jedi("Yoda"),
                           new Jedi("Luke Skywalker"),
                           new Jedi("Kyle Katarn"),
                       };
        }

        IEnumerable<Jedi> GetJedisWithYield()
        {
            yield return new Jedi("Obi-wan Kenobi");
            yield return new Jedi("Mace Windu");
            yield return new Jedi("Yoda");
            yield return new Jedi("Luke Skywalker");
            yield return new Jedi("Kyle Katarn");
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