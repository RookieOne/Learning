using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using NUnit.Framework;

namespace MyWcfServiceLibrary.Basic
{
    [TestFixture]
    public class basic_service_tests
    {
        [Test]
        public void self_host()
        {
            var host = new ServiceHost(typeof (BasicService));

            host.Open();

            host.Close();
        }

        [Test]
        public void self_hosting_with_config()
        {
            var baseAddress = new Uri("http://localhost:8000/MyWcfServiceLibraryBasic/BasicService");
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