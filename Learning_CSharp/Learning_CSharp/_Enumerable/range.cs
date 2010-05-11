using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Learning_CSharp._Enumerable
{
    [TestFixture]
    public class range
    {
        [Test]
        public void should_create_collection()
        {
            IEnumerable<Foo> foos = Enumerable.Range(0, 10).Select(value => new Foo {Id = value});

            foos.Count().ShouldBe(10);
        }
    }

    internal class Foo
    {
        public int Id { get; set; }
    }
}