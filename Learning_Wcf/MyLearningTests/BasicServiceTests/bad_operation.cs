using System;
using System.ServiceModel;
using NUnit.Framework;

namespace MyLearningTests.BasicServiceTests
{
    [TestFixture]
    public class bad_operation : host_basic_service
    {
        [Test]
        [ExpectedException(typeof (FaultException))]
        public void should_throw_fault_exception()
        {
            _proxy.BadOperation();
        }

        [Test]
        public void test()
        {
            try
            {
                _proxy.BadOperation();
            }
            catch (Exception)
            {
            }

            try
            {
                _proxy.BadOperation();
            }
            catch (Exception)
            {
            }

            try
            {
                _proxy.BadOperation();
            }
            catch (Exception)
            {
            }
        }
    }
}