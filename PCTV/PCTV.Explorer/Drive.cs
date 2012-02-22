using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCTV.Explorer.IO
{
    public class Drive : Directory
    {
        public override Directory Parent
        {
            get { return base.Parent; }
            set
            {
                if (value != null)
                    throw new ArgumentException("A drive cannot have a parent directory");
            }
        }

        public Drive(String name) : base(name, name, null) { }
    }
}
