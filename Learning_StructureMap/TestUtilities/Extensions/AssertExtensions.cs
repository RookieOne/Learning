using System;
using NUnit.Framework;

namespace TestUtilities.Extensions
{
    public static class AssertExtensions
    {
        public static void ShouldBeType<T>(this object o)
        {
            Assert.IsInstanceOf(typeof (T), o);
        }

        public static void ShouldBeType(this object o, Type type)
        {
            Assert.IsInstanceOf(type, o);
        }

        public static void ShouldBeTheSameInstanceAs<T>(this T expected, T actual)
        {
            Assert.AreSame(expected, actual);
        }

        public static void ShouldBe<T>(this T actual, T expected)
        {
            Assert.AreEqual(expected, actual);
        }
    }
}