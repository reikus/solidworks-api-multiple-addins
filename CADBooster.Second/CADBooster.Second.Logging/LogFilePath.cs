using System;
using System.IO;
using CADBooster.Second.Logging.Exceptions;
using NDepend.Path;

namespace CADBooster.Second.Logging
{
    internal class LogFilePath
    {
        private static readonly Logger Log = Logger.GetLogger(nameof(LogFilePath));

        /// <summary>
        /// Extension of text log file.
        /// </summary>
        public static string FileExtension = ".txt";

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="path"></param>
        public LogFilePath(string path)
        {
            CheckThatPathIsValid(path);
            CheckThatExtensionIsCorrect(path, FileExtension);

            Path = path;
        }
        
        /// <summary>
        /// Path to the file or directory
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Whether the file/directory exists.
        /// </summary>
        public bool Exists => File.Exists(Path);
        
        /// <summary>
        /// Check if the path is a valid file path
        /// </summary>
        /// <param name="path"></param>
        private static void CheckThatPathIsValid(string path)
        {
            if (path.IsValidFilePath()) return;

            Log.Error("File path is not valid", nameof(CheckThatPathIsValid));
            throw new LogFilePathInvalid();
        }
        
        /// <summary>
        /// Make sure the extension in the path is one of the allowed extensions.
        /// Leave allowed null or empty to allow every extension.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="allowedExtension"></param>
        private void CheckThatExtensionIsCorrect(string path, string allowedExtension)
        {
            if (string.IsNullOrEmpty(allowedExtension)) return;
            string extension = System.IO.Path.GetExtension(path.ToLower());

            if (allowedExtension != extension)
            {
                Log.Error("File extension is not correct, path = " + path + ". Extension should be: " + allowedExtension, nameof(CheckThatExtensionIsCorrect));
                throw new LogFileExtensionInvalid();
            }
        }

        public override bool Equals(object otherObject)
        {
            if (otherObject == null || otherObject.GetType() != typeof(LogFilePath))
                return false;

            return Equals((LogFilePath) otherObject);
        }

        protected bool Equals(LogFilePath other)
        {
            return string.Equals(Path, other.Path, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return (Path != null ? Path.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return Path;
        }
    }
}
