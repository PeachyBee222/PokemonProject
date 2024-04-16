using PokemonProject.Data.Models;
using DataAccess;

namespace PokemonProject.Data.DataDelegates
{
    internal class GetUserDataDelegate : DataReaderDelegate<User>
    {
        private readonly string UserEmail;

        public GetUserDataDelegate(string email)
            : base("Pokemon.GetUser")
        {
            this.UserEmail = email;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Email", UserEmail);
        }

        public override User Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read()) return null;
            return new User(
                reader.GetInt32("UserID"),
                reader.GetString("Email")
                );
        }
    }
}
