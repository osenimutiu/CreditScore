using Abp.Data;
using Abp.EntityFrameworkCore;
using IFRSDemo.EntityFrameworkCore;
using IFRSDemo.EntityFrameworkCore.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace IFRSDemo.DigitalLending
{
   public class SeverityRepository : IFRSDemoRepositoryBase<Tbl_Severity, int>, ISeverityRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;
        public SeverityRepository(IDbContextProvider<IFRSDemoDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
           : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }

        //public void PostSeverity(double param1, double param2, double param3, double param4, double param5, double param6,
        //    double param8, double param9, double param10, double param11, double param12, double param13, double param14, double param15,
        //    double param16, double param17, double param18, double param19, double param20, double param21, double param22, double param23,
        //    double param24, double param25, double param26, double param27, double param28, double param29, double param30, double param31,
        //    double param32, double param33, double param34, double param35, double param36, double param37, double param38, double param39,
        //    double param40, double param41, double param42)
        //{
        //    EnsureConnectionOpen();
        //    int status = 0;
        //    string storProc = "sp_postSeverity";
        //    using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
        //    {
        //        command.CommandTimeout = 0;
        //        command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param1",
        //            Value = param1,
        //        });
        //        command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param2",
        //            Value = param2,
        //        });
        //        command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param3",
        //            Value = param3,
        //        });
        //        command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param4",
        //            Value = param4,
        //        });
        //        command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param5",
        //            Value = param5,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param6",
        //            Value = param6,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param8",
        //            Value = param8,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param9",
        //            Value = param9,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param10",
        //            Value = param10,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param11",
        //            Value = param11,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param12",
        //            Value = param12,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param13",
        //            Value = param13,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param14",
        //            Value = param14,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param15",
        //            Value = param15,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param16",
        //            Value = param16,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param17",
        //            Value = param17,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param18",
        //            Value = param18,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param19",
        //            Value = param19,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param20",
        //            Value = param20,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param21",
        //            Value = param21,
        //        });
        //        command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param22",
        //            Value = param22,
        //        });
        //        command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param23",
        //            Value = param23,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param24",
        //            Value = param24,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param25",
        //            Value = param25,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param26",
        //            Value = param26,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param27",
        //            Value = param27,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param28",
        //            Value = param28,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param29",
        //            Value = param29,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param30",
        //            Value = param30,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param31",
        //            Value = param31,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param32",
        //            Value = param32,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param33",
        //            Value = param33,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param34",
        //            Value = param34,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param35",
        //            Value = param35,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param36",
        //            Value = param36,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param37",
        //            Value = param37,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param38",
        //            Value = param38,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param39",
        //            Value = param39,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param40",
        //            Value = param40,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param41",
        //            Value = param41,
        //        });
        //           command.Parameters.Add(new SqlParameter
        //        {
        //            ParameterName = "@_param42",
        //            Value = param42,
        //        });
        //        status = command.ExecuteNonQuery();
        //    }
        //}

        public void PostBDS(double param1, double param2, double param3, double param4, double param5, double param6)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_postBankAccountDataSource";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param1",
                    Value = param1,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param2",
                    Value = param2,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param3",
                    Value = param3,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param4",
                    Value = param4,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param5",
                    Value = param5,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param6",
                    Value = param6,
                });
                status = command.ExecuteNonQuery();
            }
        }
        public void PostCLEDS(double param8, double param9, double param10, double param11, double param12, double param13)
        {
                EnsureConnectionOpen();
                int status = 0;
                string storProc = "sp_postcreditLineEstimationDataSource";
                using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
                {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param8",
                    Value = param8,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param9",
                    Value = param9,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param10",
                    Value = param10,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param11",
                    Value = param11,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param12",
                    Value = param12,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param13",
                    Value = param13,
                });
                status = command.ExecuteNonQuery();
            }
        }
        public void PostFDS(double param14, double param15, double param16)
        {
                    EnsureConnectionOpen();
                    int status = 0;
                    string storProc = "sp_postFinancialDataSource";
                    using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
                    {
                    command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param14",
                    Value = param14,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param15",
                    Value = param15,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param16",
                    Value = param16,
                });
                status = command.ExecuteNonQuery();
                }
            }
        public void PostFCDS(double param17, double param18, double param19, double param20, double param21)
                    {
                        EnsureConnectionOpen();
                        int status = 0;
                        string storProc = "sp_postFraudCheckDataSource";
                        using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
                {
                    command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param17",
                    Value = param17,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param18",
                    Value = param18,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param19",
                    Value = param19,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param20",
                    Value = param20,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param21",
                    Value = param21,
                });
                status = command.ExecuteNonQuery();
                }
            }
        public void PostNFRDS(double param22, double param23)
                        {
                            EnsureConnectionOpen();
                            int status = 0;
                            string storProc = "sp_postNonFinacialRisk";
                            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
                {
                    command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param22",
                    Value = param22,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param23",
                    Value = param23,
                });
                status = command.ExecuteNonQuery();
                }
            }
        public void CBDS(double param24, double param25, double param26, double param27, double param28, double param29, double param30, double param31,
            double param32, double param33, double param34, double param35, double param36, /*double param37,*/ double param38, double param39,
            double param40, double param41, double param42)
                            {
                                EnsureConnectionOpen();
                                int status = 0;
                                string storProc = "sp_postCreditBureauDataSource";
                                using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
                {
                    command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param24",
                    Value = param24,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param25",
                    Value = param25,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param26",
                    Value = param26,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param27",
                    Value = param27,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param28",
                    Value = param28,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param29",
                    Value = param29,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param30",
                    Value = param30,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param31",
                    Value = param31,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param32",
                    Value = param32,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param33",
                    Value = param33,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param34",
                    Value = param34,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param35",
                    Value = param35,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param36",
                    Value = param36,
                });
                //command.Parameters.Add(new SqlParameter
                //{
                //    ParameterName = "@_param37",
                //    Value = param37,
                //});
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param38",
                    Value = param38,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param39",
                    Value = param39,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param40",
                    Value = param40,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param41",
                    Value = param41,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_param42",
                    Value = param42,
                });
                status = command.ExecuteNonQuery();
                }
            }
        public void GenerateScoreAllocation()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "DL_Generate_Score_Allocation";
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
    }
}
