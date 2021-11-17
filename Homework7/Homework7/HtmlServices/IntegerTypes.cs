using System;
using System.Collections.Generic;

namespace Homework7.HtmlServices
{
    public static class IntegerTypes
    {
        private static readonly HashSet<Type> integerTypes = new()
        {
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong)
        };

        public static bool IsIntegerType(this Type type) =>
            integerTypes.Contains(type) || integerTypes.Contains(Nullable.GetUnderlyingType(type));
    }
}