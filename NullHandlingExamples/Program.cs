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


            var classWithNulls = new ClassWithNulls();

            #region Example Property Access ToString Exception

            try
            {
                var s = classWithNulls.IamNull.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Property Access Exception Thrown : " + ex.Message);
            }

            #endregion

            #region Dictionary Access ToString Exception

            try
            {
                var s = classWithNulls.SampleDictionary[Constants.NullValueKey].ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Missing Dictionary Access Exception Thrown : " + ex.Message);
            }

            #endregion

            #region null check before ToString samples

            // 'AS' operator
            //https://msdn.microsoft.com/en-us/library/cscsdfbt.aspx
            var asOperator = classWithNulls.IamNull as string;
            Console.WriteLine("Null is returned by as with no exception : " + asOperator);

            // Convert Class
            // https://msdn.microsoft.com/en-us/library/system.convert(v=vs.110).aspx
            var convertToString = Convert.ToString(classWithNulls.IamNull);
            Console.WriteLine("Convert Class returns empty string if null no exception : " + convertToString);


            // '??' coalesce operator
            //https://msdn.microsoft.com/en-GB/library/ms173224.aspx
            var coalesce  = classWithNulls.IamNull ?? "DefaultValueIfNull";
            Console.WriteLine("DefaultValue is returned if null : " + coalesce);

            // '?:' Conditional Operator 
            //https://msdn.microsoft.com/en-gb/library/ty67wk28.aspx

            // ReSharper disable once MergeConditionalExpression
            var conditional = classWithNulls.IamNull != null
                ? classWithNulls.IamNull.ToString()
                : "DefaultValueIfNull";
            Console.WriteLine("DefaultValue is returned if null : " + conditional);

            // C# 6 and later null propagation operator
            //https://msdn.microsoft.com/en-GB/library/dn986595.aspx

            
            var conditionalCSharp6 = classWithNulls.IamNull?.ToString();
            Console.WriteLine("Null is propagated and returned without an Exception" + conditionalCSharp6);

            // Can be combined with Coalesce
            var conditionalCSharp6DefaultValue = classWithNulls.IamNull?.ToString() ?? "DefaultValueIfNull";
            Console.WriteLine("Default Value Returned without an Exception" + conditionalCSharp6DefaultValue);

            // Extension Method
            // https://msdn.microsoft.com/en-gb/library/bb383977.aspx
            var extensionMethod = classWithNulls.IamNull.ToStringOrEmpty();
            Console.WriteLine("String Empty is returned by as with no exception : " + extensionMethod);

            #endregion

            Console.ReadKey();
        }
    }
}
