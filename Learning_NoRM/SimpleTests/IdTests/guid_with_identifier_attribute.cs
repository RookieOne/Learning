using System;
using System.Linq;
using Domain;
using Norm;
using Norm.Linq;
using NUnit.Framework;
using TestUtilities;

namespace SimpleTests.IdTests
{
    [TestFixture]
    public class guid_with_identifier_attribute
    {
        [SetUp]
        public void setup()
        {
            Mongo mongo = MongoTestHelper.create_new_database_connection();

            mongo.Database.DropCollection(typeof (Movie).Name);

            _movie = new Movie();
            mongo.GetCollection<Movie>().Insert(_movie);
        }

        Movie _movie;

        [Test]
        public void should_read_and_set_id()
        {
            MongoQueryProvider provider = MongoTestHelper.create_query_provider();
            Movie movie = new MongoQuery<Movie>(provider).First();

            movie.Id.ShouldBe(_movie.Id);
        }

        [Test]
        public void should_set_id_on_insert()
        {
            _movie.Id.ShouldNotBe(Guid.Empty);
        }
    }
}