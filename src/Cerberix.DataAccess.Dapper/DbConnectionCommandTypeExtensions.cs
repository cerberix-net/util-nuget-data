using System;
using System.Data;

namespace Cerberix.DataAccess.Dapper
{
    internal static class DbConnectionCommandTypeExtensions
    {
        public static CommandType ToCommandType(this DbConnectionCommandType commandType)
        {
            switch(commandType)
            {
                case DbConnectionCommandType.Text:
                    return CommandType.Text;
                case DbConnectionCommandType.StoredProcedure:
                    return CommandType.StoredProcedure;
                default:
                    throw new NotImplementedException($"Unsupported command type: {commandType.ToString()}");
            }
        }
    }
}
