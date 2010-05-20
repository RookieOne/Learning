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
            var container = new Container();

            container.Configure(x =>
                                    {
                                        x.For<IFoo>().Use<Foo>();
                                        x.For<IBar>().Use<Bar>();
                                    });

            _bar = container.GetInstance<IBar>();
        }

        IBar _bar;


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
            _bar.ShouldBeType<Bar>();
        }

        [Test]
        public void IBars_IFoo_dependency_should_resolve_to_Foo()
        {
            _bar.Foo.ShouldBeType<Foo>();
        }
    }
}