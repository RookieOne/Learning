using System;
using Norm;
using NUnit.Framework;
using TestUtilities;

namespace SimpleTests
{
    [TestFixture]
    public class objectid_not_labeled_as_id
    {
        class Foo
        {
            [MongoIdentifier]
            public Guid Id { get; set; }
            public ObjectId Whatever { get; set; }
        }

        [Test]
        public void should_not_set_properties_of_ObjectId_if_not_named_Id()
        {
            Mongo mongo = MongoTestHelper.create_new_database_connection();

            var foo = new Foo();
            mongo.GetCollection<Foo>().Insert(foo);

            foo.Whatever.ShouldBe(null);
        }
    }
}