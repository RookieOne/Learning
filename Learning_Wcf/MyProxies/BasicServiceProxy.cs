using System;
using System.ServiceModel;
using MyContracts;

namespace MyProxies
{
    public class BasicServiceProxy : IBasicService
    {
        public BasicServiceProxy()
        {
            var address = new EndpointAddress("http://localhost:9010/MyWcfServiceLibraryBasic/BasicService");

            var factory = new ChannelFactory<IBasicService>(new WSHttpBinding());

            _service = factory.CreateChannel(address);
        }

        readonly IBasicService _service;

        public string GetMessage()
        {
            return _service.GetMessage();
        }

        public void BadOperation()
        {
            _service.BadOperation();
        }
    }
}