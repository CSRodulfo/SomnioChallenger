using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Resources.Abstract;
using Resources.Concrete;
using Resources.Utility;

namespace Application.Resources
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ResourceBuilder();
            Boolean fileOK = builder.Create(new DbResourceProvider(),
                summaryCulture: "en-us");

            Console.WriteLine("Created file {0}", fileOK);   
        }
    }
}
