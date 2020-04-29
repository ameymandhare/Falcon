using Enum;
using DataAccess.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Class FactoryDataAccess.
    /// </summary>
    public class FactoryDataAccess
    {
        /// <summary>
        /// The Default provider
        /// </summary>
        Provider DefaultProvider = Provider.MsSqlServer;
        /// <summary>
        /// The Connection string
        /// </summary>
        private string ConnString = "";
        /// <summary>
        /// Initializes a new instance of the <see cref="FactoryDataAccess"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <exception cref="System.Exception">Connection string should not be empty</exception>
        public FactoryDataAccess(Provider provider, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString) || string.IsNullOrWhiteSpace(connectionString))
                throw new Exception("Connection string should not be empty");
            if (provider == Provider.MsSqlServer)
            {
                try
                {
                    var connBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid Connection string \n" + ex.Message);
                }

            }
            DefaultProvider = provider;
            ConnString = connectionString;

        }

        /// <summary>
        /// Gets the data access.
        /// </summary>
        /// <returns>IDataAccess.</returns>
        public IDataAccess GetDataAccess()
        {
            IDataAccess iDataAccess = null;
            switch (DefaultProvider)
            {
                case Provider.MsSqlServer:
                    iDataAccess = new MsSqlDataAccess(ConnString);
                    break;
                case Provider.Oracle:
                    iDataAccess = new OracleDataAccess();
                    break;
            }
            return iDataAccess;
        }
    }
}
