# ImagoPromo

File Equals. How can we determine if two files are equal? We can compare lengths, dates created and modified. But there is no way to know if the contents are the same unless we test them. We demonstrate a method that compares two files for equality.
Example. The simplest way to check two files for equal contents is to use File.ReadAllBytes on each file and then compare the result arrays. If the arrays have the same length, each byte must be compared for accurate results.
However:
If the arrays have different lengths, we know the files are not equal.

File.ReadAllBytes
Note:
The output of this program will depend on the contents of the two files. Please change the paths in Main().

Based on: .NET (2018)

C# program that uses FileEquals

using System;
using System.IO;

class Program
{
    static bool FileEquals(string path1, string path2)
    {
        byte[] file1 = File.ReadAllBytes(path1);
        byte[] file2 = File.ReadAllBytes(path2);
        if (file1.Length == file2.Length)
        {
            for (int i = 0; i < file1.Length; i++)
            {
                if (file1[i] != file2[i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

    static void Main()
    {
        bool a = FileEquals("C:\\stage\\htmlmeta",
            "C:\\stage\\htmlmeta-aspnet");

        bool b = FileEquals("C:\\stage\\htmllink",
            "C:\\stage\\htmlmeta-aspnet");

        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}

Output

True
False
If the common case in your program is that the files are not equal, then using a FileInfo struct and the Length property to compare lengths first would be faster. The file contents would not be read into memory in that case.
However:
If the common case is that the files are equal, the above version would be faster, because the arrays are needed.

FileInfo Length
FileInfo
Usage. What sort of use does this method have? Let's say you are trying to update a directory of files but some files may not be different. Instead of rewriting files, you can test them for equality first.
So:
If they are equal, you can just do nothing. Reading in a file is a lot faster than writing out a file.

Therefore:
In this use case, this FileEquals method can significantly improve performance.

Summary. We looked at an implementation of a file content comparison method. You can guess whether two files are equal by testing their dates and lengths. But you cannot know if every single byte is equal unless you test every single byte.
And:
Hash computations can give virtually unique file identifiers. But this is not advantageous here. We still need to read every byte.

