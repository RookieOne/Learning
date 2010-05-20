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
        [Test]
        public void should_load_IFoo()
        {
            var container = new Container();

            container.Configure(x => x.Scan(s =>
                                                {
                                                    s.TheCallingAssembly();
                                                                                                               
                                                    s.Convention<DefaultConventionScanner>();                                                    
                                                } ));

            // IFoo -> Foo
            // IWhatever -> Whatever
            var foo = container.GetInstance<IFoo>();

            foo.ShouldBeType<Foo>();
        }
    }
}
