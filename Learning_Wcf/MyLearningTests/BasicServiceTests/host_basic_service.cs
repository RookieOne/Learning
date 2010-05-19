using System;
using System.ServiceModel;
using MyContracts;
using MyProxies;
using MyServices;
using NUnit.Framework;

namespace MyLearningTests.BasicServiceTests
{
    public class host_basic_service
    {
        ServiceHost _host;
        protected IBasicService _proxy;

        [SetUp]
        public void setup()
        {
            start_host();

            _proxy = new BasicServiceProxy();
        }

        [TearDown]
        public void teardown()
        {
            end_host();
        }

        void start_host()
        {
            var baseAddress = new Uri("http://localhost:9010/MyWcfServiceLibraryBasic");
            _host = new ServiceHost(typeof (BasicService), baseAddress);

            _host.AddServiceEndpoint(typeof (IBasicService), new WSHttpBinding(), "BasicService");
            _host.Open();
        }

        void end_host()
        {
            _host.Close();
        }
    }
}