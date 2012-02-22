using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCTV.Explorer.IO
{
    public class File: Element
    {
        public Directory Parent { get; set; }

        public File(String name, String fullPath, Directory parent) : base(name, fullPath) 
        {
            Parent = parent;
        }
    }
}
