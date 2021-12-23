using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataBots.CLASSES
{
    internal class FilesManage
    {
        public void CreateProject(string path,string projectName)
        {
            Directory.CreateDirectory(path);
            var solutionPath = Path.Combine(path, projectName);

            if (File.Exists(solutionPath))
            {
                File.AppendAllLines(solutionPath,new string[] { $"Project name : {projectName}" });
                File.AppendAllLines(solutionPath,new string[] { $"Create Date : {DateTime.Now}" });
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(solutionPath))
                {
                    writer.WriteLine(DateTime.Now.ToString());
                }
                System.Windows.MessageBox.Show(solutionPath);

            }


        }
        public bool CheckingPath(string path)
        {
            if (Directory.Exists(path) || File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CopyFile(DateTime startTime, DateTime endTime)
        {
            System.Timers.Timer time = new System.Timers.Timer();
            time.Interval = 1000;
            time.Start();
            time.AutoReset = true;
            time.Elapsed += Time_Elapsed;

            void Time_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                if(startTime > endTime)
                {
                    System.Diagnostics.Debug.WriteLine(startTime);
                    //time.Stop();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(endTime);
                }
            }

        }

   
    }
}
