using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PCTV.Explorer.IO
{
    public class Directory : Element
    {
        public List<Element> Children { get; set; }
        public virtual Directory Parent { get; set; }

        public Directory()
        {
            Children = new List<Element>();
        }

        public Directory(String name, String fullPath, Directory parent)
            : base(name, fullPath)
        {
            Parent = parent;
            Children = new List<Element>();
        }

        //public IEnumerable<Element> GetContents()
        //{
        //    DirectoryInfo dir = ToDirectoryInfo();

        //    return dir.GetDirectories()
        //        .Where(d => !d.Attributes.HasFlag(FileAttributes.Hidden) && !d.Attributes.HasFlag(FileAttributes.System))
        //        .Select(di => new Directory(di.Name, di.FullName, this))
        //        .Union<Element>(
        //            dir.GetFiles()
        //            .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden) && !f.Attributes.HasFlag(FileAttributes.System))
        //            .Select(fi => new File(fi.Name, fi.FullName, this)));
        //}

        //private DirectoryInfo ToDirectoryInfo()
        //{
        //    DirectoryInfo info = new DirectoryInfo(FullPath);
        //    if (!info.Exists) throw new InvalidOperationException("No such path exists");
        //    return info;
        //}
    }
}
