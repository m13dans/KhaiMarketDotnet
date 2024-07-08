using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace KhaiMarket.ServerWithController.Infrastructure;

public interface IDbConnectionFactory
{
    IDbConnection CreateOpenConnection();
}
