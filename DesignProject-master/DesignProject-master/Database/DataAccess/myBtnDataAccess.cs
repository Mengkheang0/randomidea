using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace Database.DataAccess
{
    public class myBtnDataAccess
    {
        
        /// <summary>
        /// Get Data from datbase
        /// </summary>
        /// <returns></returns>
        public List<Models.myBtnModel> GetButtonsData()
        {
            using (System.Data.IDbConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["BtnDB"].ConnectionString))
            {
                var output = con.Query<Models.myBtnModel>("select * from ButtonTB").ToList();

                return output;
            }
        }

        /// <summary>
        /// Delet data from database
        /// </summary>
        /// <param name="btnName"></param>
        public void DeleteButtonsData(string btnName)
        {
            using (System.Data.IDbConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["BtnDB"].ConnectionString))
            {
                con.Query<Models.myBtnModel>($"delete from dbo.ButtonTB where ButtonName = '{btnName}'");
                con.Query<Models.myBtnModel>($"delete from dbo.ButtonTB where ButtonText = '{btnName}'");
                
            }
        }

        /// <summary>
        /// Add data to database
        /// </summary>
        /// <param name="btnName"></param>
        /// <param name="btnText"></param>
        /// <exception cref="Exception"></exception>
        public void AdddButtonsData(string btnName,string btnText)
        {
            using (System.Data.IDbConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["BtnDB"].ConnectionString))
            {
                try
                {
                    con.Query<Models.myBtnModel>($"insert into dbo.ButtonTB(ButtonName,ButtonText) values('{btnName}','{btnText}')");

                }
                catch (Exception)
                {

                    throw new Exception("There are some unavalable text init");
                }

            }
        }

        /// <summary>
        /// Update data to database
        /// </summary>
        /// <param name="oldbtnName"></param>
        /// <param name="newBtnName"></param>
        public void UpdateButtonsData(string oldbtnName, string newBtnName)
        {
            using (System.Data.IDbConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["BtnDB"].ConnectionString))
            {
                con.Query<Models.myBtnModel>($"update dbo.ButtonTB set ButtonName = '{newBtnName}' where ButtonName = '{oldbtnName}'");
                con.Query<Models.myBtnModel>($"update dbo.ButtonTB set ButtonText = '{newBtnName}' where ButtonText = '{oldbtnName}'");

            }
        }

        public List<Models.myBtnModel> SearchButtonsData(string btnName)
        {
            using (System.Data.IDbConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["BtnDB"].ConnectionString))
            {
                var output =con.Query<Models.myBtnModel>($"select * from dbo.ButtonTB where ButtonName like '{btnName}%'").ToList();

                return output;
            }
        }

    }
}
