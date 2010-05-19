using System.ServiceModel;

namespace MyContracts
{
    [ServiceContract]
    public interface IBasicService
    {
        [OperationContract]
        string GetMessage();

        [OperationContract]
        void BadOperation();
    }
}