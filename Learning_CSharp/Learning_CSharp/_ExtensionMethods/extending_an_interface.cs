using NUnit.Framework;

namespace Learning_CSharp._ExtensionMethods
{
    [TestFixture]
    public class extending_an_interface
    {
        public void can_extend_an_interface()
        {
            var a = new A();

            a.SayHelloWorld();

            a.Message.ShouldBe("Hello World");

            var b = new B();

            b.SayHelloWorld();

            b.Message.ShouldBe("Hello World");
        }
    }

    public interface IFoo
    {
        string Message { get; set; }
    }

    public class A : IFoo
    {
        public string Message { get; set; }
    }

    public class B : IFoo
    {
        public string Message { get; set; }
    }

    public static class ExtendIFoo
    {
        public static void SayHelloWorld(this IFoo foo)
        {
            foo.Message = "Hello World";
        }
    }
}