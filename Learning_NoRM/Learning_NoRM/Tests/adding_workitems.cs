using System.Linq;
using Norm;
using Norm.Linq;
using NUnit.Framework;

namespace Learning_NoRM.Tests
{
    [TestFixture]
    public class adding_workitems
    {
        [Test]
        public void can_add_workitem()
        {
            var mongo = new Mongo("test", "localhost", "27017", "");

            var provider = new MongoQueryProvider(mongo);

            provider.DB.DropCollection(typeof (WorkItem).Name);

            var workitem = new WorkItem
                               {
                                   Title = "Title"
                               };
            provider.DB.GetCollection<WorkItem>().Insert(workitem);

            new MongoQuery<WorkItem>(provider).Count().ShouldBe(1);
        }
    }
}