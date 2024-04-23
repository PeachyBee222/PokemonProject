namespace TheFlyingSaucer.Data.Models
{
    /// <summary>
    /// the model class for the pokemon
    /// </summary>
    public class Pokemon
    {
        /// <summary>
        /// The id for the creature
        /// </summary>
        public int CreatureID { get; }

        /// <summary>
        /// generation the creature was first created in
        /// </summary>
        public int GenerationNum { get; }

        /// <summary>
        /// the name of the pokemon
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// the base health a pokemon will start with
        /// </summary>
        public int BaseHP { get; }

        /// <summary>
        /// the base attack number the pokemon will start with
        /// </summary>
        public int Attack { get; }

        /// <summary>
        /// the base defense number the pokemon will start with
        /// </summary>
        public int Defense { get; }

        /// <summary>
        /// the base speed the pokemon will start with
        /// </summary>
        public int Speed { get; }

        /// <summary>
        /// the total of the HP, attack, defense, and speed of the pokemon
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// the primary element of the pokeon
        /// </summary>
        public ElementType Pelem { get; }

        /// <summary>
        /// the secondary element of the pokemon if it has one
        /// ElementType.none if it does not have one
        /// </summary>
        public ElementType Selem { get; }

        /// <summary>
        /// the total number of users for each pokemon
        /// </summary>
        public int NumUsers { get; private set;  }


        /// <summary>
        /// Constructor for pokemon
        /// </summary>
        /// <param name="creatureID"></param>
        /// <param name="generationNum"></param>
        /// <param name="name"></param>
        /// <param name="baseHP"></param>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="speed"></param>
        /// <param name="pelem"></param>
        /// <param name="selem"></param>
        /// <param name="numUsers"></param>
        public Pokemon(int creatureID, int generationNum, string name, int baseHP,
            int attack, int defense, int speed, ElementType pelem, ElementType? selem, int numUsers)
        {
            CreatureID = creatureID;
            GenerationNum = generationNum;
            Name = name;
            BaseHP = baseHP;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            Pelem = pelem;
            Selem = selem ?? ElementType.none; //it will be none if its null
            NumUsers = numUsers;

            Total = baseHP + attack + defense + speed;
        }

        /// <summary>
        /// Constructor for pokemon
        /// </summary>
        /// <param name="creatureID"></param>
        /// <param name="generationNum"></param>
        /// <param name="name"></param>
        /// <param name="baseHP"></param>
        /// <param name="attack"></param>
        /// <param name="defense"></param>
        /// <param name="speed"></param>
        /// <param name="pelem"></param>
        /// <param name="selem"></param>
        public Pokemon(int creatureID, int generationNum, string name, int baseHP,
            int attack, int defense, int speed, ElementType pelem, ElementType? selem)
        {
            CreatureID = creatureID;
            GenerationNum = generationNum;
            Name = name;
            BaseHP = baseHP;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            Pelem = pelem;
            Selem = selem ?? ElementType.none; //it will be none if its null

            Total = baseHP + attack + defense + speed;
        }

        /// <summary>
        /// Sets the number of users each pokemon has
        /// </summary>
        /// <param name="numUsers">current number of users for this specific pokemon</param>
        public void SetNumUsers(int numUsers)
        {
            NumUsers = numUsers;
        }

    }
}