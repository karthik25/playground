/*
 * Some more changes
 *
 * */
using System;

namespace TestConsoleApp
{
    public class Equatables
    {
        public static void Main(string[] args)
        {
            var instance1 = new SchemaVersion { MajorVersion = 1, MinorVersion = 0, ScriptVersion = 1 };
            var instance2 = new SchemaVersion { MajorVersion = 2, MinorVersion = 0, ScriptVersion = 2 };
            var instance3 = new SchemaVersion { MajorVersion = 1, MinorVersion = 0, ScriptVersion = 1 };

            Console.WriteLine(instance1.Equals(instance2));
            Console.WriteLine(instance1.Equals(instance3));
        }
    }

    public class SchemaVersion : IEquatable<SchemaVersion>
    {
        public short MajorVersion { get; set; }
        public short MinorVersion { get; set; }
        public short ScriptVersion { get; set; }

        public bool Equals(SchemaVersion other)
        {
            if (MajorVersion != other.MajorVersion)
                return false;
            if (MinorVersion != other.MinorVersion)
                return false;
            return ScriptVersion == other.ScriptVersion;
        }
    }
}
