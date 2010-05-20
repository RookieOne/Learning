using NUnit.Framework;
using StructureMap;
using TestUtilities.Extensions;

namespace Basics
{
    [TestFixture]
    public class OpenGenericWithClosedGenericAlternative
    {
        [SetUp]
        public void setup()
        {
            _container = new Container();
            _container.Configure(x =>
                                     {
                                         x.For(typeof (IRepository<>)).Use(typeof (Repository<>));
                                         x.For<IRepository<Customer>>().Use<CustomerRepository>();
                                     });
        }

        IContainer _container;

        class Book
        {
        }

        class Customer
        {
        }

        class CustomerRepository : IRepository<Customer>
        {
        }

        interface IRepository<T>
        {
        }

        class Repository<T> : IRepository<T>
        {
        }

        [Test]
        public void IRepository_book_should_resolve_to_Repository_book()
        {
            var repository = _container.GetInstance<IRepository<Book>>();

            repository.ShouldBeType<Repository<Book>>();
        }

        [Test]
        public void IRepository_customer_should_resolve_to_Customer_Repository()
        {
            var repository = _container.GetInstance<IRepository<Customer>>();

            repository.ShouldBeType<CustomerRepository>();
        }
    }
}