using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Warrior
{
    public class GlobalKey
    {
        // Global key gets the current keys getting pressed by the user.
        static volatile string _currentKey;
        static IntPtr _hook;
        static LowLevelKeyboardProc _proc = Hook;

        public void Init()
        {
            new Thread(() =>
            {
                using var p = Process.GetCurrentProcess();
                using var m = p.MainModule;
                _hook = SetWindowsHookEx(13, _proc, GetModuleHandle(m.ModuleName), 0);
                while (GetMessage(out MSG _, IntPtr.Zero, 0, 0)) { }
            })
            { IsBackground = true }.Start();
        }

        public string CurrentKey()
        {
            var k = _currentKey; 
            _currentKey = null;
            return k;
        }

        static IntPtr Hook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)0x0100)
            {
                int vk = Marshal.ReadInt32(lParam);
                _currentKey = ((ConsoleKey)vk).ToString();
            }
            return CallNextHookEx(_hook, nCode, wParam, lParam);
        }

        delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        struct MSG { IntPtr h; uint m; IntPtr w, l; uint t; }

        [DllImport("user32.dll")] static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll")] static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll")] static extern IntPtr GetModuleHandle(string lp);
        [DllImport("user32.dll")] static extern bool GetMessage(out MSG msg, IntPtr hWnd, uint min, uint max);
    }
}
