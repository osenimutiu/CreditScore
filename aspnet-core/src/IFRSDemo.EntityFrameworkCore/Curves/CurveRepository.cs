using Abp.Data;
using Abp.EntityFrameworkCore;
using IFRSDemo.EntityFrameworkCore;
using IFRSDemo.EntityFrameworkCore.Repositories;
using IFRSDemo.IfrsLoan;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace IFRSDemo.Curves
{
    public class CurveRepository : IFRSDemoRepositoryBase<DescriptiveStatistics, int>, ICurveRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;
        public CurveRepository(IDbContextProvider<IFRSDemoDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
           : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }

        public bool InsertNewCoperateScore(string param1, string param2, string param3, double param4)
        {

            EnsureConnectionOpen();
            bool result;
            int status = 0;
            string storProc = "sp_insertNewCooperateScore";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_companyname",
                    Value = param1,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_rcnumber",
                    Value = param2,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_accountNo",
                    Value = param3,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_score",
                    Value = param4,
                });
                status = command.ExecuteNonQuery();
                result = true;
                return result;
            }
        }
        public void GetAgebinParam(string agebin)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_agebin_param";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@agebin",
                    Value = agebin,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void GetCurrAccStatusParam(string currAccStat)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_Current_Account_Status_param";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@curr",
                    Value = currAccStat,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public string[] GetDistictAgebin()
        {
            EnsureConnectionOpen();
            var combinationlist = new List<string>();
            using (var command = CreateCommand("spp_distinct_Agebin", CommandType.StoredProcedure))
            {
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
                }
            }
            return combinationlist.ToArray();
        }

        public string[] GetDistictCurrAccStatus()
        {
            EnsureConnectionOpen();
            var combinationlist = new List<string>();
            using (var command = CreateCommand("spp_distinct_current_account_status", CommandType.StoredProcedure))
            {
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
                }
            }
            return combinationlist.ToArray();
        }

        public string[] GetDistictLocation()
        {
            EnsureConnectionOpen();
            var combinationlist = new List<string>();
            using (var command = CreateCommand("spp_distinct_location", CommandType.StoredProcedure))
            {
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
                }
            }
            return combinationlist.ToArray();
        }

        public string[] GetDistictPayment_performance()
        {
            EnsureConnectionOpen();
            var combinationlist = new List<string>();
            using (var command = CreateCommand("spp_distinct_payment_performance", CommandType.StoredProcedure))
            {
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
                }
            }
            return combinationlist.ToArray();
        }

        public string[] GetDistictProduct()
        {
            EnsureConnectionOpen();
            var combinationlist = new List<string>();
            using (var command = CreateCommand("spp_distinct_product", CommandType.StoredProcedure))
            {
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
                }
            }
            return combinationlist.ToArray();
        }

        public string[] GetDistictResident_status()
        {
            EnsureConnectionOpen();
            var combinationlist = new List<string>();
            using (var command = CreateCommand("spp_distinct_resident_status", CommandType.StoredProcedure))
            {
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
                }
            }
            return combinationlist.ToArray();
        }

        public string[] GetDistictTime_at_Jobbin()
        {
            
            EnsureConnectionOpen();
            var combinationlist = new List<string>();
            using (var command = CreateCommand("spp_distinct_Time_at_job_bin", CommandType.StoredProcedure))
            {
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
                }
            }
            return combinationlist.ToArray();
        }

        public void GetLocationParam(string location)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_location_param";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@loc",
                    Value = location,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void GetPayment_performanceParam(string payment_performance)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_payment_performance_param";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@pay_perf",
                    Value = payment_performance,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void GetProductParam(string product)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_product_param";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@prod",
                    Value = product,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void PostProductParamRaw(string productRaw)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_product_param_raw";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@prod",
                    Value = productRaw,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void GetResident_statusParam(string residentStatus)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_resident_Status_param";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@res_Sta",
                    Value = residentStatus,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void GetTime_at_JobbinParam(string time_at_Jobbin)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_time_at_Jobbin_param";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@jobbin",
                    Value = time_at_Jobbin,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void PostForAll()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_count_all";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                status = command.ExecuteNonQuery();
            }
        }

        public void PostForAllRaw()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_count_all_raw";
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

        public void PostCurrAccStatParamRaw(string curraccstatRaw)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_curraccstat_param_raw";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@curraccstat",
                    Value = curraccstatRaw,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void PostLocationParamRaw(string locationRaw)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_location_param_raw";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@location",
                    Value = locationRaw,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void PostResidentStatusParamRaw(string residStatRaw)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_residentstatus_param_raw";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@resdtsta",
                    Value = residStatRaw,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void PostPayment_performanceParamRaw(string payment_performanceRaw)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_payperf_param_raw";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@payperf",
                    Value = payment_performanceRaw,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void RunProcess()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_count_all_raw";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                status = command.ExecuteNonQuery();
            }
        }

        public async Task<List<string>> GetHeaders()
        {
            EnsureConnectionOpen();
            using (var command = CreateCommand("sp_getinput_headers", CommandType.StoredProcedure))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    var result = new List<string>();
                    while (dataReader.Read())
                    {
                        result.Add(dataReader["column_name"].ToString());
                    }

                    return result;
                }
            }
        }

        public void InsertHeaders()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_insertinput_headers";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                status = command.ExecuteNonQuery();
            }
        }

        public void TruncateCutOff()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_CutOff_single";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                status = command.ExecuteNonQuery();
            }
        }
        public void ExecuteStabilityTrend(string param1, string param2, string param3)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "binning_count_Archive";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@tablename",
                    Value = param1,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@credit_exclusion",
                    Value = param2,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@good_bad",
                    Value = param3,
                });
                status = command.ExecuteNonQuery();
            }
        }
        public void CountAttributes()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_getattribute_headers";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                status = command.ExecuteNonQuery();
            }
        }
    }
}
