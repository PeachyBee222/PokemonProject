using DataAccess2;
using System.Data;
using TheFlyingSaucer.Data.Models;

namespace TheFlyingSaucer.Data.DataDelegates
{
    public class AddPokemonDataDelegate : NonQueryDataDelegate<UserPokemon>
    {
        public readonly Pokemon pokemon;
        public readonly string NickName;

        public AddPokemonDataDelegate(Pokemon pokemon, string nickname)
            : base("Pokemon.AddPokemon")
        {
            this.pokemon = pokemon;
            this.NickName = nickname;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("Pokemon", pokemon);
            command.Parameters.AddWithValue("NickName", NickName);
        }

        public override UserPokemon Translate(Command command)
        {
            return new UserPokemon(
                pokemon,
                NickName ?? string.Empty
                );
        }
    }
}