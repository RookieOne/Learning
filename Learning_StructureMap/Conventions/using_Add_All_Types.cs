using Conventions.WhatShouldBeRegistered;
using NUnit.Framework;
using StructureMap;
using TestUtilities.Extensions;

namespace Conventions
{
    [TestFixture]
    public class using_Add_All_Types
    {
        [Test]
        public void should_load_Person_Entity()
        {
            var container = new Container();

            container.Configure(x => x.Scan(s =>
                                                {
                                                    s.TheCallingAssembly();

                                                    s.AddAllTypesOf<IEntity>().NameBy(t => t.Name.Replace("Entity", ""));
                                                }));

            var person = container.GetInstance<IEntity>("Person");

            person.ShouldBeType<PersonEntity>();
        }
    }
}