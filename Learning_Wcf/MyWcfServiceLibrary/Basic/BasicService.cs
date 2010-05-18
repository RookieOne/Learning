namespace MyWcfServiceLibrary.Basic
{
    public class BasicService : IBasicService
    {
        public string GetMessage()
        {
            return "Hello World";
        }
    }
}