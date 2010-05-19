using System;

namespace MyLearningTests.BasicServices
{
    public class host_basic_service
    {
        ServiceHost _host;

        public void start_host()
        {
            var baseAddress = new Uri("http://localhost:9010/MyWcfServiceLibraryBasic");
            _host = new ServiceHost(typeof(BasicService), baseAddress);

            _host.AddServiceEndpoint(typeof(IBasicService), new WSHttpBinding(), "BasicService");
            _host.Open();
        }

        public void end_host()
        {
            _host.Close();
        }
    }
}