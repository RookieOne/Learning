using System.Collections.Generic;
using System.Linq;
using Learning_CSharp.FauxDomain;
using NUnit.Framework;

namespace Learning_CSharp.Linq.LinqAdditions
{
    [TestFixture]
    public class using_func_distinct
    {
        [Test]
        public void should_return_distinct_items()
        {
            var jedis = new[]
                            {
                                new Jedi("Mace Windu"),
                                new Jedi("Mace Windu"),
                                new Jedi("Luke Skywalker"),
                                new Jedi("Yoda"),
                                new Jedi("Yoda"),
                            };
            
            IEnumerable<Jedi> distinct = jedis.Distinct((j1, j2) => j1.Name == j2.Name);

            distinct.Count().ShouldBe(3);
        }
    }
}