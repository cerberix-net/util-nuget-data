using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Cerberix.DataAccess.Core;
using Dapper;

namespace Cerberix.DataAccess.Dapper
{
    public class DapperDbConnectionAsync : IDbConnectionAsync
    {
        private readonly IDbConnection _dbConnection;

        public DapperDbConnectionAsync(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<int> Execute(
            string sql,
            object param = null,
            int? commandTimeout = null,
            DbConnectionCommandType? commandType = null
            )
        {
            return _dbConnection.ExecuteAsync(
                sql: sql,
                param: param,
                commandTimeout: commandTimeout,
                commandType: commandType?.ToCommandType()
                );
        }

        public Task<IEnumerable<TResult>> Query<TResult>(
            string sql,
            object param = null,
            int? commandTimeout = null,
            DbConnectionCommandType? commandType = null
            )
        {
            return _dbConnection.QueryAsync<TResult>(
                sql: sql,
                param: param,
                commandTimeout: commandTimeout,
                commandType: commandType?.ToCommandType()
                );
        }

        public Task<TResult> QueryScalar<TResult>(
            string sql,
            object param = null,
            int? commandTimeout = null,
            DbConnectionCommandType? commandType = null
            )
        {
            return _dbConnection.ExecuteScalarAsync<TResult>(
                sql: sql,
                param: param,
                commandTimeout: commandTimeout,
                commandType: commandType?.ToCommandType()
                );
        }
    }
}
