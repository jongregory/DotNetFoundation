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
            ExceptionSamples.AccessNullExamples();
            SafePropertyAccess.Samples();
            SafeCollectionAccess.Samples();

            Console.ReadKey();
        }
    }
}
