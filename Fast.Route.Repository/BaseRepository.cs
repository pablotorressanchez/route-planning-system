using Fast.Route.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Fast.Route.Repository
{
    public class BaseRepository
    {
        protected BaseRepository(AppSettings appSettings) 
        {
            Connection = new SqlConnection(appSettings.ConnectionString);
        }

        public IDbConnection Connection { get; set; }
        //public SqlConnection Connection { get; set; }
    }
}
