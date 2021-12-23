using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataBots.CLASSES
{
    public class DataAccess
    {
        private List<Models.FileInfoModel> ListFileInfo = new List<Models.FileInfoModel>();

        public DataAccess()
        {



            ListFileInfo.Add(new Models.FileInfoModel() { Id = 1, FileName = "Project1", Path = @"D:\BG\Project1.sln", TimeCreated = DateTime.Now.AddYears(-3) });
            ListFileInfo.Add(new Models.FileInfoModel() { Id = 2, FileName = "DeleteData", Path = @"D:\Test\DeleteData.sln", TimeCreated = DateTime.Now.AddYears(-2) });
            ListFileInfo.Add(new Models.FileInfoModel() { Id = 3, FileName = "FileSystem", Path = @"D:\Test\2021\FileSystem.sln", TimeCreated = DateTime.Now.AddYears(-1) });
            ListFileInfo.Add(new Models.FileInfoModel() { Id = 4, FileName = "Design", Path = @"D:\Test\DesignProjects\FileSystem.sln", TimeCreated = DateTime.Now.AddMonths(2) });
            ListFileInfo.Add(new Models.FileInfoModel() { Id = 5, FileName = "phone", Path = @"D:\Test\DesignProjects\phone.sln", TimeCreated = DateTime.Now.AddMonths(1) });
            ListFileInfo.Add(new Models.FileInfoModel() { Id = 6, FileName = "instagram", Path = @"D:\Test\DesignProjects\instagram.sln", TimeCreated = DateTime.Now.AddDays(12) });
            ListFileInfo.Add(new Models.FileInfoModel() { Id = 7, FileName = "gamer", Path = @"D:\Test\DesignProjects\gamer.sln", TimeCreated = DateTime.Now });
        }

        /// <summary>
        /// Get Data
        /// </summary>
        /// <returns></returns>
        public List<Models.FileInfoModel> GetListOfFileInfo()
        {
            using(IDbConnection conn = new System.Data.SqlClient.SqlConnection(CLASSES.ConnectionString.GetConString("DataBots")))
            {
                var ListFileInfo = conn.Query<Models.FileInfoModel>($"select * from dbo.FileInfoTB").ToList();

                return ListFileInfo;
            }

        }



        /// <summary>
        /// Add Data
        /// </summary>
        /// <param name="fileInfo"></param>
        public void AddData(Models.FileInfoModel fileInfo)
        {
            using(IDbConnection connection = new System.Data.SqlClient.SqlConnection(CLASSES.ConnectionString.GetConString("DataBots")))
            {
                connection.Query<Models.FileInfoModel>($@"insert into dbo.FileInfoTB(Path,FileName,TimeCreated)
                                                                            values('{fileInfo.Path}','{fileInfo.FileName}','{fileInfo.TimeCreated}')");

            }
        }
  
        /// <summary>
        /// Search data
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public List<Models.FileInfoModel> SearchFileName(string fileName)
        {
            List<Models.FileInfoModel> newFile = new List<Models.FileInfoModel>();

            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(CLASSES.ConnectionString.GetConString("DataBots")))
            {
                var ListFileInfo = conn.Query<Models.FileInfoModel>($"select * from dbo.FileInfoTB").ToList();

                foreach (var file in ListFileInfo)
                {
                    if (file.FileName.StartsWith(fileName) || file.FileName.StartsWith(fileName.ToUpper()))
                    {
                        newFile.Add(file);
                    }
                }

                return newFile;
            }

            
        }

        public void DeleteData(int id)
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(CLASSES.ConnectionString.GetConString("DataBots")))
            {
                var ListFileInfo = conn.Query<Models.FileInfoModel>($"delete from dbo.FileInfoTB where Id={id}").ToList();

            }
        }
    }
}
