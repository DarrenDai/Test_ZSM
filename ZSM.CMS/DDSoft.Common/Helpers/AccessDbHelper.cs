using System;
using System.Data;
using System.Data.OleDb;

namespace DDSoft.Common
{
    public class AccessDbHelper : IDisposable
    {
        #region Private fields

        private OleDbConnection _connection;
        private string _connectionString = string.Format( @"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0}",
            string.Format(@"{0}\DDSoft\DataBase\dd",Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)));

        #endregion

        #region Constructor

        public AccessDbHelper()
        {
            _connection = new OleDbConnection(_connectionString);
            _connection.Open();
        }

        #endregion

        #region Public Methods

        public OleDbConnection DbConnection()
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();
            return _connection;
        }

        public bool ExecuteSQLNonQuery(string sql)
        {
            OleDbCommand command = new OleDbCommand(sql, _connection);
            try
            {
                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object ExecuteScalar(string sql)
        {
            OleDbCommand command = new OleDbCommand(sql, _connection);
            try
            {
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDataSet(string sql, string subtableName)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(sql, _connection);
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(subtableName);
            adapter.Fill(dataSet, subtableName);
            return dataSet;
        }

        public DataSet GetDataSet(string sql, string subtableName, DataSet DataSetName)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(sql, _connection);
            adapter.SelectCommand = command;
            new DataTable();
            DataSet set = new DataSet();
            set = DataSetName;
            adapter.Fill(DataSetName, subtableName);
            return set;
        }

        public DataTable GetDataTable(string sql)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(sql, _connection);
            adapter.SelectCommand = command;
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public OleDbDataAdapter SelectToOleDbDataAdapter(string sql)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand(sql, _connection);
            adapter.SelectCommand = command;
            return adapter;
        }

        public void Close()
        {
            if (_connection.State == ConnectionState.Open)
                _connection.Close();
        }

        #endregion

        #region IDisposable members 

        public void Dispose()
        {
            Close();
        }

        #endregion
    }
}