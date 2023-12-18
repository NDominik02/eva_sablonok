using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Persistence
{
    public class GameFileDataAccess : IGameDataAccess
    {
        public async Task<GameTable> LoadAsync(String path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path)) // fájl megnyitása
                {
                    GameTable table = new GameTable();

                    return table;
                }
            }
            catch
            {
                throw new GameDataException();
            }
        }

        public async Task SaveAsync(String path, GameTable table)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path)) // fájl megnyitása
                {

                }
            }
            catch
            {
                throw new GameDataException();
            }
        }
    }
}
