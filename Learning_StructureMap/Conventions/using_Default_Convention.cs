using Conventions.WhatShouldBeRegistered;
using NUnit.Framework;
using StructureMap;
using StructureMap.Graph;
using TestUtilities.Extensions;

namespace Conventions
{
    [TestFixture]
    public class using_Default_Convention
    {
        [SetUp]
        public void setup()
        {
            _container = new Container();

            _container.Configure(x => x.Scan(s =>
                                                 {
                                                     s.TheCallingAssembly();

                                                     s.Convention<DefaultConventionScanner>();
                                                 }));
        }

        IContainer _container;

        [Test]
        public void should_load_IFoo()
        {
            // IFoo -> Foo
            // IWhatever -> Whatever
            var foo = _container.GetInstance<IFoo>();

            foo.ShouldBeType<Foo>();
        }

        [Test]
        [ExpectedException(typeof (StructureMapException))]
        public void should_not_find_default_generic_repository()
        {
            _container.GetInstance<IRepository<Foo>>();
        }
    }
}