using DataAccess2;
using System.Data;
using TheFlyingSaucer.Data.Models;

namespace TheFlyingSaucer.Data.DataDelegates
{
    public class AddPokemonDataDelegate : NonQueryDataDelegate<UserPokemon>
    {
        public readonly int PokemonName;
        public readonly string Nickname;
        public readonly string Email;

        public AddPokemonDataDelegate(int pokemonName, string nickname, string userEmail)
            : base("Pokemon.AddPokemon")
        {
            this.PokemonName = pokemonName;
            this.Nickname = nickname;
            this.Email = userEmail;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);
            command.Parameters.AddWithValue("Name", PokemonName);
            command.Parameters.AddWithValue("Nickname", Nickname);
        }

        public override UserPokemon Translate(Command command)
        {
            int PokemonID = command.GetParameterValue<int>("CreatureID");
            int GenerationNum = command.GetParameterValue<int>("GenerationNum");
            string Name = command.GetParameterValue<string>("Name");
            int BaseHP = command.GetParameterValue<int>("BaseHP");
            int Attack = command.GetParameterValue<int>("Attack");
            int Defense = command.GetParameterValue<int>("Defense");
            int Speed = command.GetParameterValue<int>("Speed");
            int ElementOne = command.GetParameterValue<int>("ElementTypePrimary");   //FIXME to match up witch SQL
            int ElementTwo = command.GetParameterValue<int>("ElementTypeSecondary");
            int NumUsers = command.GetParameterValue<int>("NumUsers");

            Enum.TryParse(ElementOne.ToString(), out ElementType primary);
            Enum.TryParse(ElementTwo.ToString(), out ElementType secondary);

            Pokemon pokemon = new Pokemon(PokemonID, GenerationNum, Name, BaseHP, Attack, Defense, Speed, primary, secondary, NumUsers);

            return new UserPokemon(
                pokemon,
                Nickname ?? string.Empty
                );
        }
    }
}