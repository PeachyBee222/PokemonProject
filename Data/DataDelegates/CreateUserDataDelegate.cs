using DataAccess;
using PokemonProject.Data.Models;
using System.Data;

namespace PokemonProject.Data.DataDelegates
{
    internal class CreateUserDataDelegate : NonQueryDataDelegate<User>
    {
        public readonly string Email;
        public CreateUserDataDelegate(string email)
            : base("Pokemon.CreateUser")
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
                command.GetParameterValue<int>("CreatureID"),
                Email
                );
        }
    }
}
