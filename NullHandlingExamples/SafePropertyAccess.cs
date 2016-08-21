using System;

namespace NullHandlingExamples
{
    class SafePropertyAccess
    {
        public static void Samples()
        {
            var classWithNulls = new ClassWithNulls();

            #region 'AS' operator

            //https://msdn.microsoft.com/en-us/library/cscsdfbt.aspx

            var asOperator = classWithNulls.IamNull as string;
            Console.WriteLine("Null is returned by as with no exception : " + asOperator);

            #endregion

            #region Convert Class

            // https://msdn.microsoft.com/en-us/library/system.convert(v=vs.110).aspx
            var convertToString = Convert.ToString(classWithNulls.IamNull);
            Console.WriteLine("Convert Class returns empty string if null no exception : " + convertToString);

            #endregion

            #region '??' coalesce operator

            //https://msdn.microsoft.com/en-GB/library/ms173224.aspx
            var coalesce = classWithNulls.IamNull ?? "DefaultValueIfNull";
            Console.WriteLine("DefaultValue is returned if null : " + coalesce);

            #endregion

            #region '?:' Conditional Operator 

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

            #endregion

            #region Extension Method

            // https://msdn.microsoft.com/en-gb/library/bb383977.aspx
            var extensionMethod = classWithNulls.IamNull.ToStringOrEmpty();
            Console.WriteLine("String Empty is returned by as with no exception : " + extensionMethod);

            #endregion

        }
    }
}