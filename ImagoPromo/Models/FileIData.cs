using System;

namespace ImagoPromo.Models
{
    public class FileIData
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
