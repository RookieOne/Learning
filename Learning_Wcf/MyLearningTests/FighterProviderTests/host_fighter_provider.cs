using System;
using System.ServiceModel;
using MyContracts;
using MyServices;

namespace MyLearningTests.FighterProviderTests
{
    public class host_fighter_provider
    {
        ServiceHost _host;

        public void start_host()
        {
            var baseAddress = new Uri("http://localhost:9010/MyWcfServiceLibraryBasic");
            _host = new ServiceHost(typeof (FighterProvider), baseAddress);

            _host.AddServiceEndpoint(typeof (IFighterProvider), new WSHttpBinding(), "FighterProvider");
            _host.Open();
        }

        public void end_host()
        {
            _host.Close();
        }
    }
}