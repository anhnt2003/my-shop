using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Driving.Ports.Commands
{
    public class CommandResponse<TResponse> : ICommandReponse<TResponse>
        where TResponse : class
    {
        public bool IsSuccess { get; private set; } = false;

        public List<string> Errors { get; private set; } = new List<string>();

        public TResponse? Data { get; private set; }

        public static CommandResponse<TResponse> Ok()
        {
            return Ok(null);
        }

        public static CommandResponse<TResponse> Ok(TResponse? data)
        {
            return new CommandResponse<TResponse>()
            {
                IsSuccess = true,
                Data = data
            };
        }

        public static CommandResponse<TResponse> Failure(string error)
        {
            return Failure(new List<string> { error });
        }

        public static CommandResponse<TResponse> Failure(List<string> errors)
        {
            return new CommandResponse<TResponse>
            {
                IsSuccess = false,
                Errors = errors
            };
        }
    }
}
