using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Learning_CSharp._Linq.LinqAdditions;

namespace Learning_CSharp._yield
{
    [TestFixture]
    public class yield_tests
    {
        class Foo
        {
            public int Id { get; set; }
        }

        IEnumerable<Foo> CreateList()
        {
            var result = new List<Foo>();

            for (int i = 0; i < 10; i++)
            {
                result.Add(new Foo { Id = i});
            }

            return result;
        }

        IEnumerable<Foo> CreateListWithYield()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new Foo { Id = i };
            }
        }

        [Test]
        public void with_yield()
        {
            IEnumerable<Foo> foos = CreateListWithYield();

            foos.Count().ShouldBe(10);
        }

        [Test]
        public void without_yield()
        {
            IEnumerable<Foo> foos = CreateList();

            foos.Count().ShouldBe(10);
        }
    }
}