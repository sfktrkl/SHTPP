using System;
using System.Collections.Generic;
using System.IO;

namespace Shooting__
{
    public class FileReadWrite
    {
        public FileReadWrite(string id, string pw)
        {
            this.userDirectory = directory + "\\" + id;
            this.userFile = userDirectory + "\\" + id + ".sht";
        }

        public enum FileCondition
        {
            DirectoryNotExist,
            FileExist,
            FileNotExist,
        }

        public FileCondition CheckFile()
        {
            FileCondition condition;

            if (!Directory.Exists(userDirectory))
                condition = FileCondition.DirectoryNotExist;
            else
            {
                if (File.Exists(userFile))
                    condition = FileCondition.FileExist;
                else
                    condition = FileCondition.FileNotExist;
            }

            return condition;
        }

        public List<string> ReadFile()
        {
            List<string> read = new List<string>();
            // Open the stream and read it back.
            string content = FileEncrypterDecrypter.FileDecrypt(userFile);

            string line;
            StringReader sr = new StringReader(content);
            while ((line = sr.ReadLine()) != null)
            {
                read.Add(line);
            }

            return read;
        }

        public void WriteFile(List<string> inputs)
        {
            // Create the file.
            Directory.CreateDirectory(userDirectory);
            FileStream fs = File.Create(userFile);
            fs.Close();

            StringWriter sw = new StringWriter();

            // Add some information to the file.
            foreach (string input in inputs)
                sw.WriteLine(HashGenerator.GetHash(input));

            sw.Close();

            FileEncrypterDecrypter.FileEncrypt(sw.ToString(), userFile);
        }

        private readonly string userDirectory;
        private readonly string userFile;
        private readonly string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Shoot++";
    }
}