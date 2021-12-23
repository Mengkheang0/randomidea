using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DictionaryApp.DataAccess
{
    public class DictionaryDataAccess
    {
        /// <summary>
        /// Get Data from datbase
        /// </summary>
        /// <returns></returns>
        public List<Models.DictionaryModel> GetDictionaryData()
        {
            using (System.Data.IDbConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["DictionaryDB"].ConnectionString))
            {
                var output = con.Query<Models.DictionaryModel>("select * from dictionaryTB").ToList();

                return output;
            }
        }

        /// <summary>
        /// Delet data from database
        /// </summary>
        /// <param name="btnName"></param>
        public void DeleteButtonData(string btnName)
        {
            using (System.Data.IDbConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["DictionaryDB"].ConnectionString))
            {
                con.Query<Models.DictionaryModel>($"delete from dbo.ButtonTB where ButtonName = '{btnName}'");
                con.Query<Models.DictionaryModel>($"delete from dbo.ButtonTB where ButtonText = '{btnName}'");

            }
        }

        /// <summary>
        /// Add data to database
        /// </summary>
        /// <param name="btnName"></param>
        /// <param name="btnText"></param>
        /// <exception cref="Exception"></exception>
        public void AdddButtonsData(string btnName, string btnText)
        {
            using (System.Data.IDbConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["DictionaryDB"].ConnectionString))
            {
                try
                {
                    con.Query<Models.DictionaryModel>($"insert into dbo.ButtonTB(ButtonName,ButtonText) values('{btnName}','{btnText}')");

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
            using (System.Data.IDbConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["DictionaryDB"].ConnectionString))
            {
                con.Query<Models.DictionaryModel>($"update dbo.ButtonTB set ButtonName = '{newBtnName}' where ButtonName = '{oldbtnName}'");
                con.Query<Models.DictionaryModel>($"update dbo.ButtonTB set ButtonText = '{newBtnName}' where ButtonText = '{oldbtnName}'");

            }
        }

        public List<Models.DictionaryModel> SearchDictionaryData(string word)
        {
            using (System.Data.IDbConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["DictionaryDB"].ConnectionString))
            {
                var output = con.Query<Models.DictionaryModel>($"select * from dbo.DictionaryTB where Word like '{word}%'").ToList();

                return output;
            }
        }

        public List<Models.DictionaryModel> GetDictionaryDefinition(string word)
        {
            using (System.Data.IDbConnection con = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings["DictionaryDB"].ConnectionString))
            {
                var output = con.Query<Models.DictionaryModel>($"select * from dbo.DictionaryTB where Word ='{word}' ").ToList();

                return output;
            }
        }

    }
}
