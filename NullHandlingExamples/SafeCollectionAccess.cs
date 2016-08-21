using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullHandlingExamples
{
    public class SafeCollectionAccess
    {

        public static void Samples()
        {
            var classWithNulls = new ClassWithNulls();

            #region Dictionary Access


            // When accessing a collection with a key it is best practice to check if the key exists
            // Remember the value could be null

            //Key does not exist

            if (classWithNulls.SampleDictionary.ContainsKey(Constants.MissingKey))
            {
                Console.WriteLine("Key Does Not Exist");
            }

            //Key exists with null value

            if (classWithNulls.SampleDictionary.ContainsKey(Constants.MissingKey))
            {
                var value = classWithNulls.SampleDictionary[Constants.NullValueKey];

                Console.WriteLine("Key Exist With Null Value : " + value);

                //Need to use a safe accessor from SafePropertyAccess.cs

                var valueToString = classWithNulls.SampleDictionary[Constants.NullValueKey]?.ToString() ?? "DefaultValue";

                Console.WriteLine("Null Value safe Access: " + valueToString);
            }

            #endregion
        }
    }
}
