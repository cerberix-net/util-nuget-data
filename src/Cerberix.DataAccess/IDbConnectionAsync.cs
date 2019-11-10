using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cerberix.DataAccess
{
    public interface IDbConnectionAsync
    {
        Task<int> Execute(
            string sql,
            object param = null,
            int? commandTimeout = null,
            DbConnectionCommandType? commandType = null
            );

        Task<TResult> ExecuteScalar<TResult> (
            string sql,
            object param = null,
            int? commandTimeout = null,
            DbConnectionCommandType? commandType = null
            ) where TResult : struct;

        Task<IEnumerable<TResult>> Query<TResult>(
            string sql,
            object param = null,
            int? commandTimeout = null,
            DbConnectionCommandType? commandType = null
            ) where TResult: class, new();

        Task<TResult> QuerySingle<TResult>(
            string sql,
            object param = null,
            int? commandTimeout = null,
            DbConnectionCommandType? commandType = null
            ) where TResult : class, new();
    }
}
