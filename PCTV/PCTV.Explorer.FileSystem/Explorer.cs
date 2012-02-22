using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Directory = PCTV.Explorer.IO.Directory;
using System.IO;
using PCTV.Explorer.IO;

namespace PCTV.Explorer.FileSystem
{
    public class FileSystemExplorer : IExplorer
    {
        private Directory[] _fileStruture;
        private Directory _current;

        public String CurrentPath { get; private set; }

        public FileSystemExplorer()
        {
            _fileStruture = GetRootDirectories();
            CurrentPath = String.Empty;
        }

        public void Open(String name)
        {
            if (_current == null)
            {
                _current = (from di in _fileStruture 
                            where di.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase) 
                            select di).FirstOrDefault();
                if (_current == null)
                    throw new DirectoryNotFoundException("Invalid path");

                CurrentPath = _current.FullPath;
                return;
            }

            Directory next = _current.Children.Where(dir => dir.Name.Equals(name)).FirstOrDefault() as Directory;

            if (next == null)
                throw new DirectoryNotFoundException("Invalid directory");

            _current = next;
            CurrentPath = next.FullPath;
        }

        public void Up()
        {
            if(_current == null){
                return;
            }

            _current = _current.Parent;
            CurrentPath = _current != null ? _current.FullPath : String.Empty;
        }

        public IEnumerable<Element> GetCurrentContents()
        {
            if (_current == null)
            {
                return _fileStruture.ToList<Element>();
            }

            IEnumerable<Element> contents = _current.GetContents();

            _current.Children.Clear();
            _current.Children.AddRange(contents);

            return contents;
        }

        private static Drive[] GetRootDirectories()
        {
            return (from di in DriveInfo.GetDrives() where di.IsReady select new Drive(di.RootDirectory.Name)).ToArray();
        }

        //private static IEnumerable<Directory> TransformDirectories(IEnumerable<DirectoryInfo> directoryInfos)
        //{
        //    return from di in directoryInfos select new Directory { Name = di.Name, FullPath = di.FullName };
        //}
    }
}
