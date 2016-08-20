using System.Collections.Generic;

namespace NullHandlingExamples
{
    public class ClassWithNulls
    {
        public ClassWithNulls()
        {
            SampleDictionary = new Dictionary<string, string> { { Constants.NullValueKey, null } };
        }
        public object IamNull { get; set; }
        public Dictionary<string, string> SampleDictionary { get; set; }
    }
}