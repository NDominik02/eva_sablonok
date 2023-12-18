using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockDocu.Model
{
    public class BlockDocuFileDataAccess : IBlockDocuDataAccess
    {
        public async Task<(BlockDocuTable, BlockDocuTable)> LoadAsync(String path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                { 
                    String line = await reader.ReadLineAsync() ?? String.Empty;
                    String[] numbers  = line.Split(' ');
                    Int32 tableSize = Int32.Parse(numbers[0]);
                    BlockDocuTable table = new BlockDocuTable(tableSize);
                    BlockDocuTable shapeTable = new BlockDocuTable(2);
                    table.PointsT = Int32.Parse(numbers[1]);
                    table.ShapeNumT = Int32.Parse(numbers[2]);

                    for (int i = 0; i < tableSize; i++)
                    {
                        line = await reader.ReadLineAsync() ?? String.Empty;
                        numbers = line.Split(" ");

                        for (int j = 0; j < tableSize; j++)
                        {
                            if (numbers[j] == "1")
                            {
                                table.SetOwned(i, j, true);
                            }
                        }
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        line = await reader.ReadLineAsync() ?? String.Empty;
                        numbers = line.Split(" ");

                        for (int j = 0; j < 2; j++)
                        {
                            if (numbers[j] == "1")
                            {
                                shapeTable.SetOwned(i, j, true);
                            }
                        }
                    }

                    return (table, shapeTable);
                }
            }
            catch
            {
                throw new BlockDocuDataException();
            }
        }

        public async Task SaveAsync(String path, BlockDocuTable table, BlockDocuTable shapeTable)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(table.Size);
                    await writer.WriteAsync(" " + table.PointsT);
                    await writer.WriteLineAsync(" " + table.ShapeNumT);
                    for (int i = 0; i < table.Size; i++)
                    {
                        for (int j = 0; j < table.Size; j++)
                        {
                            await writer.WriteAsync((table.IsOwned(i, j) ? "1" : "0") + " ");
                        }
                        await writer.WriteLineAsync();
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            await writer.WriteAsync((shapeTable.IsOwned(i, j) ? "1" : "0") + " ");
                        }
                        await writer.WriteLineAsync();
                    }
                }
            }
            catch
            {
                throw new BlockDocuDataException();
            }
        }
    }
}
