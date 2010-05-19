using System;
using System.Threading;
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
            Thread.Sleep(TimeSpan.FromMilliseconds(10));
            throw new Exception("Bad Operation");
        }
    }
}