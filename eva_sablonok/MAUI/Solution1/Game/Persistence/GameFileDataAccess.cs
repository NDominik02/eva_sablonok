using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Persistence
{
    public class FileDataAccess : IGameDataAccess
    {
        private string? _directory = String.Empty;

        public FileDataAccess(string? saveDirectory = null)
        {
            _directory = saveDirectory;
        }
        public async Task<GameTable> LoadAsync(String path)
        {
            if (!String.IsNullOrEmpty(_directory))
                path = Path.Combine(_directory, path);

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
            if (!String.IsNullOrEmpty(_directory))
                path = Path.Combine(_directory, path);

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
