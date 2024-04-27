using DataAccess2;
using PokemonCollections.Data.Models;
using System.Data;

namespace PokemonCollections.Data.DataDelegates
{
    /// <summary>
    /// The data delegate to call our procedure for creating a brand new user
    /// </summary>
    public class CreateUserDataDelegate : NonQueryDataDelegate<User>
    {
        public readonly string Email;
        public CreateUserDataDelegate(string email)
            : base("Pokemon.AddUser")
        {
            this.Email = email;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Email", Email);

            var p = command.Parameters.Add("UserID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override User Translate(Command command)
        {
            return new User(
                command.GetParameterValue<int>("UserID"),
                Email
                );
        }
    }
}
