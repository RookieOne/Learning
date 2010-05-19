using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using MyContracts;
using MyServices;
using NUnit.Framework;

namespace MyLearningTests.BasicServiceTests
{
    [TestFixture]
    public class basic_service_tests
    {
        [Test]
        public void self_hosting_with_config()
        {
            var baseAddress = new Uri("http://localhost:9010/MyWcfServiceLibraryBasic");
            var selfHost = new ServiceHost(typeof (BasicService), baseAddress);

            selfHost.AddServiceEndpoint(typeof (IBasicService), new WSHttpBinding(), "BasicService");

            var behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(behavior);

            selfHost.Open();

            selfHost.Close();
        }
    }
}