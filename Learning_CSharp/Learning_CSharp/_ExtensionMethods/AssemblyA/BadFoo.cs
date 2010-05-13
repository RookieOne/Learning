using Learning_CSharp._ExtensionMethods.AssemblyB;

namespace Learning_CSharp._ExtensionMethods.AssemblyA
{
    public class BadFoo
    {
        public Bar Whatever()
        {            
            return null;
        }
    }

    // this is a method begging to be made an extension method
    // because it adds a dependency to the AssemblyB namespace
}