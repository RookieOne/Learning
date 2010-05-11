using Norm;
using NUnit.Framework;

namespace Learning_NoRM.Simple
{
    [TestFixture]
    public class book_crud
    {
        #region Setup/Teardown

        [SetUp]
        public void setup()
        {
            _mongo = MongoTestHelper.create_new_database_connection();

            _mongo.Database.DropCollection(typeof (Book).Name);
        }

        #endregion

        Mongo _mongo;

        [Test]
        public void insert_book()
        {
            var book = new Book
                           {
                               Title = "Ender's Game",
                               Author = "Orson Scott Card",
                           };
            _mongo.GetCollection<Book>().Insert(book);

            _mongo.GetCollection<Book>().Count().ShouldBe(1);
        }
    }
}