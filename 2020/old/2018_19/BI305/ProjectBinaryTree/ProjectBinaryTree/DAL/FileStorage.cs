using ProjectBinaryTree.Domains;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectBinaryTree.DAL
{
    public class FileStorage
    {
        private static FileStream _fs;
        public static void SaveList(List<Customer> list)
        {
            foreach (var item in list)
            {
                AddCustomer(item);
            }
        }
        public static void AddCustomer(Customer customer)
        {
            var fs = new FileStream("database.bin",FileMode.Append,FileAccess.Write);
            string str = customer.ToString();
            byte[] bytes= Encoding.UTF8.GetBytes(str);
            fs.WriteByte((byte)bytes.Length);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();
        }
        public static void OpenFile()
        {
            _fs = new FileStream("database.bin",FileMode.Open);
        }

        public static void CloseFile()
        {
            _fs.Close();
        }

        public static Customer NextCustomer(out long index)
        {
            index = _fs.Position;
            if (_fs == null) return null;
            if (_fs.Position >= _fs.Length) return null;
            Customer cust = null;

            try
            {
                byte size = (byte)_fs.ReadByte();
                byte[] bytes = new byte[size];
                _fs.Read(bytes, 0, size);
                string str = Encoding.UTF8.GetString(bytes);
                cust = Customer.Parse(str);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return cust;
        }

        public static Customer GetCustomer(long offset)
        {
            _fs.Seek(offset, SeekOrigin.Begin);
            return NextCustomer(out long i);
        }
    }
}
