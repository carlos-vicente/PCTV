using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCTV.Explorer.IO
{
    public abstract class Element
    {
        public String Name { get; set; }
        public String FullPath { get; set; }

        protected Element() { }

        protected Element(String name, String fullPath)
        {
            Name = name;
            FullPath = fullPath;
        }
    }
}
