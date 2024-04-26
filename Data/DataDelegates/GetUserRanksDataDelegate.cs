﻿using DataAccess2;
using PokemonCollections.Data.Models;

namespace PokemonCollections.Data.DataDelegates
{
    internal class GetUserRanksDataDelegate : DataReaderDelegate<List<User>>
    {
        public GetUserRanksDataDelegate()
            : base("Pokemon.GetUserRanks")
        {
        }

        public override List<User> Translate(Command command, IDataRowReader reader)
        {
            var users = new List<User>();

            while (reader.Read())
            {
                var input = new User(
                    reader.GetInt32("UserID"),
                    reader.GetString("Email"));
                input.SetNumPokemon(reader.GetInt32("NumberOfPokemon"));
                users.Add(input);
            }

            return users;
        }
    }
}
