using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonProject.Data.Models
{
    public class Pokemon
    {
        public int CreatureID { get; }
        public int GenerationNum { get; }
        public string Name { get; }
        public int BaseHP { get; }
        public int Attack { get; }
        public int Defense { get; }
        public int Speed { get; }
        public int Total { get; }
        /*public ElementType Pelem { get; }
        public ElementType Selem { get; }*/


        /// <summary>
        /// Constructor for pokemon
        /// </summary>
        /// <param name="creatureID"></param>
        /// <param name="generationID"></param>
        /// <param name="name"></param>
        /// <param name="baseHP"></param>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="speed"></param>
        public Pokemon(int creatureID, int generationNum, string name, int baseHP,
            int attack, int defense, int speed/*, ElementType pelem, ElementType? selem*/)
        {
            CreatureID = creatureID;
            GenerationNum = generationNum;
            Name = name;
            BaseHP = baseHP;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            //Pelem = pelem;
            //Selem = selem ?? ElementType.none; //it will be none if its null

            Total = baseHP + attack + defense + speed;
        }


    }
}