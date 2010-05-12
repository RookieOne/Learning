using System;
using System.Linq;
using Domain;
using Norm;
using Norm.Linq;
using NUnit.Framework;
using TestUtilities;

namespace MapTests
{
    [TestFixture]
    public class customer_id_tests
    {
        [SetUp]
        public void setup()
        {
            Mongo mongo = MongoTestHelper.create_new_database_connection();

            mongo.Database.DropCollection(typeof (Customer).Name);

            _customer = new Customer();
            mongo.GetCollection<Customer>().Insert(_customer);
        }

        Customer _customer;

        [Test]
        public void should_read_and_set_id()
        {
            MongoQueryProvider provider = MongoTestHelper.create_query_provider();
            Customer customer = new MongoQuery<Customer>(provider).First();

            customer.Id.ShouldBe(_customer.Id);
        }

        [Test]
        public void should_set_id()
        {
            _customer.Id.ShouldNotBe(Guid.Empty);
        }
    }
}