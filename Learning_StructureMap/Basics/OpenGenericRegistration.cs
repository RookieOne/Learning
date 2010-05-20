using NUnit.Framework;
using StructureMap;
using TestUtilities.Extensions;

namespace Basics
{
    [TestFixture]
    public class OpenGenericRegistration
    {
        class Book
        {
        }

        interface IRepository<T>
        {
        }

        class Repository<T> : IRepository<T>
        {
        }

        [Test]
        public void IRepositoryT_should_resolve_to_RepositoryT()
        {
            var container = new Container();
            container.Configure(x => x.For(typeof (IRepository<>)).Use(typeof (Repository<>)));

            var repository = container.GetInstance<IRepository<Book>>();

            repository.ShouldBeType<Repository<Book>>();
        }
    }
}