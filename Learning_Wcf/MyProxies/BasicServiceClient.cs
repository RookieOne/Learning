using System.ServiceModel;
using MyContracts;

namespace MyProxies
{
    public class BasicServiceClient : IBasicService
    {
        public BasicServiceClient()
        {
            var factory = new ChannelFactory<IBasicService>();

            _service = new ChannelFactory<IBasicService>().CreateChannel();
        }

        readonly IBasicService _service;

        public string GetMessage()
        {
            return _service.GetMessage();
        }
    }
}