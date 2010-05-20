using NUnit.Framework;
using StructureMap;
using TestUtilities.Extensions;

namespace Basics
{
    [TestFixture]
    public class SingletonRegistration
    {
        interface IFoo
        {
        }

        class Foo : IFoo
        {
        }

        [Test]
        public void should_return_same_instance_of_Foo()
        {
            var container = new Container();
            container.Configure(x => x.For<IFoo>().Singleton().Use<Foo>());

            var foo1 = container.GetInstance<IFoo>();
            var foo2 = container.GetInstance<IFoo>();

            foo1.ShouldBeTheSameInstanceAs(foo2);
        }
    }
}