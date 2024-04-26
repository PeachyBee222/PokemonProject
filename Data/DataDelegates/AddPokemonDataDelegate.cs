using DataAccess2;
using System.Data;
using PokemonCollections.Data.Models;

namespace PokemonCollections.Data.DataDelegates
{
    public class AddPokemonDataDelegate : NonQueryDataDelegate<UserPokemon>
    {
        public readonly int PokemonID;
        public readonly string Nickname;
        public readonly string Email;

        public AddPokemonDataDelegate(int pokemonID, string nickname, string userEmail)
            : base("Pokemon.AddPokemon")
        {
            this.PokemonID = pokemonID;
            this.Nickname = nickname;
            this.Email = userEmail;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("PokemonID", PokemonID);
            if (Nickname == null)
            {
                // Add @ElementTypeSecondary with a NULL value
                command.Parameters.AddWithValue("Nickname", DBNull.Value);
            }
            else
            {
                // Add @ElementTypeSecondary with its actual value
                command.Parameters.AddWithValue("Nickname", Nickname);
            }
            command.Parameters.AddWithValue("Email", Email);
        }

        public override UserPokemon Translate(Command command)
        {
            Pokemon pokemon = new Pokemon(0, 0, "Blah", 0, 0, 0, 0, ElementType.fire, ElementType.none);

            return new UserPokemon(pokemon, Email, Nickname);
        }
    }
}