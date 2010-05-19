using System.ServiceModel;
using MyContracts;

namespace MyServices
{
    public class FighterProvider : IFighterProvider
    {
        public FighterProvider()
        {
            _availableFighters = 3;
        }

        int _availableFighters;

        public void RequestFighterCover(int x, int y)
        {
            if (_availableFighters <= 0)
            {
                var fault = new NoResourceAvailable
                                {
                                    Reason = "No fighters available"
                                };
                throw new FaultException<NoResourceAvailable>(fault);
            }

            _availableFighters--;
        }
    }
}