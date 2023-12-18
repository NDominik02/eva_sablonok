using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockDocu.Model
{
    public interface IBlockDocuDataAccess
    {
        Task<(BlockDocuTable, BlockDocuTable)> LoadAsync(String path);

        Task SaveAsync(String path, BlockDocuTable table, BlockDocuTable shapeTable);
    }
}
