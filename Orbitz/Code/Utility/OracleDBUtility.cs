using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;
using Oracle.DataAccess.Types;

namespace Orbitz.Utility
{
    class OracleDBUtility
    {
        #region Private Fields
        
        private static OracleConnection _connection = new OracleConnection();

        private static OracleDBUtility _oracleDBUtility = new OracleDBUtility();
            
        
        #endregion

        #region Credentials

        String _providerClient = "Oracle.DataAccess.Client";

        String _userID = "aravindm";
        String _password = "mypassword";
        String _dataSource = "aos.acsu.buffalo.edu:1521/aos.buffalo.edu";

        #endregion

        #region Constructors

        private OracleDBUtility()
        {
            //Create the connection
            CreateConnection();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the connection with Oracle DB
        /// </summary>
        private void CreateConnection()
        {
            try
            {
                //If the connection is not open
                if (_connection.State != ConnectionState.Open)
                {
                    //Set the connection string
                    _connection.ConnectionString = String.Format("user id={0};password={1};data source=//{2}", _userID, _password, _dataSource);
                    _connection.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns the instance of OracleDBUtility
        /// </summary>
        /// <returns></returns>
        public static OracleDBUtility GetInstance()
        {
            if (_oracleDBUtility == null)
                _oracleDBUtility = new OracleDBUtility();

            return _oracleDBUtility;
        }

        /// <summary>
        /// Gets a scalar output
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Int32 GetOutput(String procedureName, Queue<Object> input)
        {
            //Declarations
            Int32 output = Int32.MinValue;
            Int32 count;
            String parameterType = String.Empty;

            //Create connection if required
            CreateConnection();

            //Set the command
            OracleCommand oracleCommand = new OracleCommand(procedureName, _connection);
            oracleCommand.CommandType = CommandType.StoredProcedure;
            
            //If there are any inputs which needs to be passed on
            if (input != null)
            {
                //Get the count of inputs
                count = input.Count;

                //Build up the input parameters            
                for (int index = 0; index < count; index++)
                {
                    Object parameter = input.Dequeue();
                    parameterType = parameter.GetType().ToString();

                    switch (parameterType)
                    {
                        case "System.String":
                            oracleCommand.Parameters.Add(index.ToString(), OracleDbType.Varchar2, parameter, ParameterDirection.Input);
                            break;
                        case "System.Int32":
                            oracleCommand.Parameters.Add(index.ToString(), OracleDbType.Int32, parameter, ParameterDirection.Input);
                            break;
                        case "System.Double":
                            oracleCommand.Parameters.Add(index.ToString(), OracleDbType.Double, parameter, ParameterDirection.Input);
                            break;
                        case "System.Float":
                            oracleCommand.Parameters.Add(index.ToString(), OracleDbType.BinaryFloat, parameter, ParameterDirection.Input);
                            break;
                    }
                }
            }

            //Build up the output parameter
            oracleCommand.Parameters.Add("output", OracleDbType.Int32, ParameterDirection.Output);

            oracleCommand.ExecuteNonQuery();

            //Get the output
            Int32.TryParse(oracleCommand.Parameters["output"].Value.ToString(), out output);

            return output;
        }

        /// <summary>
        /// Gets multiple record data through oracle
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public DataTable GetData(String procedureName, Queue<Object> input)
        {
            //Declarations           
            Int32 count = 0;
            String parameterType = String.Empty;

            //Create connection if required
            CreateConnection();

            //Set the command
            OracleCommand oracleCommand = new OracleCommand(procedureName, _connection);
            oracleCommand.CommandType = CommandType.StoredProcedure;

            //If there are any inputs which needs to be passed on
            if (input != null)
            {
                //Get the count of inputs
                count = input.Count;

                //Build up the input parameters            
                for (int index = 0; index < count; index++)
                {
                    Object parameter = input.Dequeue();
                    parameterType = parameter.GetType().ToString();

                    switch (parameterType)
                    {
                        case "System.String":
                            oracleCommand.Parameters.Add(index.ToString(), OracleDbType.Varchar2, parameter, ParameterDirection.Input);
                            break;
                        case "System.Int32":
                            oracleCommand.Parameters.Add(index.ToString(), OracleDbType.Int32, parameter, ParameterDirection.Input);
                            break;
                        case "System.Double":
                            oracleCommand.Parameters.Add(index.ToString(), OracleDbType.Double, parameter, ParameterDirection.Input);
                            break;
                        case "System.Float":
                            oracleCommand.Parameters.Add(index.ToString(), OracleDbType.BinaryFloat, parameter, ParameterDirection.Input);
                            break;
                    }
                }
            }

            //Build up the output parameter
            oracleCommand.Parameters.Add("output", OracleDbType.RefCursor, ParameterDirection.InputOutput);

            //Execute the statement            
            oracleCommand.ExecuteNonQuery();

            // Create the OracleDataAdapter
            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand);

            // Populate a DataSet with refcursor1
            DataSet dataSet = new DataSet();
            oracleDataAdapter.Fill(dataSet, "output", (OracleRefCursor)(oracleCommand.Parameters["output"].Value));


            return dataSet.Tables[0];
        }

        #endregion

    }
}
