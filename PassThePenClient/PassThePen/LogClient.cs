﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PassThePen
{
    public class LogClient
    {
        private readonly string path;

        public LogClient()
        {
            this.path = GetPath();
        }

        public void Add(string message)
        {

            CreateDirectory();
            string nameFile = GetNameFile();
            string stringLog = "";

            stringLog += DateTime.Now + " - " + message + Environment.NewLine;

            StreamWriter streamWriter = new StreamWriter(path + nameFile, true);
            streamWriter.Write(stringLog);
            streamWriter.Close();

        }

        private string GetNameFile()
        {
            string nameFile;

            nameFile = "log_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".txt";

            return nameFile;
        }

        private void CreateDirectory()
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException(ex.Message);
            }
        }

        private string GetPath()
        {
            string currentDirectory = Environment.CurrentDirectory;
            string direction = ConfigurationManager.AppSettings.Get("Log");
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(currentDirectory, direction)));

            return directory.ToString();
        }
    }
}

