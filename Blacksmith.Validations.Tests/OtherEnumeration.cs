using Blacksmith.Enumerations;

namespace Blacksmith.Validations.Tests
{
    public class OtherSampleEnumeration: SampleEnumeration
    {
        private OtherSampleEnumeration(int id, string name) : base(id, name) { }

        public static OtherSampleEnumeration Four => new OtherSampleEnumeration(4, "four");
        public static OtherSampleEnumeration Five => new OtherSampleEnumeration(5, "five");
        public static OtherSampleEnumeration Six => new OtherSampleEnumeration(6, "six");
    }
}