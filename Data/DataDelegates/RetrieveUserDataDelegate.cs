using DataAccess;
using PokemonProject.Data.Models;

namespace PokemonProject.Data.DataDelegates
{
    internal class RetrieveUserDataDelegate : DataReaderDelegate<IReadOnlyList<User>>
    {
        public RetrieveUserDataDelegate()
            : base("Pokemon.RetrieveUsers")
        {
        }
        public override IReadOnlyList<User> Translate(Command command, IDataRowReader reader)
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
