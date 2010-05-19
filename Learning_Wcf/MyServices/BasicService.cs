using System;
using MyContracts;

namespace MyServices
{
    public class BasicService : IBasicService
    {
        public string GetMessage()
        {
            return "Hello World";
        }

        public void BadOperation()
        {
            throw new Exception("Bad Operation");
        }
    }
}