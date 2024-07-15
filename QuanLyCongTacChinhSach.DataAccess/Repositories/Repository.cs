using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace QuanLyCongTacChinhSach.DataAccess.IRepositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly string _connectionString = "Server=125.212.218.93\\MSSQLSERVER2022;Database=ciucynhk_DbDev;User Id=ciucynhk_dev;Password=LebJXti9pGtWcfZodHeuuBem5nX4Dmvh;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=true";

        public Repository()
        {
        }

        public async Task<bool> Add(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string spName = $"SP_{typeof(T).Name}_Insert";
                var parameters = GetDynamicParameters(entity);
                int affectedRows = await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }
        private DynamicParameters GetDynamicParameters(T entity)
        {
            var parameters = new DynamicParameters();

            foreach (var property in typeof(T).GetProperties())//dùng Reflection
            {
                var value = property.GetValue(entity);
                if (value != null)
                {
                    parameters.Add($"@{property.Name}", value);
                }
            }

            return parameters;
        }
        public async Task<bool> Update(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string spName = $"SP_{typeof(T).Name}_Update";
                var parameters = new DynamicParameters(entity);
                int affectedRows = await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }

        public async Task<bool> Delete(object id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string spName = $"SP_{typeof(T).Name}_Delete";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                int affectedRows = await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
                return affectedRows > 0;
            }
        }

        public async Task<T> GetById(object id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string spName = $"SP_{typeof(T).Name}_GetById";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return await connection.QuerySingleOrDefaultAsync<T>(spName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string spName = $"SP_{typeof(T).Name}_GetAll";
                return await connection.QueryAsync<T>(spName, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<(IEnumerable<dynamic> Items, int TotalRecords)> Search(string searchTerm, int pageIndex, int pageSize)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string spName = $"SP_{typeof(T).Name}_Search";
                var parameters = new DynamicParameters();
                parameters.Add("@SearchTerm", searchTerm);
                parameters.Add("@PageIndex", pageIndex);
                parameters.Add("@PageSize", pageSize);
                parameters.Add("@TotalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var items =await connection.QueryAsync<dynamic>(spName, parameters, commandType: CommandType.StoredProcedure);
                int totalRecords = parameters.Get<int>("@TotalRecords");

                return (items, totalRecords);
            }
        }
    }

}
