using System.ServiceModel;
using NUnit.Framework;

namespace MyLearningTests.BasicServiceTests
{
    [TestFixture]
    public class bad_operation : host_basic_service
    {
        [Test]
        [ExpectedException(typeof(CommunicationObjectFaultedException))]
        public void should_throw_communication_exception()
        {
            try
            {
                _proxy.BadOperation();
            }
            catch
            {
            }

            _proxy.BadOperation();
        }

        [Test]
        [ExpectedException(typeof(FaultException))]
        public void should_not_throw_communication_exception()
        {
            try
            {
                _proxy.BadOperation();
            }
            catch
            {
            }

            create_proxy();

            _proxy.BadOperation();
        }

        [Test]
        [ExpectedException(typeof (FaultException))]
        public void should_throw_fault_exception()
        {
            _proxy.BadOperation();
        }
    }
}