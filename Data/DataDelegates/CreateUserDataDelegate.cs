using DataAccess2;
using TheFlyingSaucer.Data.Models;
using System.Data;

namespace TheFlyingSaucer.Data.DataDelegates
{
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
