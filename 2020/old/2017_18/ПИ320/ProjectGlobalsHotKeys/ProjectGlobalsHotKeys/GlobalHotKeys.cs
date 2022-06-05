using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectGlobalsHotKeys
{
    public class GlobalHotKeys
    {
        #region Win API
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool RegisterHotKey(IntPtr hwnd,
                                          short id,
                                          uint Mod,
                                          uint Key);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool UnregisterHotKey(IntPtr hwnd,
                                            short id);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern ushort GlobalAddAtom(string str);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern ushort GlobalDeleteAtom(ushort id);

        #endregion

        #region Константы клавиш-модификаторов
        public const int MOD_ALT =   0x1; // 2^0
        public const int MOD_CTRL =  0x2; // 2^1
        public const int MOD_SHIFT = 0x4; // 2^2
        public const int MOD_WIN =   0x8; // 2^3
        #endregion

        private IntPtr _hwnd;
        private ushort _id;

        public void AddHotKeys(int Mod, Keys ky)
        {
            // 1) Нужна уникальная текстовая строка
            Type t = this.GetType();
            string uniqueStr = t.Namespace
                + t.Name + Thread.CurrentThread
                       .ManagedThreadId
                       .ToString();

        }
    }
}
