using NUnit.Framework;
using StructureMap;
using TestUtilities.Extensions;

namespace Basics
{
    [TestFixture]
    public class SpecifyingConstruction
    {
        class Foo : IFoo
        {
            public Foo(string message)
            {
                Message = message;
            }

            public string Message { get; set; }
        }

        interface IFoo
        {
            string Message { get; }
        }

        [SetUp]
        public void setup()
        {
            _container = new Container();
            _container.Configure(x => x.For<IFoo>().Use(() => new Foo("Hello")));
        }

        IContainer _container;

        [Test]
        public void IFoo_should_resolve_to_Foo()
        {
            var foo = _container.GetInstance<IFoo>();

            foo.ShouldBeType<Foo>();            
        }

        [Test]
        public void message_should_be_set_during_construction()
        {
            var foo = _container.GetInstance<IFoo>();
            
            foo.Message.ShouldBe("Hello");
        }
    }
}