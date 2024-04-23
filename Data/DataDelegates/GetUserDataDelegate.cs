using TheFlyingSaucer.Data.Models;
using DataAccess2;

namespace TheFlyingSaucer.Data.DataDelegates
{
    public class GetUserDataDelegate : DataReaderDelegate<Dictionary<User,Pokemon>>
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

        public override Dictionary<User, Pokemon> Translate(Command command, IDataRowReader reader)
        {
            if (!reader.Read())
                return null;

            var userPokemon = new Dictionary<User, Pokemon>();

            while (reader.Read())
            {
                var user = new User(
                    reader.GetInt32("UserID"),
                    reader.GetString("Email"));

                ElementType pelem;
                ElementType selem;
                //FIXME i need to know the names of these exactly
                Enum.TryParse<ElementType>(reader.GetString("PrimaryElement"), true, out pelem);
                Enum.TryParse<ElementType>(reader.GetString("SecondaryElement"), true, out selem);
                var pokemon = new Pokemon(
                    reader.GetInt32("CreatureID"),
                    reader.GetInt32("GenerationNum"),
                    reader.GetString("Name"),
                    reader.GetInt32("BaseHP"),
                    reader.GetInt32("Attack"),
                    reader.GetInt32("Defense"),
                    reader.GetInt32("Speed"),
                    pelem,
                    selem
                    );

                userPokemon.Add(user, pokemon);
            }

            return userPokemon;
        }
    }
}
