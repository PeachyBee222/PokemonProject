using DataAccess2;
using TheFlyingSaucer.Data.Models;

namespace TheFlyingSaucer.Data.DataDelegates
{
    internal class GetUserRanksDataDelegate : DataReaderDelegate<User>
    {
        public GetUserRanksDataDelegate()
            : base("Pokemon.GetUserRanks")
        {
        }

        public override User Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            return new User(
               reader.GetInt32("UserID"),
               reader.GetString("Email"));
        }
    }
}
