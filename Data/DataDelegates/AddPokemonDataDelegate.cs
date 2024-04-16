using DataAccess;
using PokemonProject.Data.Models;
using System.Data;

namespace PokemonProject.Data.DataDelegates
{
    internal class AddPokemonDataDelegate : NonQueryDataDelegate<UserPokemon>
    {
        public readonly int PokemonID;
        public readonly string NickName;

        public AddPokemonDataDelegate(int PokemonID, string nickname)
            : base("Pokemon.AddPokemon")
        {
            this.PokemonID = PokemonID;
            this.NickName = nickname;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("PokemonID", PokemonID);
            command.Parameters.AddWithValue("NickName", NickName);
        }

        public override UserPokemon Translate(Command command)
        {
            return new UserPokemon(
                PokemonID,
                NickName ?? string.Empty
                );
        }
    }
}
