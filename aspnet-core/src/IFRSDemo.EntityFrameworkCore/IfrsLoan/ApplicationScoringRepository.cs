using System;
using System.Data.Common;
using System.Data;
using System.Collections.Generic;
using IFRSDemo.EntityFrameworkCore.Repositories;
using System.Text;
using Microsoft.EntityFrameworkCore;
using IFRSDemo.EntityFrameworkCore;
using Abp.Data;
using Abp.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace IFRSDemo.IfrsLoan
{
   public class ApplicationScoringRepository : IFRSDemoRepositoryBase<ApplicationScoring, int>, IApplicationScoringRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;

        public ApplicationScoringRepository(IDbContextProvider<IFRSDemoDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
           : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }

        public void ComputeApplicationScore(int param1, int param2, int param3, int param4, int param5, int param6, int param7, string param8, string param9, int param10)
        {
            
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_calculate_score_new";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "v_id",
                    Value = param1,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@v_id1",
                    Value = param2,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@v_id2",
                    Value = param3,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@v_id3",
                    Value = param4,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@v_id4",
                    Value = param5,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@v_id5",
                    Value = param6,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@v_id6",
                    Value = param7,
                });
               
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "v_applicationtype",
                    Value = param8,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@v_applicant",
                    Value = param9,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@v_id7",
                    Value = param10,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void ComputeApplicationScore2(string param11, string param9, string custid, int param10)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_calculate_score_new2";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "v_applicationtype",
                    Value = param11,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@v_applicant",
                    Value = param9,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@v_custId",
                    Value = custid,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@v_id7",
                    Value = param10,
                });
                status = command.ExecuteNonQuery();


            }
        }
		
		        public void GetTrain_TestParam(string param)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_trainingortest";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@i",
                    Value = param,
                });
                status = command.ExecuteNonQuery();


            }
        }

        public void PostForAllRegression()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_count_all_regression";
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
