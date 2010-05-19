using NUnit.Framework;

namespace MyLearningTests.BasicServiceTests
{
    [TestFixture]
    public class get_message : host_basic_service
    {
        [Test]
        public void should_return_hello_world()
        {
            _proxy.GetMessage().ShouldBe("Hello World");
        }
    }
}