using NUnit.Framework;
using StructureMap;
using TestUtilities.Extensions;

namespace Basics
{
    [TestFixture]
    public class NormalRegistration
    {
        class Foo : IFoo
        {
        }

        interface IFoo
        {
        }

        [Test]
        public void IFoo_should_resolve_to_Foo()
        {
            var container = new Container();
            container.Configure(x => x.For<IFoo>().Use<Foo>());

            var foo = container.GetInstance<IFoo>();

            foo.ShouldBeType<Foo>();
        }
    }
}