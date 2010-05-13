using Learning_CSharp._ExtensionMethods.AssemblyA;
using Learning_CSharp._ExtensionMethods.AssemblyB;
using NUnit.Framework;

namespace Learning_CSharp._ExtensionMethods
{
    [TestFixture]
    public class foo_example
    {
        [Test]
        public void using_bad_foo()
        {
            var foo = new BadFoo();

            // notice that since I called this method I now have a dependency on AssemblyB
            Bar bar = foo.Whatever();
        }

        [Test]
        public void using_good_foo()
        {
            var foo = new GoodFoo();

            // yeah I have to have the same dependency but since it is an extension method
            // it is more of an opt in scenario
            Bar bar = foo.Whatever();
        }
    }
}