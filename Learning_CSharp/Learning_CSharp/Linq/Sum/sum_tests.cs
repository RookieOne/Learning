using System.Collections.Generic;
using System.Linq;
using Learning_CSharp.FauxDomain;
using NUnit.Framework;

namespace Learning_CSharp.Linq.Sum
{
    [TestFixture]
    public class sum_tests
    {
        [Test]
        public void should_be_able_to_specify_property_to_sum()
        {
            var jedi = new List<Jedi>
                           {
                               new Jedi("Yoda").MidichlorianCountIs(1000),
                               new Jedi("Anakin Skywalker").MidichlorianCountIs(3000),
                               new Jedi("Luke Skywalker").MidichlorianCountIs(1500),
                               new Jedi("Obi-wan Kenobi").MidichlorianCountIs(500),
                           };

            int sum = jedi.Sum(j => j.MidichlorianCount);

            sum.ShouldBe(6000);
        }

        [Test]
        public void should_sum_values()
        {
            var nums = new List<int>
                           {
                               5,
                               9,
                               1,
                               10
                           };
            int sum = nums.Sum();

            sum.ShouldBe(25);
        }

        [Test]
        public void summing_non_number_collection()
        {
            var jedi = new List<Jedi>
                           {
                               new Jedi("Yoda").MidichlorianCountIs(1000),
                               new Jedi("Anakin Skywalker").MidichlorianCountIs(3000),
                               new Jedi("Luke Skywalker").MidichlorianCountIs(1500),
                               new Jedi("Obi-wan Kenobi").MidichlorianCountIs(500),
                           };
            // can't compile
            //var sum = jedi.Sum();
        }
    }
}