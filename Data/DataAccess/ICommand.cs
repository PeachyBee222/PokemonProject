using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.DataAccess
{
    public interface ICommand
    {
        SqlParameterCollection Parameters { get; }

        T GetParameterValue<T>(string name);
    }
}
