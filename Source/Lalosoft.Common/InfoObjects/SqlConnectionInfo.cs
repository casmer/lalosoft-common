using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Data;
namespace Lalosoft.Common.InfoObjects
{
    [Browsable(true)]
    [TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class SqlConnectionInfo: ICloneable
    {
       // public const int DefaultPort = 3304;
        private int _commandTimeout = 30;

        public int CommandTimeout
        {
            get { return _commandTimeout; }
            set { _commandTimeout = value; }
        }

        private bool _pooling=false;
        private int _MaxPoolSize=200;
        private bool _selected;
        /// <summary>
        /// For supporting lists of selected Items.
        /// </summary>
        
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        private string _server = "(local)";
        [Browsable(true)]
        [Description("Server Name")]
        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }
        private int _connectTimeout = 30;
        [Browsable(true)]
        public int ConnectTimeout
        {
            get { return _connectTimeout; }
            set { _connectTimeout = value; }
        }
        private string _initialCatalog = "master";
        [Browsable(true)]
        public string InitialCatalog
        {
            get { return _initialCatalog; }
            set { _initialCatalog = value; }
        }
        private int _connectionTimeout = 30;
        [Browsable(true)]
        public int ConnectionTimeout
        {
            get { return _connectionTimeout; }
            set { _connectionTimeout = value; }
        }
        private bool _useIntegratedSecurity = true;
        [Browsable(true)]
        public bool UseIntegratedSecurity
        {
            get { return _useIntegratedSecurity; }
            set { _useIntegratedSecurity = value; }
        }
        private string _username = "";
        [Browsable(true)]
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private string _password = "";
        [Browsable(true)]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string GetConnectionString()
        {

            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = _server;
            sb.InitialCatalog = _initialCatalog;

            if (_useIntegratedSecurity)
                sb.IntegratedSecurity = true;
            else
            {
                sb.UserID = _username;
                sb.Password = _password;
            }
            sb.ConnectTimeout = _connectTimeout;
            sb.Pooling = _pooling;
            sb.MinPoolSize = _minPoolSize;
            sb.MaxPoolSize = _MaxPoolSize;
            
            return sb.ToString();
        }
        public void SetConnectionString(string newConnectionString)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.ConnectionString = newConnectionString;
            _initialCatalog = sb.InitialCatalog;
            _server = sb.DataSource;
            _username = sb.UserID;
            _password = sb.Password;
            _useIntegratedSecurity = sb.IntegratedSecurity;
            _connectTimeout = sb.ConnectTimeout;
            _pooling = sb.Pooling;
            _MaxPoolSize = sb.MaxPoolSize;
            _minPoolSize = sb.MinPoolSize;
        }
        public SqlConnectionInfo()
        { }



        public SqlConnectionInfo(string connectionString)
        {
          if (!Lalosoft.Common.CommonUtils.IsNullOrWhiteSpace(connectionString)) 
            SetConnectionString(connectionString);
        }
        public override string ToString()
        {
            //return string.Format
            //    ("Server={0};InitialCatalog={1};Integrated Security={2},UID={3},PWD={4},Timeout={5},Port={6}",
            //    _server, _initialCatalog, _useIntegratedSecurity, _username, _password, _connectionTimeout, _port);
            return string.Format
                ("Server={0};InitialCatalog={1}",
                _server, _initialCatalog);
        }

        #region ICloneable Members

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion

        public bool Pooling
        {
            get { return this._pooling; }
            set { this._pooling = value; }
        }

        public int MaxPoolSize
        {
            get { return this._MaxPoolSize; }
            set { this._MaxPoolSize = value; }
        }

        private int _minPoolSize=5;

        public int MinPoolSize
        {
            get { return this._minPoolSize; }
            set { this._minPoolSize = value; }
        }
    }
}
