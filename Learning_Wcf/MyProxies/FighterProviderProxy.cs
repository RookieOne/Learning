using System.ServiceModel;
using MyContracts;

namespace MyProxies
{
    public class FighterProviderProxy : IFighterProvider
    {
        public FighterProviderProxy()
        {
            var address = new EndpointAddress("http://localhost:9010/MyWcfServiceLibraryBasic/FighterProvider");

            var factory = new ChannelFactory<IFighterProvider>(new WSHttpBinding());

            _service = factory.CreateChannel(address);
        }

        readonly IFighterProvider _service;

        public void RequestFighterCover(int x, int y)
        {
            _service.RequestFighterCover(x, y);
        }
    }
}