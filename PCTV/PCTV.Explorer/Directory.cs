using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PCTV.Explorer.IO
{
    internal class Directory
    {
        public Directory Parent { get; set; }
        public String Name { get; set; }
        public String FullPath { get; set; }
        public List<Directory> Children { get; set; }

        //public IEnumerable<DirectoryInfo> GetDirectories()
        //{
        //    return GetCurrent().GetDirectories();
        //}

        //public IEnumerable<FileInfo> GetFiles()
        //{
        //    return GetCurrent().GetFiles();
        //}

        public Directory()
        {
            Children = new List<Directory>();
        }

        public Directory(DirectoryInfo info) : this()
        {
            Name = info.Name;
            FullPath = info.FullName;
        }

        public IEnumerable<FileSystemInfo> GetContents()
        {
            DirectoryInfo dir = new DirectoryInfo(FullPath);
            if (!dir.Exists)
                throw new InvalidOperationException("No such path exists");

            return dir.GetDirectories()
                .Where(d => !d.Attributes.HasFlag(FileAttributes.Hidden) && !d.Attributes.HasFlag(FileAttributes.System))
                .Union<FileSystemInfo>(
                    dir.GetFiles()
                    .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden) && !f.Attributes.HasFlag(FileAttributes.System)));

            //List<FileSystemInfo> infos = new List<FileSystemInfo>();

            //foreach (var d in dir.GetDirectories())
            //{
            //    if (d.Attributes.HasFlag(FileAttributes.Hidden) | d.Attributes.HasFlag(FileAttributes.System))
            //        continue;
            //    infos.Add(d);
            //}

            //foreach (var d in dir.GetFiles())
            //{
            //    if (d.Attributes.HasFlag(FileAttributes.Hidden) | d.Attributes.HasFlag(FileAttributes.System))
            //        continue;
            //    infos.Add(d);
            //}

            //return infos;
        }

        public DirectoryInfo ToDirectoryInfo()
        {
            DirectoryInfo info = new DirectoryInfo(FullPath);
            if (!info.Exists) throw new InvalidOperationException("No such path exists");
            return info;
        }

        //private DirectoryInfo GetCurrent()
        //{
        //    DirectoryInfo dir = new DirectoryInfo(FullPath);
        //    if (!dir.Exists)
        //        throw new DirectoryNotFoundException();
        //    return dir;
        //}
    }
}
