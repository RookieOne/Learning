using NUnit.Framework;
using StructureMap;
using TestUtilities.Extensions;

namespace Basics
{
    [TestFixture]
    public class SpecifyConstructionWithDependencies
    {
        [SetUp]
        public void setup()
        {
            _container = new Container();

            _container.Configure(x =>
                                     {
                                         x.For<IFoo>().Use<Foo>();
                                         x.For<IBar>().Use(c =>
                                                               {
                                                                   var bar = new Bar();
                                                                   bar.Foo = c.GetInstance<IFoo>();
                                                                   return bar;
                                                               });
                                     });
        }

        IContainer _container;


        class Bar : IBar
        {
            public IFoo Foo { get; set; }
        }

        class Foo : IFoo
        {
        }

        interface IBar
        {
            IFoo Foo { get; }
        }

        interface IFoo
        {
        }

        [Test]
        public void should_set_foo_property_on_bar()
        {
            var bar = _container.GetInstance<IBar>();

            bar.Foo.ShouldBeType<Foo>();
        }
    }
}