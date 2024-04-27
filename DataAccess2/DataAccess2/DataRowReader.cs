using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess2
{
    /// <summary>
    /// Simple wrapper class for more concise code by the callers.
    /// Other "getters" supported by <see cref="SqlDataReader"/> can easily be added.
    /// </summary>
    internal class DataRowReader : IDataRowReader
    {
        private readonly SqlDataReader reader;

        public DataRowReader(SqlDataReader reader)
        {
            this.reader = reader;
        }

        public bool Read()
        {
            return reader.Read();
        }

        public int GetInt32(string name)
        {
            return GetValue(name, reader.GetInt32);
        }

        public byte GetByte(string name)
        {
            return GetValue(name, reader.GetByte);
        }

        public bool GetBoolean(string name)
        {
            return GetValue(name, reader.GetBoolean);
        }

        public string GetString(string name)
        {
            return GetValue(name, reader.GetString);
        }

        public DateTime GetDateTime(string name, DateTimeKind kind = DateTimeKind.Unspecified)
        {
            DateTime dateTime = GetValue(name, reader.GetDateTime);

            return DateTime.SpecifyKind(dateTime, kind);
        }

        public DateTimeOffset GetDateTimeOffset(string name)
        {
            return GetValue(name, reader.GetDateTimeOffset);
        }

        public bool IsDbNull(string name)
        {
            return reader.IsDBNull(GetOrdinal(name));
        }

        public T GetValue<T>(string name)
        {
            return (T)reader.GetValue(GetOrdinal(name));
        }

        private int GetOrdinal(string name)
        {
            try
            {
                return reader.GetOrdinal(name);
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new ColumnNotFoundException(name, ex);
            }
        }

        private T GetValue<T>(string name, Func<int, T> getter)
        {
            var ordinal = GetOrdinal(name);
            if (!reader.HasRows || reader.IsDBNull(ordinal))
            {
                // Handle DBNull based on T
                if (Nullable.GetUnderlyingType(typeof(T)) != null)
                {
                    // T is nullable, return null
                    return default;
                }
                else
                {
                    // T is a non-nullable value type, handle it based on the type
                    if (typeof(T) == typeof(string))
                    {
                        // Return "null" as a string
                        return (T)(object)"none";
                    }
                    else if (typeof(T).IsValueType)
                    {
                        // For value types other than string, return default value
                        return default;
                    }
                    else
                    {
                        // For reference types, return null
                        return default;
                    }
                }
            }
            else
            {
                return getter(ordinal);
            }
        }

        public T GetValue<T>(string name, T ifDbNull)
        {
            var ord = GetOrdinal(name);

            return reader.IsDBNull(ord) ? ifDbNull : (T)reader.GetValue(ord);
        }
    }
}
