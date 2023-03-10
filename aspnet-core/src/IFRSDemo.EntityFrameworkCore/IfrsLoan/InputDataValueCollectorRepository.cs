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

namespace IFRSDemo.IfrsLoan
{
   public class InputDataValueCollectorRepository : IFRSDemoRepositoryBase<InputDataValueCollector, int>, IInputDataValueCollectorRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;

        public InputDataValueCollectorRepository(IDbContextProvider<IFRSDemoDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
           : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;

        }

        public void CreateSelectedAttributes(string param1, int param2)
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_selected_attributes";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@SelectedValues",
                    Value = param1,
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@TenantId",
                    Value = param2,
                });
                status = command.ExecuteNonQuery();
            }
        }

        public void FillCreditExclusion()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_fillcredit_exclusion";
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
