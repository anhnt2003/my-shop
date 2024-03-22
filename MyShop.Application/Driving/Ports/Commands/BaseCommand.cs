using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Driving.Ports.Commands
{
    public class BaseCommand<TReponse> : IBaseCommand<TReponse>
        where TReponse : class
    {
    }
}
