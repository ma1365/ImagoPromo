using ImagoPromo.Models;
using System.Collections.Generic;

namespace ImagoPromo.Managers
{
    public interface IFileProcessingManager
    {
        Dictionary<string, List<FileIData>> ProcessPath(string path);
    }
}
