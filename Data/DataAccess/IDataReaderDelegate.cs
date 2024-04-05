using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.DataAccess
{
    public interface IDataReaderDelegate<out T> : IDataDelegate
    {
        T Translate(Command command, IDataRowReader reader);
    }
}
