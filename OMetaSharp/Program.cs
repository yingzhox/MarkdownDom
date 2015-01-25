using OMetaSharp.OMetaCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMetaSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //generate OMeta parser itself
            Bootstrapper.BootstrapOMetaCS();
        }
    }
}
