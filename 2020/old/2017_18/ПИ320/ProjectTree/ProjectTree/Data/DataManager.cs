using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProjectTree.Domains;

namespace ProjectTree.Data
{
    public class DataManager
    {
        protected static FileStream _fs;
        protected static long _cursor;

        public static void CreateFile()
        {
            _fs = new FileStream("records.bin", FileMode.Create);
        }

        public static void OpenRead()
        {
            _fs = new FileStream("records.bin", FileMode.Open);
            _cursor = 0;
        }

        public static Student NextRecord()
        {
            if (_fs.Position == _fs.Length)
            { // мы достигли конца файла
                return null;   
            }
            // считываем из текущего места в файле
            // размер следующей записи
            byte len = (byte) _fs.ReadByte();
            // считываем целиком студента
            byte[] bytes = new byte[len];
            _fs.Read(bytes, 0, len);
            string st = Encoding.UTF8.GetString(bytes);
            return Student.Parse(st);
        }

        public static void CloseFile()
        {
            _fs.Close();
        }

        public static void AddRecordFile(Student stud)
        {
            string info = stud.Serialize();
            // превращаем в байты
            byte[] bytes = Encoding.UTF8.GetBytes(info);
            // сначала записываем размер студента
            _fs.WriteByte((byte)bytes.Length);
            // записываем самого студента
            _fs.Write(bytes, 0, bytes.Length);
        }
    }
}
