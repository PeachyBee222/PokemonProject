using DataAccess2;
using PokemonCollections.Data.Models;

namespace PokemonCollections.Data.DataDelegates
{
    public class RetrieveUserDataDelegate : DataReaderDelegate<List<User>>
    {
        public RetrieveUserDataDelegate()
            : base("Pokemon.RetrieveUsers")
        {
        }
        public override List<User> Translate(Command command, IDataRowReader reader)
        {
            var users = new List<User>();

            while (reader.Read())
            {
                users.Add(new User(
                    reader.GetInt32("UserID"),
                    reader.GetString("Email"))
                    );
            }

            return users;
        }
    }
}
