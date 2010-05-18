using System.ServiceModel;

namespace MyWcfServiceLibrary.Basic
{
    [ServiceContract]
    public interface IBasicService
    {
        [OperationContract]
        string GetMessage();
    }
}