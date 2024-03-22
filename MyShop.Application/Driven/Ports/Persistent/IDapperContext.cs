using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Driven.Ports.Persistent
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
