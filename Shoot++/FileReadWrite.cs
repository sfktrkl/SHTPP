using System;
using System.Collections.Generic;
using System.IO;

namespace Shoot
{
    public static class FileReadWrite
    {
        public enum FileCondition
        {
            DirectoryNotExist,
            FileExist,
            FileNotExist,
        }

        public static FileCondition CheckLoginFile(string id, string pw)
        {
            userDirectory = directory + "\\" + id;
            userFile = userDirectory + "\\" + id + ".sht";

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

        public static List<string> ReadLoginFile(string id, string pw)
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

        public static void WriteLoginFile(List<string> inputs, string id, string pw)
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

        public static FileCondition CheckFile(string fileDir, string fileName)
        {
            FileCondition condition;

            if (!Directory.Exists(fileDir))
                condition = FileCondition.DirectoryNotExist;
            else
            {
                if (File.Exists(fileName))
                    condition = FileCondition.FileExist;
                else
                    condition = FileCondition.FileNotExist;
            }

            return condition;
        }

        public static string ReadFile(string fileName)
        {
            string file = userDirectory + "\\" + fileName + ".sfk";

            FileCondition condition = CheckFile(userDirectory, file);

            if (condition == FileCondition.FileExist)
            {
                string text = File.ReadAllText(file);
                return text;
            }

            return null;
        }

        public static string WriteFile(string content, string fileName)
        {
            string file = userDirectory + "\\" + fileName + ".sfk";

            FileCondition condition = CheckFile(userDirectory, file);

            if (condition == FileCondition.DirectoryNotExist)
            {
                Directory.CreateDirectory(userDirectory);
                FileStream fs = File.Create(file);
                fs.Close();
            }
            else if (condition == FileCondition.FileNotExist)
            {
                FileStream fs = File.Create(file);
                fs.Close();
            }

            StreamWriter sw = new StreamWriter(file);
            sw.Write(content);
            sw.Close();

            return file;
        }

        private static string userDirectory;
        private static string userFile;
        private static readonly string directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\My Games\\Shoot++";
    }
}