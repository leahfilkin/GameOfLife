using System;
using System.IO;

namespace GameOfLife.GameOfLifeConsole
{
    public static class FilePathValidator
    {
        public static void CheckFileExists(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"The file at {path} does not exist");
            } 
        }

        public static void CheckFileIsTxt(string path)
        {
            var extension = path.Substring(path.LastIndexOf('.'));
            if (extension != ".txt")
            {
                throw new ArgumentException("We currently only accept .txt files");
            }
        }
    }
}