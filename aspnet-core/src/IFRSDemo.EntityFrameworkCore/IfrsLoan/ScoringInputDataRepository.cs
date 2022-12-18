using Abp.Data;
using IFRSDemo.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using IFRSDemo.EntityFrameworkCore;
using Abp.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace IFRSDemo.IfrsLoan
{
   public class ScoringInputDataRepository : IFRSDemoRepositoryBase<ScoringInputData, int>, IScoringInputDataRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;

        public ScoringInputDataRepository(IDbContextProvider<IFRSDemoDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
           : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }

        public void ComputeBulkScore()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "rating_generate_bulk_score_for_scoring_output";
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
