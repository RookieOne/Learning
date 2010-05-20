using Conventions.Conventions;
using Conventions.WhatShouldBeRegistered;
using NUnit.Framework;
using StructureMap;
using TestUtilities.Extensions;

namespace Conventions
{
    [TestFixture]
    public class using_Controller_Convention
    {
        IContainer _container;

        [SetUp]
        public void setup()
        {
            _container = new Container();
            _container.Configure(x => x.Scan(s =>
                                                 {
                                                     s.TheCallingAssembly();

                                                     s.Convention<ControllerConvention>();
                                                 }));
        }

        [Test]
        public void should_use_register_a_single_controller()
        {
            var count = _container.GetAllInstances<IController>().Count;

            count.ShouldBe(1);
        }

        [Test]
        public void should_register_controller_for_person()
        {
            var controller = _container.GetInstance<IController>("Person");

            controller.ShouldBeType<PersonController>();
        }
    }
}