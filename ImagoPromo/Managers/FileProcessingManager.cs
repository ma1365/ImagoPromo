using ImagoPromo.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace ImagoPromo.Managers
{
    public class FileProcessingManager : IFileProcessingManager
    {
        private Dictionary<string, List<FileIData>> _mappings = new Dictionary<string, List<FileIData>>();
        public Dictionary<string, List<FileIData>> ProcessPath(string path)
        {

            var paths = new List<string>();
            paths.AddRange(Directory.GetDirectories(path));
            paths.AddRange(Directory.GetFiles(path));

            foreach (string p in paths)
            {
                if (File.Exists(p))
                {
                    // This path is a file
                    ProcessFile(p, _mappings);
                }
                else if (Directory.Exists(p))
                {
                    // This path is a directory
                    ProcessDirectory(p);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", path);
                }
            }

            return _mappings;
        }

        private void ProcessDirectory(string path)
        {
            ProcessPath(path);
        }

        private void ProcessFile(string path, Dictionary<string, List<FileIData>> mappings)
        {
            var fileName = Path.GetFileName(path);
            var fileInfo = new FileInfo(path);
            if (!mappings.ContainsKey(fileName))
            {
                mappings[fileName] = new List<FileIData> { new FileIData
                {
                    Name = fileName,
                    Extension = Path.GetExtension(path),
                    Path = path,
                    Size = fileInfo.Length,
                    Created = fileInfo.CreationTime,
                    Updated = fileInfo.LastWriteTime
                } };
            }
            else
            {
                var filePaths = mappings[fileName];
                filePaths.Add(new FileIData
                {
                    Name = fileName,
                    Extension = Path.GetExtension(path),
                    Path = path,
                    Size = fileInfo.Length,
                    Created = fileInfo.CreationTime,
                    Updated = fileInfo.LastWriteTime
                });
            }
        }
    }
}
