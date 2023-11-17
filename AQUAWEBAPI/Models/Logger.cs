using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AQUAWEBAPI.Models
{
    public class Logger
    {
        public void writeLog(string strValue)
        {
            try
            {
                //Logfile
                string path = System.Configuration.ConfigurationManager.AppSettings["logfilepath"];
                StreamWriter sw;
                if (!File.Exists(path))
                { sw = File.CreateText(path); }
                else
                { sw = File.AppendText(path); }

                LogWrite(strValue, sw);

                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {

            }
        }

        

        private static void LogWrite(string logMessage, StreamWriter w)
        {
            w.WriteLine("{0}", logMessage);
            w.WriteLine("----------------------------------------");
        }
        
        public void writeDataLog(string strValue)
        {
            try
            {
                //Logfile
                string path = System.Configuration.ConfigurationManager.AppSettings["datalogpath"];
                StreamWriter sw;
                if (!File.Exists(path))
                { sw = File.CreateText(path); }
                else
                { sw = File.AppendText(path); }

                DataLogWrite(strValue, sw);

                sw.Flush();
                sw.Close();
            }
            catch (Exception )
            {

            }
        }

        private static void DataLogWrite(string logMessage, StreamWriter w)
        {
            w.WriteLine("{0}", logMessage);
            w.WriteLine("----------------------------------------");
        }
        
        public void writeLog_Grading(string strValue)
        {
            try
            {
                //Logfile
                string path = System.Configuration.ConfigurationManager.AppSettings["Gradinglogpath"];
                StreamWriter sw;
                if (!File.Exists(path))
                { sw = File.CreateText(path); }
                else
                { sw = File.AppendText(path); }

                DataLogWrite_Grd(strValue, sw);

                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {

            }
        }

        private static void DataLogWrite_Grd(string logMessage, StreamWriter w)
        {
            w.WriteLine("{0}", logMessage);
            w.WriteLine("----------------------------------------");
        }

        public void writeLog_Peeling(string strValue)
        {
            try
            {
                //Logfile
                string path = System.Configuration.ConfigurationManager.AppSettings["Peelinglogpath"];
                StreamWriter sw;
                if (!File.Exists(path))
                { sw = File.CreateText(path); }
                else
                { sw = File.AppendText(path); }

                DataLogWrite_Plng(strValue, sw);

                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {

            }
        }

        private static void DataLogWrite_Plng(string logMessage, StreamWriter w)
        {
            w.WriteLine("{0}", logMessage);
            w.WriteLine("----------------------------------------");
        }

    }
   
}