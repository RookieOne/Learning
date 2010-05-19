using System.ServiceModel;

namespace MyContracts
{
    [ServiceContract]
    public interface IFighterProvider
    {
        [OperationContract]
        [FaultContract(typeof(NoResourceAvailable))]
        void RequestFighterCover(int x, int y);
    }
}