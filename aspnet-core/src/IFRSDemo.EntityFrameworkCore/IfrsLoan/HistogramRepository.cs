using Abp.Data;
using Abp.EntityFrameworkCore;
using IFRSDemo.EntityFrameworkCore;
using IFRSDemo.EntityFrameworkCore.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace IFRSDemo.IfrsLoan
{
    public class HistogramRepository : IFRSDemoRepositoryBase<Histogram, int>, IHistogramRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;
        

        public HistogramRepository(IDbContextProvider<IFRSDemoDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
           : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }

       
        public string[] GetCombinations()
        {
            EnsureConnectionOpen();
            var combinationlist = new List<string>();
            using (var command = CreateCommand("spp_rating_combinations", CommandType.StoredProcedure))
            {
                // command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = 0;
                SqlDataReader reader = (SqlDataReader)command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var dstfeauture = new KeyValueModel();
                        if (reader["Name"] != DBNull.Value)
                            dstfeauture.Value = reader["Name"].ToString();
                        combinationlist.Add(dstfeauture.Value);
                    }
                    reader.Close();
                    //con.Close();
                }

               // con.Close();
            }
            return combinationlist.ToArray();
        
        }

        public string[] GetDistinctFeatures()
        {
            EnsureConnectionOpen();
            var distinctFeaturelist = new List<string>();
            using (var command = CreateCommand("spp_rating_distinctfeature", CommandType.StoredProcedure))
            {
               // command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = 0;

                SqlDataReader reader = (SqlDataReader)command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var dstfeauture = new KeyValueModel();
                        if (reader["Name"] != DBNull.Value)
                            dstfeauture.Value = reader["Name"].ToString();
                        distinctFeaturelist.Add(dstfeauture.Value);
                    }
                    reader.Close();
                   // con.Close();
                }

                //con.Close();
            }
            return distinctFeaturelist.ToArray();
        }
            

        public string[] GetDistinctTop1Feature()
        {
            EnsureConnectionOpen();
            var distinctFeaturelist = new List<string>();
            using (var command = CreateCommand("spp_rating_distinctTop1", CommandType.StoredProcedure))
            { 
                // command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandTimeout = 0;
                SqlDataReader reader = (SqlDataReader)command.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        var dstfeauture = new KeyValueModel();
                        if (reader["Name"] != DBNull.Value)
                            dstfeauture.Value = reader["Name"].ToString();
                        distinctFeaturelist.Add(dstfeauture.Value);
                    }
                    reader.Close();
                    //con.Close();
                }

                //con.Close();
            }
            return distinctFeaturelist.ToArray();
        }

        public string GetAllHistogramChart(string ftname)
        {
            //throw new NotImplementedException();
            DataTable dt = new DataTable();
            dt = GetHistogramData(ftname);
            //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            object o = JsonConvert.DeserializeObject("json1");
            string json2 = JsonConvert.SerializeObject(o, Formatting.Indented);
           // var packageJson = File.ReadAllText(Path.Combine(env.ContentRootPath, "ClientApp", "package.json"));

            //var packageInfo = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, dynamic>>("packageJson");
            //string data = JsonConvert.SerializeObject(new { Histogram = low, MyId = id });
            //object dataObj = JsonConvert.DeserializeObject(data);

            //var jsonStr = System.Text.Json.JsonSerializer.Serialize("MyObject");
            //var obj = new AnySerializableObject("with-some-params");
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>(); Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    //if (col.ColumnName == "Name")
                    //    row.Add("label", dr[col]);
                    if (col.ColumnName == "lowerBound")
                        row.Add("label", dr[col]);
                    //if (col.ColumnName == "upperBound")
                    //    row.Add("uvalue", dr[col]);
                    //if (col.ColumnName == "count")
                    //    row.Add("cvalue", dr[col]);
                    if (col.ColumnName == "percent")
                        row.Add("value", dr[col]);
                }
                rows.Add(row);
            }
            //return serializer.Serialize(rows);
            //return packageInfo.ToString();
            return o.ToString();
            //return Json(jsonStr);
           
        }

        public DataTable GetHistogramData(string ftname)
        {
            EnsureConnectionOpen();
            string sql = "SELECT featurename as Name,lowerBound, [percent] FROM [Tbl_Histograms] "
        + "WHERE featurename = @ftname;";
            using (var command = CreateCommand(sql, CommandType.Text))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sql, command.ToString()))
                {
                    da.SelectCommand.CommandTimeout = 120;
                    da.SelectCommand.CommandText = sql;
                    da.SelectCommand.Parameters.Add("@ftname", SqlDbType.NVarChar);
                    da.SelectCommand.Parameters["@ftname"].Value = ftname;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds.Tables[0];
                }
            }
                //throw new NotImplementedException();
            }

       
        public void UpdateRecords(string optVal)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc;
            if (optVal == "Mean")
                storProc = "HistoTest1";
            else if (optVal == "Median")
                storProc = "HistoTest2";
            else
                storProc = "HistoTest3";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
               
                command.CommandTimeout = 0;
                status = command.ExecuteNonQuery();
            }

        }

        private DbCommand CreateCommand(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var command = Context.Database.GetDbConnection().CreateCommand();

            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Transaction = GetActiveTransaction();


            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command;
        }




        private void EnsureConnectionOpen()
        {
            var connection = Context.Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        private DbTransaction GetActiveTransaction()
        {
            return (DbTransaction)_transactionProvider.GetActiveTransaction(new ActiveTransactionProviderArgs
            {
                {"ContextType", typeof(IFRSDemoDbContext) },
                {"MultiTenancySide", MultiTenancySide }
            });
        }

        public void MaintainSingleRecord()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_setup_single";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                status = command.ExecuteNonQuery();
            }
        }

        public void RunDistStat()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "Spp_CreditScore_DescriptiveStatistics";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                status = command.ExecuteNonQuery();
            }
        }
    }
}
