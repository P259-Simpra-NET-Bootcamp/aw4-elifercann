using Dapper;
using SimApi.Base;
using SimApi.Data.Context;
using System.Data;

namespace SimApi.Data.Repository
{
    public class DapperRepository<TEntity> : IDapperRepository<TEntity> where TEntity : BaseModel
    {
        private readonly SimDapperDbContext _dapperDbContext;

        public DapperRepository(SimDapperDbContext dapperDbContext)
        {
            _dapperDbContext = dapperDbContext;
        }

        public List<TEntity> GetAll()
        {
            string sql = $"SELECT * FROM {GetTableName()}";
            return _dapperDbContext.CreateConnection().Query<TEntity>(sql).ToList();
        }

        public List<TEntity> Filter(string sql)
        {
            return _dapperDbContext.CreateConnection().Query<TEntity>(sql).ToList();
        }

        public TEntity GetById(int id)
        {
            string sql = $"SELECT * FROM {GetTableName()} WHERE Id = @Id";
            return _dapperDbContext.CreateConnection().QuerySingleOrDefault<TEntity>(sql, new { Id = id });
        }

        public void Insert(TEntity entity)
        {
            string sql = $"INSERT INTO {GetTableName()} (Id, Column1, Column2, ...) VALUES (@Id, @Column1, @Column2, ...)";
            _dapperDbContext.CreateConnection().Execute(sql, entity);
        }

        public void Update(TEntity entity)
        {
            var entityType = typeof(TEntity);
            var properties = entityType.GetProperties();

            var updateColumns = properties.Select(p => $"{p.Name} = @{p.Name}").ToList();
            string sql = $"UPDATE {GetTableName()} SET {string.Join(", ", updateColumns)} WHERE Id = @Id";

            _dapperDbContext.CreateConnection().Execute(sql, entity);
        }

        public void DeleteById(int id)
        {
            string sql = $"DELETE FROM {GetTableName()} WHERE Id = @Id";
            _dapperDbContext.CreateConnection().Execute(sql, new { Id = id });
        }

        private string GetTableName()
        {
            var entityType = typeof(TEntity);
            var attribute = entityType.GetCustomAttributes(false).SingleOrDefault(a => a.GetType().Name == "TableAttribute");
            var tableName = attribute?.GetType().GetProperty("Name")?.GetValue(attribute, null) as string;
            return tableName ?? entityType.Name;
        }
    }
}
