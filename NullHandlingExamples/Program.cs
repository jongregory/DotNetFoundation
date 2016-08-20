using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullHandlingExamples
{
    class Program
    {
        static void Main(string[] args)
        {


            var sample = new Sample();

            #region Example Property Access ToString Exception

            try
            {
                var s = sample.IamNull.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Property Access Exception Thrown : " + ex.Message);
            }

            #endregion

            #region Dictionary Access ToString Exception

            try
            {
                var s = sample.SampleDictionary[Constants.NullValueKey].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Missing Dictionary Access Exception Thrown : " + ex.Message);
            }

            #endregion

            #region null check samples

            // 'AS' operator
            //https://msdn.microsoft.com/en-us/library/cscsdfbt.aspx
            var asOperator = sample.IamNull as string;
            Console.WriteLine("Null is returned by as with no exception : " + asOperator);

            // '??' coalesce operator
            //https://msdn.microsoft.com/en-GB/library/ms173224.aspx
            var coalesce  = sample.IamNull ?? "DefaultValueIfNull";
            Console.WriteLine(coalesce);

            // '?:' Conditional Operator 
            //https://msdn.microsoft.com/en-gb/library/ty67wk28.aspx

            var conditional = sample.IamNull != null
                ? sample.IamNull.ToString()
                : "DefaultValueIfNull";
            Console.WriteLine(conditional);

            // C# 6 and later null propagation operator
            //https://msdn.microsoft.com/en-GB/library/dn986595.aspx

            
            var conditionalCSharp6 = sample.IamNull?.ToString();
            Console.WriteLine("Null is propagated and returned without an Exception" + conditionalCSharp6);

            // Can be combined with Coalesce
            var conditionalCSharp6DefaultValue = sample.IamNull?.ToString() ?? "DefaultValueIfNull";
            Console.WriteLine("Default Value Returned without an Exception" + conditionalCSharp6DefaultValue);

            // Extension Method
            var extensionMethod = sample.IamNull.ToStringOrEmpty();
            Console.WriteLine("String Empty is returned by as with no exception : " + extensionMethod);

            #endregion

            Console.ReadKey();
        }

        public class Sample
        {
            public Sample()
            {
                SampleDictionary = new Dictionary<string, string> {{Constants.NullValueKey, null}};
            }
            public object IamNull { get; set; }
            public Dictionary<string, string> SampleDictionary { get; set; }
        }

        public static class Constants 
        {
            public static string NullValueKey = "NullValueKey";
        }
    }
}
