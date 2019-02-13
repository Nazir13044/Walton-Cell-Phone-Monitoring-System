using Oracle.ManagedDataAccess.Client;

namespace UpdateEmployeesInKPIProject
{
    public class OracleDatabaseConnection
    {
        public static OracleConnection GetHrmsDbConnection()
        {
            const string connectionString = "Data Source=(DESCRIPTION="
                                            + "(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.150.5)(PORT=1521))"
                                            + "(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=hrpos)));"
                                            + "User Id=HRMS_LNK_SOFT;Password=XVP8X3;";

            var connection = new OracleConnection(connectionString);
            return connection;
        }
        public static OracleConnection GetNewConnection()
        {
            const string connectionString = "Data Source=(DESCRIPTION="
                                            + "(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.150.46)(PORT=1521))"
                                            + "(CONNECT_DATA=(SERVICE_NAME=PROD)));"
                                            + "User Id=APPSWG;Password=APPSWG#;";

            var newConnection = new OracleConnection(connectionString);
            return newConnection;
        }
        public static OracleConnection GetOldConnection()
        {
            const string connectionString = "Data Source=(DESCRIPTION="
                                            + "(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.150.49)(PORT=1521))"
                                            + "(CONNECT_DATA=(SERVICE_NAME=PROD)));"
                                            + "User Id=APPSRBG;Password=appsrbg;";
            //const string connectionString = "Data Source=(DESCRIPTION="
            //                           + "(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.100.181)(PORT=1521))"
            //                           + "(CONNECT_DATA=(SERVICE_NAME=PROD)));"
            //                           + "User Id=APPSRBG;Password=appsrbg;";
            var oldConnection = new OracleConnection(connectionString);
            return oldConnection;
        }

        //new connection to push data to oracle 

        public static OracleConnection GetImeiOracleConnection()
        {
            const string connectionString = "Data Source=(DESCRIPTION="
                                            + "(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.100.172)(PORT=1561))"
                                            + "(CONNECT_DATA=(SERVICE_NAME=PROD)));"
                                            + "User Id=apps;Password=apps;";
            //const string connectionString = "Data Source=(DESCRIPTION="
            //                           + "(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.100.181)(PORT=1521))"
            //                           + "(CONNECT_DATA=(SERVICE_NAME=PROD)));"
            //                           + "User Id=APPSRBG;Password=appsrbg;";
            var oldConnection = new OracleConnection(connectionString);
            return oldConnection;
        }





    }
}
