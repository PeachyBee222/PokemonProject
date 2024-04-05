using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data.DataAccess
{
    [Serializable]
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string key)
         : base($"The requested record with key [{key}] does not exist.")
        {
        }

        protected RecordNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext)
           : base(serializationInfo, streamingContext)
        {
        }
    }
}
