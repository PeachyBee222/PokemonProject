using TheFlyingSaucer.Data.Models;
using DataAccess2;

namespace TheFlyingSaucer.Data.DataDelegates
{
    public class GetUserDataDelegate : DataReaderDelegate<User>
    {
        private readonly string Email;

        public GetUserDataDelegate(string email)
            : base("Pokemon.GetUser")
        {
            this.Email = email;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("Email", Email);
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
