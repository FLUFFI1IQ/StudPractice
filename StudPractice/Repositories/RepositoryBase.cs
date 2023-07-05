using System.Data.SqlClient;
using System.Data.SqlTypes;
namespace StudPractice.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Data Source=DESKTOP-FQ47L6A\\SQLEXPRESS;Initial Catalog=Aviasales;Integrated Security=True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection( _connectionString );
        }
    }
}
