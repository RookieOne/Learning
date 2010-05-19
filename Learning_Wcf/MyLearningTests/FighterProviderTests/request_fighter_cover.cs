using System.ServiceModel;
using MyContracts;
using MyProxies;
using NUnit.Framework;

namespace MyLearningTests.FighterProviderTests
{
    [TestFixture]
    public class request_fighter_cover : host_fighter_provider
    {
        [SetUp]
        public void setup()
        {
            start_host();

            _proxy = new FighterProviderProxy();
        }

        [TearDown]
        public void teardown()
        {
            end_host();
        }

        IFighterProvider _proxy;

        [Test]
        [ExpectedException(typeof(FaultException<NoResourceAvailable>))]
        public void no_fighters_available()
        {
            _proxy.RequestFighterCover(3, 5);
            _proxy.RequestFighterCover(3, 5);
            _proxy.RequestFighterCover(3, 5);
            _proxy.RequestFighterCover(3, 5);
        }

        [Test]
        [ExpectedException(typeof(FaultException<NoResourceAvailable>))]
        public void no_fighters_available_second_request()
        {
            _proxy.RequestFighterCover(3, 5);
            _proxy.RequestFighterCover(3, 5);
            _proxy.RequestFighterCover(3, 5);
            _proxy.RequestFighterCover(3, 5);
            _proxy.RequestFighterCover(3, 5);
        }

        [Test]
        public void valid_request()
        {
            _proxy.RequestFighterCover(3, 5);
        }
    }
}