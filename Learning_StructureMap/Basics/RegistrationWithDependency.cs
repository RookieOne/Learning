using NUnit.Framework;
using StructureMap;
using TestUtilities.Extensions;

namespace Basics
{
    [TestFixture]
    public class RegistrationWithDependency
    {
        [SetUp]
        public void setup()
        {
            _container = new Container();

            _container.Configure(x =>
                                     {
                                         x.For<IFoo>().Use<Foo>();
                                         x.For<IBar>().Use<Bar>();
                                     });
        }

        IContainer _container;

        class Bar : IBar
        {
            public Bar(IFoo foo)
            {
                Foo = foo;
            }

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
        public void IBar_should_resolve_to_Bar()
        {
            var bar = _container.GetInstance<IBar>();

            bar.ShouldBeType<Bar>();
        }

        [Test]
        public void IBars_IFoo_dependency_should_resolve_to_Foo()
        {
            var bar = _container.GetInstance<IBar>();

            bar.Foo.ShouldBeType<Foo>();
        }
    }
}