using NUnit.Framework;

namespace MyLearningTests.BasicServices
{
    [TestFixture]
    public class get_message : host_basic_service
    {
        [Test]
        public void should_return_hello_world()
        {
            start_host();

            var proxy = new BasicServiceClient();
            proxy.GetMessage().ShouldBe("Hello World");

            end_host();
        }
    }
}