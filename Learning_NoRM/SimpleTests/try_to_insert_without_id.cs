using Norm;
using NUnit.Framework;
using TestUtilities;

namespace SimpleTests
{
    [TestFixture]
    public class try_to_insert_without_id
    {
        class Foo
        {
        }

        [Test]
        [ExpectedException(typeof (MongoException))]
        public void should_throw_exception_since_no_id_supplied()
        {
            Mongo mongo = MongoTestHelper.create_new_database_connection();

            var foo = new Foo();
            mongo.GetCollection<Foo>().Insert(foo);
        }
    }
}