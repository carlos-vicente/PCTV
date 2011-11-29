using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PCTV.Explorer.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            IExplorer explorer = new Explorer();
            IEnumerable<FileSystemInfo> contents = null;
            
            Console.WriteLine(explorer.CurrentPath ?? "<nothing>");
            contents = explorer.GetCurrentContents();

            PrintCurrentContents(contents);

            explorer.Open("D:\\");
            Console.WriteLine(explorer.CurrentPath ?? "<nothing>");

            contents = explorer.GetCurrentContents();

            PrintCurrentContents(contents);

            explorer.Open("Btuga downloads");

            contents = explorer.GetCurrentContents();

            PrintCurrentContents(contents);

            //DriveInfo[] drives = DriveInfo.GetDrives();
            //foreach (DriveInfo di in drives.Where(d => d.IsReady))
            //{
            //    Console.WriteLine("{0}", di.Name);
            //    //foreach(var fsi in di.RootDirectory.GetFileSystemInfos()){
            //    //    Console.WriteLine("     {0}", fsi.Name);
            //    //}

                
            //    Console.WriteLine(di.RootDirectory.Parent == null ? "No parent" : di.RootDirectory.Parent.Name);
            //    foreach (var fsi in di.RootDirectory.GetDirectories())
            //    {
            //        Console.WriteLine("     {0}", fsi.Name);
            //    }
            //    foreach (var fsi in di.RootDirectory.GetFiles())
            //    {
            //        Console.WriteLine("     {0}", fsi.Name);
            //    }
            //}
        }

        private static void PrintCurrentContents(IEnumerable<FileSystemInfo> contents)
        {
            foreach (var c in contents)
            {
                Console.WriteLine("- {0}({1})", c.Name, c is DirectoryInfo ? "D" : "F");
            }
        }
    }
}
