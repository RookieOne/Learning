using System;
using Domain;
using Norm;
using NUnit.Framework;
using TestUtilities;

namespace SimpleTests
{
    [TestFixture]
    public class ids
    {
        [Test]
        public void A_using_objectid()
        {
            Mongo mongo = MongoTestHelper.create_new_database_connection();

            var book = new Book();
            mongo.GetCollection<Book>().Insert(book);

            book.Id.ShouldNotBe(ObjectId.Empty);
        }

        [Test]
        public void B_using_guid_with_identifier_attribute()
        {
            Mongo mongo = MongoTestHelper.create_new_database_connection();

            var movie = new Movie();
            mongo.GetCollection<Movie>().Insert(movie);

            movie.Id.ShouldNotBe(Guid.Empty);
        }
    }
}