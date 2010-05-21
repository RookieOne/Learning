using System;
using NUnit.Framework;
using StructureMap;
using TestUtilities.Extensions;

namespace Basics
{
    [TestFixture]
    public class ConstructurArgumentsLazy
    {
        [SetUp]
        public void setup()
        {
            _container = new Container();
            _container.Configure(x =>
                                     {
                                         x.For<IIdProvider>().Use<IdProvider>();
                                         x.For<IBar>().Use<Bar>();
                                         x.For<IFoo>().Use<Foo>()
                                             .Ctor<Func<int>>("getId")
                                             .Is(c => c.GetInstance<IIdProvider>().GetId);
                                     });
        }

        class Bar : IBar
        {
        }

        class Foo : IFoo
        {
            public Foo(Func<int> getId, IBar bar)
            {
                GetId = getId;
                Bar = bar;
            }

            public Func<int> GetId { get; set; }
            public IBar Bar { get; set; }
        }

        interface IBar
        {
        }

        interface IFoo
        {
            Func<int> GetId { get; }
            IBar Bar { get; }
        }

        interface IIdProvider
        {
            int GetId();
        }

        class IdProvider : IIdProvider
        {
            public int GetId()
            {
                return 1;
            }
        }

        IContainer _container;

        [Test]
        public void should_resolve_Bar()
        {
            var foo = _container.GetInstance<IFoo>();

            foo.Bar.ShouldBeType<Bar>();
        }

        [Test]
        public void should_resolve_id()
        {
            var foo = _container.GetInstance<IFoo>();

            foo.GetId().ShouldBe(1);
        }
    }
}