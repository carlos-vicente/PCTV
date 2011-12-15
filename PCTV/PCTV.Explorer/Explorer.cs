using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Directory = PCTV.Explorer.IO.Directory;
using System.IO;

namespace PCTV.Explorer
{
    public class Explorer: IExplorer
    {
        private Directory[] _fileStruture;
        private Directory _current;

        public String CurrentPath { get; private set; }

        public Explorer()
        {
            _fileStruture = TransformDirectories(GetRootDirectories()).ToArray();
            CurrentPath = String.Empty;
        }

        public void Open(String name)
        {
            if (_current == null)
            {
                _current = (from di in _fileStruture where di.Name.Equals(name) select di).FirstOrDefault();
                if (_current == null)
                    throw new DirectoryNotFoundException("Invalid drive");

                CurrentPath = _current.FullPath;
                return;
            }

            Directory next = _current.Children.Where(dir => dir.Name.Equals(name)).FirstOrDefault();

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

        public IEnumerable<FileSystemInfo> GetCurrentContents()
        {
            if (_current == null)
            {
                return (from dir in _fileStruture select dir.ToDirectoryInfo());
            }

            IEnumerable<FileSystemInfo> contents = _current.GetContents();

            _current.Children.Clear();
            _current.Children.AddRange(TransformDirectories(
                from fsi in contents
                where fsi is DirectoryInfo
                select fsi as DirectoryInfo
                ));

            return contents;
        }

        private static DirectoryInfo[] GetRootDirectories()
        {
            return (from di in DriveInfo.GetDrives() where di.IsReady select di.RootDirectory).ToArray();
        }

        private static IEnumerable<Directory> TransformDirectories(IEnumerable<DirectoryInfo> directoryInfos)
        {
            return from di in directoryInfos select new Directory(di);
        }
    }
}
