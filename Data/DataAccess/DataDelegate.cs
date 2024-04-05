using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.DataAccess
{
    public abstract class DataDelegate
    {
        public string ProcedureName { get; }

        protected DataDelegate(string procedureName)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
                throw new ArgumentException("The procedure name cannot be null or empty.", nameof(procedureName));

            ProcedureName = procedureName;
        }

        public virtual void PrepareCommand(Command command)
        {
        }
    }
}
