using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Ban_Hang.DAO
{
    public class DataProvider
    {
        private static DataProvider _Instance;

        public static DataProvider Instance { get { if (_Instance == null) _Instance = new DataProvider(); return _Instance; } private set { _Instance = value; } }

        private DataProvider() { }

        private string _Connectionstr = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyBanHang;Integrated Security=True";

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable _data = new DataTable();

            using (SqlConnection _connection = new SqlConnection(_Connectionstr))
            {
                _connection.Open();

                SqlCommand _command = new SqlCommand(query, _connection);

                if (parameter != null)
                {
                    string[] _listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in _listpara)
                    {
                        if (item.Contains('@'))
                        {
                            _command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SqlDataAdapter _adapter = new SqlDataAdapter(_command);

                _adapter.Fill(_data);

                _connection.Close();
            }

            return _data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int _data = 0;

            using (SqlConnection _connection = new SqlConnection(_Connectionstr))
            {
                _connection.Open();

                SqlCommand _command = new SqlCommand(query, _connection);

                if (parameter != null)
                {
                    string[] _listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in _listpara)
                    {
                        if (item.Contains('@'))
                        {
                            _command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                _data = _command.ExecuteNonQuery();

                _connection.Close();
            }

            return _data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object _data = 0;

            using (SqlConnection _connection = new SqlConnection(_Connectionstr))
            {
                _connection.Open();

                SqlCommand _command = new SqlCommand(query, _connection);

                if (parameter != null)
                {
                    string[] _listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in _listpara)
                    {
                        if (item.Contains('@'))
                        {
                            _command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                _data = _command.ExecuteScalar();

                _connection.Close();
            }

            return _data;
        }

    }
}
