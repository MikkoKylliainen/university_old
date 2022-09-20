using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;

namespace university
{
    public class Administrator
    {
        public int idadministrator { get; set; }
        public string category { get; set; }

        internal Database Db { get; set; }

        public Administrator()
        {
        }

        internal Administrator(Database db)
        {
            Db = db;
        }

        public async Task<List<Administrator>> GetAllAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM  administrator ;";
            var result=await ReturnAllAsync(await cmd.ExecuteReaderAsync());
           // Console.WriteLine(result);
            return await ReturnAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task<User> FindOneAsync(int idadministrator)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM  administrator  WHERE  idadministrator  = @idadministrator";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@idadministrator",
                DbType = DbType.Int32,
                Value = idadministrator,
            });
            var result = await ReturnAllAsync(await cmd.ExecuteReaderAsync());
            Console.WriteLine(result.Count);
            if(result.Count > 0){
                return result[0];
            }
            else {
                return null;
            }
            //return result.Count > 0 ? result[0] : null;
        }


        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM  administrator ";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }
    

        public async Task<int> InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText=@"insert into user(idadministrator,category) 
            values(@idadministrator,@category);";
            BindParams(cmd);
            try
            {
                await cmd.ExecuteNonQueryAsync();
                int lastInsertId = (int) cmd.LastInsertedId; 
                return lastInsertId;
            }
            catch (System.Exception)
            {   
                return 0;
            } 
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE  administrator  SET  idadministrator = @idadministrator,  category = @category WHERE  idadministrator  = @idadministrator;";
            BindParams(cmd);
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM  administrator  WHERE  idadministrator  = @idadministrator;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private async Task<List<Administrator>> ReturnAllAsync(DbDataReader reader)
        {
            var posts = new List<Administrator>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new Administrator(Db)
                    {
                        idadministrator = reader.GetInt32(0),
                        category = reader.GetString(1),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
        
        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@idadministrator",
                DbType = DbType.Int32,
                Value = idadministrator,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@category",
                DbType = DbType.String,
                Value = category,
            });
        }
    }
}