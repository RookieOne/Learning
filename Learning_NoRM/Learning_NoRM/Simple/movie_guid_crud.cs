using System;
using System.Linq;
using Norm;
using Norm.Linq;
using NUnit.Framework;

namespace Learning_NoRM.Simple
{
    [TestFixture]
    public class movie_guid_crud
    {
        [SetUp]
        public void setup()
        {
            _mongo = MongoTestHelper.create_new_database_connection();

            _provider = new MongoQueryProvider(_mongo);

            _mongo.Database.DropCollection(typeof (Movie).Name);
        }

        MongoQueryProvider _provider;
        Mongo _mongo;

        [Test]
        public void delete_movie()
        {
            var movie = new Movie
                            {
                                Title = "Star Wars"
                            };
            _mongo.GetCollection<Movie>().Insert(movie);

            Movie movieToDelete = new MongoQuery<Movie>(_provider).First();

            _mongo.GetCollection<Movie>().Delete(movieToDelete);

            _mongo.GetCollection<Movie>().Count().ShouldBe(0);
        }

        [Test]
        public void insert_movie()
        {
            var movie = new Movie
                            {
                                Title = "Star Wars",
                            };
            _mongo.GetCollection<Movie>().Insert(movie);

            _mongo.GetCollection<Movie>().Count().ShouldBe(1);
        }

        [Test]
        public void insert_movie_should_set_id()
        {
            var movie = new Movie
                            {
                                Title = "Star Wars",
                            };
            _mongo.GetCollection<Movie>().Insert(movie);

            new MongoQuery<Movie>(_provider).First().Id.ShouldNotBe(Guid.Empty);
        }

        [Test]
        public void read_movie()
        {
            var movie = new Movie
                            {
                                Title = "Star Wars"
                            };
            _mongo.GetCollection<Movie>().Insert(movie);

            new MongoQuery<Movie>(_provider).First().Title.ShouldBe("Star Wars");
        }

        [Test]
        public void update_movie()
        {
            var movie = new Movie
                            {
                                Title = "Star Wars"
                            };
            _mongo.GetCollection<Movie>().Insert(movie);

            Movie movieToUpdate = new MongoQuery<Movie>(_provider).First();
            movieToUpdate.Title = "Empire Strikes Back";

            _mongo.GetCollection<Movie>().Save(movieToUpdate);

            _mongo.GetCollection<Movie>().Count().ShouldBe(1);
            new MongoQuery<Movie>(_provider).First().Title.ShouldBe("Empire Strikes Back");
        }
    }
}