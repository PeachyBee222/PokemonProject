using PokemonCollections.Data.Models;
using DataAccess2;

namespace PokemonCollections.Data.DataDelegates
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

            var userPokemon = new Dictionary<User, Pokemon>();

            reader.Read();

            var user = new User(
                    reader.GetInt32("UserID"),
                    reader.GetString("Email"));

            int index = 0;

            if(reader.GetString("PrimaryElement") == "none")
            {
                return userPokemon;
            }
            do
            {
                ElementType pelem;
                ElementType selem;
                //FIXME i need to know the names of these exactly
                Enum.TryParse<ElementType>(reader.GetString("PrimaryElement"), true, out pelem);
                Enum.TryParse<ElementType>(reader.GetString("SecondaryElement"), true, out selem);
                var pokemon = new Pokemon(
                    reader.GetInt32("CreatureID"),
                    reader.GetInt32("GenerationNum"),
                    reader.GetString("CreatureName"),
                    reader.GetInt32("HP"),
                    reader.GetInt32("Attack"),
                    reader.GetInt32("Defense"),
                    reader.GetInt32("Speed"),
                    pelem,
                    selem
                    );
                user.SetUserPokemon(pokemon, reader.GetString("Nickname"));
                
                if(index == 0)
                {
                    userPokemon.Add(user, pokemon);
                }
                else
                {
                    userPokemon.Add(new User(
                    reader.GetInt32("UserID"),
                    reader.GetString("Email")), pokemon);
                }
                index++;
            } while (reader.Read());

            return userPokemon;
        }
    }
}
