using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Cerberix.Extension.Core;
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

        public Task<TResult> ExecuteScalar<TResult>(
            string sql,
            object param = null,
            int? commandTimeout = null,
            DbConnectionCommandType? commandType = null
            ) where TResult: struct
        {
            return _dbConnection.ExecuteScalarAsync<TResult>(
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
            ) where TResult: class, new()
        {
            return _dbConnection.QueryAsync<TResult>(
                sql: sql,
                param: param,
                commandTimeout: commandTimeout,
                commandType: commandType?.ToCommandType()
                );
        }

        public Task<TResult> QuerySingle<TResult>(
            string sql,
            object param = null,
            int? commandTimeout = null,
            DbConnectionCommandType? commandType = null
            ) where TResult : class, new()
        {
            return _dbConnection.QueryAsync<TResult>(
                sql: sql,
                param: param,
                commandTimeout: commandTimeout,
                commandType: commandType?.ToCommandType()
                ).SingleAsync();
        }
    }
}
