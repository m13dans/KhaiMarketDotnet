using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KhaiMarket.Server.Infrastructure;

public interface IDbConnectionFactory
{
    IDbConnection CreateOpenConnection();
}
