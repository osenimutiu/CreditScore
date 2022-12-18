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

namespace IFRSDemo.DemoAttribute
{
    public class DemoRetailRepository : IFRSDemoRepositoryBase<DemoRetailAttrItem, int>, IDemoRetailRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;
        public DemoRetailRepository(IDbContextProvider<IFRSDemoDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
           : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }

        public void ApproveAttribute(int param1, string param2)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_approveAttribute";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_approveId",
                    Value = param1,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_approveReason",
                    Value = param2,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void DeclineAttribute(int param1, string param2)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_declineAttribute";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_declineId",
                    Value = param1,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_declineReason",
                    Value = param2,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public bool InsertNewCustomerScore(string param1, string param2, string param3, string param4, double param5)
        {
            
            EnsureConnectionOpen();
            bool result;
            int status = 0;
            string storProc = "sp_insertNewCustomerScore";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_firstName",
                    Value = param1,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_lastName",
                    Value = param2,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_accountNo",
                    Value = param3,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_bVN",
                    Value = param4,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_score",
                    Value = param5,
                });
                status = command.ExecuteNonQuery();
                result = true;
                return result;
            }
        }

        public void ReverseAttribute(int param1)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_reverseAttribute";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@_reverseId",
                    Value = param1,
                });
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
