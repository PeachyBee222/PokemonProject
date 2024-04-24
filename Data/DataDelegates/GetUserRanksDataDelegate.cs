using DataAccess2;
using TheFlyingSaucer.Data.Models;

namespace TheFlyingSaucer.Data.DataDelegates
{
    internal class GetUserRanksDataDelegate : DataReaderDelegate<List<User>>
    {
        public GetUserRanksDataDelegate()
            : base("Pokemon.GetUserRanks")
        {
        }

        public override List<User> Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
                return new List<User>();

            var users = new List<User>();

            while (reader.Read())
            {
                var input = new User(
                    reader.GetInt32("UserID"),
                    reader.GetString("Email"));
                input.SetNumPokemon(reader.GetInt32("NumberOfPokemon"));
                users.Add(input);
            }

            return users;
        }
    }
}
