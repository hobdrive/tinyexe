using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Globalization;

namespace TinyExe
{
    public class Tracer
    {
        public static Action<string, string> tracer = null;

        public static void Trace(string comp, string message)
        {
            if (tracer != null)
                tracer(comp, message);
        }
    }

}