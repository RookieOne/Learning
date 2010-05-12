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
    public class basic_crud_with_Customer_using_map
    {
        [SetUp]
        public void setup()
        {
            _mongo = MongoTestHelper.create_new_database_connection();
            _provider = new MongoQueryProvider(_mongo);

            _mongo.Database.DropCollection(typeof (Customer).Name);
        }

        MongoQueryProvider _provider;
        Mongo _mongo;

        [Test]
        public void delete_customer()
        {
            var customer = new Customer
                               {
                                   Name = "Han Solo"
                               };
            _mongo.GetCollection<Customer>().Insert(customer);

            Customer customerToDelete = new MongoQuery<Customer>(_provider).First();

            _mongo.GetCollection<Customer>().Delete(customerToDelete);

            _mongo.GetCollection<Customer>().Count().ShouldBe(0);
        }

        [Test]
        public void insert_customer()
        {
            var customer = new Customer
                               {
                                   Name = "Han Solo"
                               };
            _mongo.GetCollection<Customer>().Insert(customer);

            _mongo.GetCollection<Customer>().Count().ShouldBe(1);
        }

        [Test]
        public void read_customer()
        {
            var customer = new Customer
                               {
                                   Name = "Han Solo"
                               };
            _mongo.GetCollection<Customer>().Insert(customer);

            new MongoQuery<Customer>(_provider).First().Name.ShouldBe("Han Solo");
        }

        [Test]
        public void update_customer()
        {
            var customer = new Customer
                               {
                                   Name = "Han Solo"
                               };
            _mongo.GetCollection<Customer>().Insert(customer);

            Customer customerToUpdate = new MongoQuery<Customer>(_provider).First();
            customerToUpdate.Name = "Luke Skywalker";

            _mongo.GetCollection<Customer>().Save(customerToUpdate);

            _mongo.GetCollection<Customer>().Count().ShouldBe(1);
            new MongoQuery<Customer>(_provider).First().Name.ShouldBe("Luke Skywalker");
        }
    }
}