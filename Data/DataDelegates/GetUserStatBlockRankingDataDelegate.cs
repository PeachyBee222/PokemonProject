using DataAccess2;
using PokemonCollections.Data.Models;

namespace PokemonCollections.Data.DataDelegates
{
    /// <summary>
    /// The data delegate to call our procedure for calling the UserStatBlockRanking aggregated query
    /// Gets the average stat block ranking for the users
    /// </summary>
    internal class GetUserStatBlockRankingDataDelegate : DataReaderDelegate<List<User>>
    {
        public GetUserStatBlockRankingDataDelegate()
            : base("Pokemon.GetUserStatBlockRanking")
        {
        }

        public override List<User> Translate(Command command, IDataRowReader reader)
        {
            var users = new List<User>();

            while (reader.Read())
            {
                var input = new User(
                    reader.GetInt32("UserID"),
                    reader.GetString("Email"));
                input.SetAverageTotal(reader.GetInt32("AverageStatBlockTotal"));
                users.Add(input);
            }

            return users;
        }
    }
}
