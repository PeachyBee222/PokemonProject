using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.DataAccess
{
    public interface IDataDelegate
    {
        string ProcedureName { get; }

        void PrepareCommand(Command command);
    }
}
