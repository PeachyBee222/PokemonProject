using TheFlyingSaucer.Data.Models;
using System.Data;
using DataAccess2;

namespace TheFlyingSaucer.Data.DataDelegates
{
    internal class CreatePokemonDataDelegate : NonQueryDataDelegate<Pokemon>
    {
        public readonly int GenerationNum;
        public readonly string Name;
        public readonly int BaseHP;
        public readonly int Attack;
        public readonly int Defense;
        public readonly int Speed;
    
        public CreatePokemonDataDelegate(int generationNum, string name, int baseHP, int attack, int defense, int speed)
            :base("Pokemon.CreatePokemon")
        {
            this.GenerationNum = generationNum;
            this.Name = name;
            this.BaseHP = baseHP;
            this.Attack = attack;
            this.Defense = defense;
            this.Speed = speed;
        }

        public override void PrepareCommand(Command command)
        {
            base.PrepareCommand(command);

            command.Parameters.AddWithValue("GenerationNum", GenerationNum);
            command.Parameters.AddWithValue("Name", Name);
            command.Parameters.AddWithValue("BaseHP", BaseHP);
            command.Parameters.AddWithValue("Attack", Attack);
            command.Parameters.AddWithValue("Defense", Defense);
            command.Parameters.AddWithValue("Speed", Speed);

            var p = command.Parameters.Add("CreatureID", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;
        }

        public override Pokemon Translate(Command command)
        {
            return new Pokemon(command.GetParameterValue<int>("CreatureID"), GenerationNum, Name, BaseHP, Attack, Defense, Speed);
        }
    }
}
