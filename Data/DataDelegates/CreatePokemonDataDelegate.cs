using PokemonCollections.Data.Models;
using System.Data;
using DataAccess2;
using System.Reflection.PortableExecutable;

namespace PokemonCollections.Data.DataDelegates
{
    public class CreatePokemonDataDelegate : NonQueryDataDelegate<Pokemon>
    {
        public readonly int GenerationNum;
        public readonly string PokemonName;
        public readonly int BaseHP;
        public readonly int Attack;
        public readonly int Defense;
        public readonly int Speed;
        public readonly ElementType ElementTypePrimary;
        public readonly ElementType ElementTypeSecondary;

        public CreatePokemonDataDelegate(int generationNum, string name, int baseHP, int attack, int defense, int speed, ElementType pelem, ElementType selem)
            : base("Pokemon.CreatePokemon")
        {
            this.GenerationNum = generationNum;
            this.PokemonName = name;
            this.BaseHP = baseHP;
            this.Attack = attack;
            this.Defense = defense;
            this.Speed = speed;
            this.ElementTypePrimary = pelem;
            this.ElementTypeSecondary = selem;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("GenerationNum", GenerationNum);
            command.Parameters.AddWithValue("PokemonName", PokemonName);
            command.Parameters.AddWithValue("BaseHP", BaseHP);
            command.Parameters.AddWithValue("Attack", Attack);
            command.Parameters.AddWithValue("Defense", Defense);
            command.Parameters.AddWithValue("Speed", Speed);
            command.Parameters.AddWithValue("ElementTypePrimary", ElementTypePrimary.ToString());
            if (ElementTypeSecondary == ElementType.none)
            {
                // Add @ElementTypeSecondary with a NULL value
                command.Parameters.AddWithValue("ElementTypeSecondary", DBNull.Value);
            }
            else
            {
                // Add @ElementTypeSecondary with its actual value
                command.Parameters.AddWithValue("ElementTypeSecondary", ElementTypeSecondary.ToString());
            }

            var p = command.Parameters.Add("CreatureID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Pokemon Translate(Command command)
        {
            return (new Pokemon(
                command.GetParameterValue<int>("CreatureID"),
                GenerationNum,
                PokemonName,
                BaseHP,
                Attack,
                Defense,
                Speed,
                ElementTypePrimary,
                ElementTypeSecondary,
                0
                ));
        }
    }
}
