using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cerberix.DataAccess.Core
{
    public interface IDbConnectionAsync
    {
        Task<int> Execute(
            string sql,
            object param = null,
            int? commandTimeout = null,
            DbConnectionCommandType? commandType = null
            );

        Task<IEnumerable<TResult>> Query<TResult>(
            string sql,
            object param = null,
            int? commandTimeout = null,
            DbConnectionCommandType? commandType = null
            );

        Task<TResult> QueryScalar<TResult>(
            string sql,
            object param = null,
            int? commandTimeout = null,
            DbConnectionCommandType? commandType = null
            );
    }
}
