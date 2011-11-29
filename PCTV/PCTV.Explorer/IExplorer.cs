using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PCTV.Explorer
{
    public interface IExplorer
    {
        String CurrentPath { get; }
        void Open(String name);
        void Up();
        IEnumerable<FileSystemInfo> GetCurrentContents();
    }
}
