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
using System.Threading.Tasks;

namespace IFRSDemo.QualitativeAnalysis
{
    public class QualitativeAnalysisRepository : IFRSDemoRepositoryBase<Tbl_QualitativeAnalysis, int>, IQualitativeAnalysisRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;
        public QualitativeAnalysisRepository(IDbContextProvider<IFRSDemoDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
           : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }

        public void TruncateCutOff()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_maintain_single_cutoff";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                status = command.ExecuteNonQuery();
            }
        }

        public void TruncateRetailCutOff()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_maintain_single_retailcutoff";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                status = command.ExecuteNonQuery();
            }
        }

        public void TruncateScoresForPost()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_singlescore";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                status = command.ExecuteNonQuery();
            }
        }
        public void ObtainOption()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_obtainoption";
            using (var command = CreateCommand(storProc, CommandType.StoredProcedure))
            {
                command.CommandTimeout = 0;
                status = command.ExecuteNonQuery();
            }
        }
        public void PreventDuplicateRating()
        {
            EnsureConnectionOpen();
            int status = 0;
            string storProc = "sp_avoid_duplicate-rating";
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
