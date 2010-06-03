using System.Collections.Generic;
using NUnit.Framework;
using StructureMap;
using StructureMap.Pipeline;
using TestUtilities.Extensions;

namespace Basics
{
    [TestFixture]
    public class ConditionalBinding
    {
        [SetUp]
        public void setup()
        {
            _container = new Container();

            _container.Configure(x =>
                                     {
                                         x.For<IFoo>().Use<AFoo>();
                                     });
        }

        IContainer _container;

        interface IFoo
        {
        }

        class AFoo : IFoo
        {
        }

        class BFoo : IFoo
        {
        }

        [Test]
        public void should_use_AFoo()
        {
            var foo = _container.GetInstance<IFoo>(new ExplicitArguments(new Dictionary<string, object> {{"Field", 5}}));

            foo.ShouldBeType<AFoo>();
        }
    }
}