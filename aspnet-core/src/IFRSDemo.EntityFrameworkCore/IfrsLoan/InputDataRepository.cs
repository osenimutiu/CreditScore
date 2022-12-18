//using System;
//using System.Collections.Generic;
//using System.Text;

using Abp.Data;
using System.Data;
using System.Data.Common;
//using System.Data.SqlClient;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.EntityFrameworkCore;
using IFRSDemo.EntityFrameworkCore;
using IFRSDemo.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace IFRSDemo.IfrsLoan
{
   public class InputDataRepository : IFRSDemoRepositoryBase<InputData, int>, IInputDataRepository
    {
        private readonly IActiveTransactionProvider _transactionProvider;

        public InputDataRepository(IDbContextProvider<IFRSDemoDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
            : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }

        public async Task<List<string>> GetDropdown()
        {
            EnsureConnectionOpen();

            using (var command = CreateCommand("GetDropdown", CommandType.StoredProcedure))
            {
                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    var result = new List<string>();

                    while (dataReader.Read())
                    {
                        result.Add(dataReader["COLUMN_NAME"].ToString());
                    }

                    return result;
                }
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
