using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess2
{
    public abstract class DataDelegate : IDataDelegate
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
