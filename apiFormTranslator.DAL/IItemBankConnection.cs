using System;
using System.Data;
using System.Data.SqlClient;

namespace apiFormTranslator.DAL
{
    public abstract class IItemBankConnection
    {
        private const string CONNECTION_STRING = "itembank_dbConnectionString";
        private const string RESULTS = "results";
        private const int NO_TIME_OUT = 0;

        protected DataTable ExecuteSqlCommand(SqlCommand command)
        {
            try
            {
                if (command.Connection == null)
                {
                    command.Connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[CONNECTION_STRING].ConnectionString);
                }

                var dtReturn = new DataTable();

                using (command.Connection)
                {
                    command.CommandTimeout = NO_TIME_OUT;

                    using (var ds = new DataSet(RESULTS))
                    {
                        using (var da = new SqlDataAdapter(command))
                        {
                            da.Fill(dtReturn);
                        }
                    }
                }
                return dtReturn;
            }
            catch (Exception ex)
            {
                throw new Exception("Error connecting to the ItemBank DB", ex);
            }
        }
    }
}
