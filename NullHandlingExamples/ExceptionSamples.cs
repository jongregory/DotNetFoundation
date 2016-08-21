using System;

namespace NullHandlingExamples
{
    class ExceptionSamples
    {
        public static void AccessNullExamples()
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

        }
    }
}