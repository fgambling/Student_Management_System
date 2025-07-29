using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Util;

namespace Student.MsSqlHelper
{
    /// <summary>
    /// SQL Server Database Helper class providing comprehensive database operations.
    /// This class handles all database interactions including queries, stored procedures,
    /// transactions, and parameterized operations for the Student Management System.
    /// </summary>
    public class YFMsSqlHelper
    {
        /// <summary>
        /// Database connection string retrieved from application configuration
        /// </summary>
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["xiaobai"].ConnectionString;

        #region Common Method

        /// <summary>
        /// Gets the next available ID for a specified field in a table
        /// </summary>
        /// <param name="FieldName">Name of the ID field</param>
        /// <param name="TableName">Name of the table</param>
        /// <returns>Next available ID (max + 1)</returns>
        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        /// <summary>
        /// Checks if a record exists based on the provided SQL query
        /// </summary>
        /// <param name="strSql">SQL query to execute</param>
        /// <returns>True if record exists, false otherwise</returns>
        public static bool Exists(string strSql)
        {
            object obj = GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if a record exists based on the provided SQL query with parameters
        /// </summary>
        /// <param name="strSql">SQL query to execute</param>
        /// <param name="cmdParms">SQL parameters</param>
        /// <returns>True if record exists, false otherwise</returns>
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region  Execute simple SQL statements

        /// <summary>
        /// Execute the SQL statement and return the number of records affected
        /// </summary>
        /// <param name="SQLString">SQL statement</param>
        /// <returns>The number of records affected</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Execute SQL statements and set the execution waiting time of the command
        /// </summary>
        /// <param name="SQLString">SQL statement to execute</param>
        /// <param name="Times">Timeout in seconds</param>
        /// <returns>Number of records affected</returns>
        public static int ExecuteSqlByTime(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Execute multiple SQL statements to implement database transactions.
        /// </summary>
        /// <param name="SQLStringList">Multiple SQL statements</param>		
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }

        /// <summary>
        /// Execute a SQL statement with a stored procedure parameter.
        /// </summary>
        /// <param name="SQLString">SQL statement</param>
        /// <param name="content">Content parameter</param>
        /// <returns>Number of records affected</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                SqlParameter myParameter = new SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Execute a SQL statement with a stored procedure parameter and return a value.
        /// </summary>
        /// <param name="SQLString">SQL statement</param>
        /// <param name="content">Content parameter</param>
        /// <returns>Object result from the query</returns>
        public static object ExecuteSqlGet(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                SqlParameter myParameter = new SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Insert image format fields into the database (another example similar to the above)
        /// </summary>
        /// <param name="strSQL">SQL statement</param>
        /// <param name="fs">Image bytes, when the database field type is image</param>
        /// <returns>Number of records affected</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                SqlParameter myParameter = new SqlParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Execute a query result calculation statement and return the query result (object).
        /// </summary>
        /// <param name="SQLString">SQL query statement</param>
        /// <returns>Query result as object</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Execute the query statement and return the SqlDataReader (remember to manually close the SqlDataReader and connection when using this method)
        /// </summary>
        /// <param name="strSQL">SQL query statement</param>
        /// <returns>SqlDataReader object</returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            //finally 
            //{
            //	cmd.Dispose();
            //	connection.Close();
            //}	
        }

        /// <summary>
        /// Execute the query statement and return the DataSet
        /// </summary>
        /// <param name="SQLString">Query statement</param>
        /// <returns>DataSet containing query results</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// Execute the query statement and return the DataSet with custom table name
        /// </summary>
        /// <param name="SQLString">Query statement</param>
        /// <param name="TableName">Custom table name for the DataSet</param>
        /// <returns>DataSet containing query results</returns>
        public static DataSet Query(string SQLString, string TableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, TableName);
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>
        /// Execute the query statement, return the DataSet, and set the execution waiting time of the command.
        /// </summary>
        /// <param name="SQLString">Query statement</param>
        /// <param name="Times">Timeout in seconds</param>
        /// <returns>DataSet containing query results</returns>
        public static DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        #endregion

        #region Execute SQL statement with parameters

        /// <summary>
        /// Execute the SQL statement and return the number of records affected
        /// </summary>
        /// <param name="SQLString">SQL statement</param>
        /// <param name="cmdParms">SQL parameters</param>
        /// <returns>The number of records affected</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (SqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Execute multiple SQL statements to implement database transactions.
        /// </summary>
        /// <param name="SQLStringList">Hash table of SQL statements</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //loop
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            trans.Commit();
                        }
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Execute a statement to calculate the query results and return the query results（object）。
        /// </summary>
        /// <param name="SQLString">SQL query statement</param>
        /// <param name="cmdParms">SQL parameters</param>
        /// <returns>Query result（object）</returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Execute the query statement, return SqlDataReader (remember to manually close SqlDataReader and connection when using this method)
        /// </summary>
        /// <param name="SQLString">Query statement</param>
        /// <param name="cmdParms">SQL parameters</param>
        /// <returns>SqlDataReader object</returns>
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            //finally //Cannot close here, otherwise the returned object will be unusable
            //{
            //	cmd.Dispose();
            //	connection.Close();
            //}	

        }

        /// <summary>
        /// Execute the query statement, return DataSet
        /// </summary>
        /// <param name="SQLString">Query statement</param>
        /// <param name="cmdParms">SQL parameters</param>
        /// <returns>DataSet containing query results</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        /// <summary>
        /// Prepare SQL command with parameters and connection settings
        /// </summary>
        /// <param name="cmd">SqlCommand object to prepare</param>
        /// <param name="conn">Database connection</param>
        /// <param name="trans">Database transaction</param>
        /// <param name="cmdText">SQL command text</param>
        /// <param name="cmdParms">SQL parameters</param>
        public static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region Stored Procedure Operations

        /// <summary>
        /// Execute stored procedure (remember to manually close SqlDataReader and connection when using this method)
        /// </summary>
        /// <param name="storedProcName">Stored procedure name</param>
        /// <param name="parameters">Stored procedure parameters</param>
        /// <returns>SqlDataReader object</returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader returnReader;
            connection.Open();
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader();
            //Connection.Close(); Cannot close here, otherwise the returned object will be unusable            
            return returnReader;

        }

        /// <summary>
        /// Execute stored procedure
        /// </summary>
        /// <param name="storedProcName">Stored procedure name</param>
        /// <param name="parameters">Stored procedure parameters</param>
        /// <returns>First row and first column of the result</returns>
        public static string RunProc(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string StrValue;
                connection.Open();
                SqlCommand cmd;
                cmd = BuildQueryCommand(connection, storedProcName, parameters);
                StrValue = cmd.ExecuteScalar().ToString();
                connection.Close();
                return StrValue;
            }
        }

        /// <summary>
        /// Execute stored procedure
        /// </summary>
        /// <param name="storedProcName">Stored procedure name</param>
        /// <param name="parameters">Stored procedure parameters</param>
        /// <param name="tableName">Table name in DataSet result</param>
        /// <returns>DataSet containing stored procedure results</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// Execute stored procedure with timeout
        /// </summary>
        /// <param name="storedProcName">Stored procedure name</param>
        /// <param name="parameters">Stored procedure parameters</param>
        /// <param name="tableName">Table name in DataSet result</param>
        /// <param name="Times">Timeout in seconds</param>
        /// <returns>DataSet containing stored procedure results</returns>
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = Times;
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// Build SqlCommand object (used to return a result set, not an integer value)
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="storedProcName">Stored procedure name</param>
        /// <param name="parameters">Stored procedure parameters</param>
        /// <returns>SqlCommand object</returns>
        public static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // Check unassigned output parameters and assign them to DBNull.Value
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        /// <summary>
        /// Execute stored procedure and return the number of affected rows		
        /// </summary>
        /// <param name="storedProcName">Stored procedure name</param>
        /// <param name="parameters">Stored procedure parameters</param>
        /// <param name="rowsAffected">Number of affected rows</param>
        /// <returns>Return value from stored procedure</returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// Create SqlCommand object instance (used to return an integer value)	
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="storedProcName">Stored procedure name</param>
        /// <param name="parameters">Stored procedure parameters</param>
        /// <returns>SqlCommand object instance</returns>
        public static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        /// <summary>
        /// Execute SQL statement
        /// </summary>
        /// <param name="query">SQL query statement</param>
        /// <returns>First row and first column of the result</returns>
        public static string RunSql(string query)
        {
            string str;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        //str = (cmd.ExecuteScalar().ToString() == "") ? "" : cmd.ExecuteScalar().ToString();
                        str = "";
                        if (cmd.ExecuteScalar() == null)
                        {
                            str = "";
                        }
                        else
                        {
                            str = cmd.ExecuteScalar().ToString();
                        }
                        return str;
                    }
                    catch (SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        #endregion
    }
}