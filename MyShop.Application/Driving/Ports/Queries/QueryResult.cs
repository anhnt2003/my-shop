using MyShop.Application.Driving.Ports.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Driving.Ports.Queries
{
    public class QueryResult<TResult> : IQueryResult<TResult>
        where TResult : class
    {
        public bool IsSuccess { get; protected set; } = false;

        public List<string> Errors { get; protected set; } = new List<string>();

        public TResult? Data { get; protected set; }

        public static QueryResult<TResult> Ok()
        {
            return Ok(null);
        }

        public static QueryResult<TResult> Ok(TResult? data)
        {
            return new QueryResult<TResult>()
            {
                IsSuccess = true,
                Data = data
            };
        }

        public static QueryResult<TResult> Failure(string error)
        {
            return Failure(new List<string> { error });
        }

        public static QueryResult<TResult> Failure(List<string> errors)
        {
            return new QueryResult<TResult>
            {
                IsSuccess = false,
                Errors = errors
            };
        }
    }
}
