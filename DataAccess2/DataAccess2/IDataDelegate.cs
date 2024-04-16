using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess2
{
    public interface IDataDelegate
    {
        string ProcedureName { get; }

        void PrepareCommand(Command command);
    }
}
