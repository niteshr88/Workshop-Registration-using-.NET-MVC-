using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Common
{
    public static class Logger
    {

        public static void LogFileWrite(string message)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                string logFilePath = "c:\\LogError\\";

                logFilePath = logFilePath + "ProgramLog" + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";

                if (logFilePath.Equals("")) return;

                #region Create the Log file directory if it does not exists 

                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                #endregion

                if (!logFileInfo.Exists)
                {
                    fileStream = logFileInfo.Create();
                }
                else
                {
                    fileStream = new FileStream(logFilePath, FileMode.Append);
                }
                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine(message);
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        public static int LineNumber(this Exception e)
        {

            int linenum = 0;
            try
            {

                linenum = Convert.ToInt32(e.StackTrace.Substring(e.StackTrace.LastIndexOf(":line") + 5));

            }
            catch
            {

                //Stack trace is not available!

            }

            return linenum;

        }
       /* public static void SaveErrorLog(string Source, string Method, Exception ex)
        {
            //string LogPath = ConfigurationManager.AppSettings["LogPath"].ToString();
            //string fileName = "Log_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            //string filePath = LogPath + fileName;
            var path = HttpContext.Current.Server.MapPath("~/LogFiles/Log_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt");

            var type = ex.GetType();
            var errorLineNo = ex.LineNumber();

            try
            {
                if (File.Exists(path))
                {
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
                        writer.WriteLine("Source : " + Source);
                        writer.WriteLine("Method Name : " + Method);
                        writer.WriteLine("Error Line No : " + errorLineNo);
                        writer.WriteLine("Exception Type : " + type);
                        writer.WriteLine("Details: " + ex.Message);
                        writer.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
                        writer.WriteLine();
                        writer.Close();
                    }
                }
                else
                {
                    StreamWriter writer = File.CreateText(path);
                    writer.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
                    writer.WriteLine("Source : " + Source);
                    writer.WriteLine("Method Name : " + Method);
                    writer.WriteLine("Error Line No : " + errorLineNo);
                    writer.WriteLine("Exception Type : " + type);
                    writer.WriteLine("Details: " + ex.Message);
                    writer.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
                    writer.WriteLine();
                    writer.Close();
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }

        public static void SaveErrorLog(string Source, string Method, string ex)
        {
            var path = HttpContext.Current.Server.MapPath("~/LogFiles/Log_" + DateTime.Now.ToString("ddMMMyyyy") + ".txt");

            var type = ex.GetType();
            var errorLineNo = 1;

            try
            {
                if (File.Exists(path))
                {
                    using (StreamWriter writer = new StreamWriter(path, true))
                    {
                        writer.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
                        writer.WriteLine("Source : " + Source);
                        writer.WriteLine("Method Name : " + Method);
                        writer.WriteLine("Error Line No : " + errorLineNo);
                        writer.WriteLine("Exception Type : " + type);
                        writer.WriteLine("Details: " + ex);
                        writer.WriteLine("---------------------------------------------------------------------------------------------------------------------------");
                        writer.WriteLine();
                        writer.Close();
                    }
                }
                else
                {
                    StreamWriter writer = File.CreateText(path);
                    writer.WriteLine(DateTime.Now.ToString("HH:mm:ss tt"));
                    writer.WriteLine("Source : " + Source);
                    writer.WriteLine("Method Name : " + Method);
                    writer.WriteLine("Error Line No : " + errorLineNo);
                    writer.WriteLine("Exception Type : " + type);
                    writer.WriteLine("Details: " + ex);
                    writer.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
                    writer.WriteLine();
                    writer.Close();
                }
            }
            catch (Exception exp)
            {

                throw exp;
            }
        }*/
    }
}
