using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils4Net.Database.MongoDB
{
    public class DatabaseAddress
    {
        public const string DefaultHost = "localhost";
        public const ushort DefaultPort = 27017;

        public string Host { get; set; }
        public ushort Port { get; set; }

        public DatabaseAddress() : this(DefaultHost, DefaultPort)
        {
        }

        public DatabaseAddress(string host, ushort port)
        {
            if (string.IsNullOrWhiteSpace(host))
            {
                throw new ArgumentException("Host is not defined");
            }

            if (port < 1)
            {
                throw new ArgumentException("Port is invalid");
            }

            Host = host;
            Port = port;
        }

        public override string ToString()
        {
            return $"{Host}:{Port}";
        }
    }

    public class DatabaseParameters
    {
        public string Database { get; private set; }

        public string? Username { get; private set; }

        public string? Password { get; private set; }

        public bool UseTransactions { get; private set; }

        public List<DatabaseAddress> Addresses { get; private set; }

        public Dictionary<string, string>? Options { get; private set; }

        public DatabaseParameters(string database, Dictionary<string, string>? options = null, bool useTransactions = false) :
        this(database, null, null, new DatabaseAddress(), options, useTransactions)
        {
        }

        public DatabaseParameters(string database, DatabaseAddress address, Dictionary<string, string>? options = null, bool useTransactions = false) :
        this(database, null, null, address, options, useTransactions)
        {
        }

        public DatabaseParameters(string database, List<DatabaseAddress> addresses, Dictionary<string, string>? options = null, bool useTransactions = false) :
        this(database, null, null, addresses, options, useTransactions)
        {
        }

        public DatabaseParameters(string database, string? username, string? password, Dictionary<string, string>? options = null, bool useTransactions = false) :
        this(database, username, password, new DatabaseAddress(), options, useTransactions)
        {
        }

        public DatabaseParameters(string database, string? username, string? password, DatabaseAddress address, Dictionary<string, string>? options = null, bool useTransactions = false) :
        this(database, username, password, new List<DatabaseAddress>() { address }, options, useTransactions)
        {
        }

        public DatabaseParameters(string database, string? username, string? password, List<DatabaseAddress> addresses, Dictionary<string, string>? options = null, bool useTransactions = false)
        {
            if (string.IsNullOrWhiteSpace(database))
            {
                throw new ArgumentException("Database is not defined");
            }

            if (addresses == null || addresses.Count == 0)
            {
                throw new ArgumentException("Addresses is not defined");
            }

            Database = database;
            Username = username;
            Password = password;
            Addresses = addresses;
            Options = options;
            UseTransactions = useTransactions;
        }

        /*
         * Connection
         */
        public string GetConnectionString()
        {
            StringBuilder sb = new("mongodb://");

            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
            {
                sb.Append($"{Username}:{Password}");
            }

            for (int i = 0; i < Addresses.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(',');
                }
                sb.Append(Addresses[i]);
            }

            sb.Append($"/{Database}");

            if (Options != null && Options.Keys.Count > 0)
            {
                sb.Append("/?");
                int i = 0;
                foreach (KeyValuePair<string, string> keyValuePair in Options)
                {
                    if (i > 0)
                    {
                        sb.Append('&');
                    }
                    sb.Append($"{keyValuePair.Key}={keyValuePair.Value}");
                    i++;
                }
            }

            return sb.ToString();
        }

        public MongoClient GetClientConnection()
        {
            return new MongoClient(GetConnectionString());
        }

        public override string ToString()
        {
            return GetConnectionString();
        }
    }
}
