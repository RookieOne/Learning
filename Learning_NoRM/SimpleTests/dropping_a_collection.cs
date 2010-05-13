using Domain;
using Norm;
using NUnit.Framework;
using TestUtilities;

namespace SimpleTests
{
    [TestFixture]
    public class dropping_a_collection
    {
        [Test]
        public void should_empty_collection()
        {
            Mongo mongo = MongoTestHelper.create_new_database_connection();

            mongo.GetCollection<Book>().Insert(new Book());

            mongo.Database.DropCollection("Book");

            mongo.GetCollection<Book>().Count().ShouldBe(0);
        }
    }
}