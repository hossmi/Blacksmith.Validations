using Blacksmith.Enumerations;

namespace Blacksmith.Validations.Tests
{
    public class SampleEnumeration : Enumeration
    {
        protected SampleEnumeration(int id, string name) :base(id, name) {}

        public static SampleEnumeration One => new SampleEnumeration(1, "one");
        public static SampleEnumeration Two => new SampleEnumeration(2, "two");
        public static SampleEnumeration Three => new SampleEnumeration(3, "three");
    }
}