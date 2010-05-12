using System.Linq;
using Domain;
using Norm;
using Norm.Linq;
using NUnit.Framework;
using TestUtilities;

namespace SimpleTests.IdTests
{
    [TestFixture]
    public class objectId
    {
        [SetUp]
        public void setup()
        {
            Mongo mongo = MongoTestHelper.create_new_database_connection();

            mongo.Database.DropCollection(typeof (Book).Name);

            _book = new Book();
            mongo.GetCollection<Book>().Insert(_book);
        }

        Book _book;

        [Test]
        public void should_read_and_set_id()
        {
            MongoQueryProvider provider = MongoTestHelper.create_query_provider();
            Book book = new MongoQuery<Book>(provider).First();

            book.Id.ShouldBe(_book.Id);
        }

        [Test]
        public void should_set_id_on_insert()
        {
            _book.Id.ShouldNotBe(ObjectId.Empty);
        }
    }
}