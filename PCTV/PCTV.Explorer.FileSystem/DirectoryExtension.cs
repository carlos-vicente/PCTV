using System;
using System.Collections.Generic;
using System.Linq;
using PCTV.Explorer.IO;
using System.IO;
using Directory = PCTV.Explorer.IO.Directory;
using File = PCTV.Explorer.IO.File;

namespace PCTV.Explorer.FileSystem
{
    internal static class DirectoryExtension
    {
        public static IEnumerable<Element> GetContents(this Directory directory)
        {
            DirectoryInfo dir = new DirectoryInfo(directory.FullPath);
            if (!dir.Exists) throw new InvalidOperationException("No such path exists");

            return dir.GetDirectories()
                .Where(d => !d.Attributes.HasFlag(FileAttributes.Hidden) && !d.Attributes.HasFlag(FileAttributes.System))
                .Select(di => new Directory(di.Name, di.FullName, directory))
                .Union<Element>(
                    dir.GetFiles()
                    .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden) && !f.Attributes.HasFlag(FileAttributes.System))
                    .Select(fi => new File(fi.Name, fi.FullName, directory)));
        }
    }
}
