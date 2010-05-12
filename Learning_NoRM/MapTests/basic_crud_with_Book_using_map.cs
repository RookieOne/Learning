using System.Linq;
using Domain;
using Norm;
using Norm.Linq;
using NUnit.Framework;
using TestUtilities;

namespace MapTests
{
    [TestFixture]
    public class basic_crud_with_Book_using_map
    {
        [SetUp]
        public void setup()
        {
            _mongo = MongoTestHelper.create_new_database_connection();
            _provider = new MongoQueryProvider(_mongo);

            _mongo.Database.DropCollection(typeof (Book).Name);
        }

        MongoQueryProvider _provider;
        Mongo _mongo;

        [Test]
        public void delete_book()
        {
            var book = new Book
                           {
                               Title = "Ender's Game",
                               Author = "Orson Scott Card",
                           };
            _mongo.GetCollection<Book>().Insert(book);

            Book bookToDelete = new MongoQuery<Book>(_provider).First();

            _mongo.GetCollection<Book>().Delete(bookToDelete);

            _mongo.GetCollection<Book>().Count().ShouldBe(0);
        }

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

        [Test]
        public void insert_book_should_set_id()
        {
            var book = new Book
                           {
                               Title = "Ender's Game",
                               Author = "Orson Scott Card",
                           };
            _mongo.GetCollection<Book>().Insert(book);

            new MongoQuery<Book>(_provider).First().Id.ShouldNotBe(ObjectId.Empty);
        }

        [Test]
        public void read_book()
        {
            var book = new Book
                           {
                               Title = "Ender's Game",
                               Author = "Orson Scott Card",
                           };
            _mongo.GetCollection<Book>().Insert(book);

            new MongoQuery<Book>(_provider).First().Title.ShouldBe("Ender's Game");
        }

        [Test]
        public void update_book()
        {
            var book = new Book
                           {
                               Title = "Ender's Game",
                               Author = "Orson Scott Card",
                           };
            _mongo.GetCollection<Book>().Insert(book);

            Book bookToUpdate = new MongoQuery<Book>(_provider).First();
            bookToUpdate.Title = "Hidden Empire";

            _mongo.GetCollection<Book>().Save(bookToUpdate);

            _mongo.GetCollection<Book>().Count().ShouldBe(1);
            new MongoQuery<Book>(_provider).First().Title.ShouldBe("Hidden Empire");
        }
    }
}