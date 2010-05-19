using MyContracts;

namespace MyServices
{
    public class BasicService : IBasicService
    {
        public string GetMessage()
        {
            return "Hello World";
        }
    }
}