using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AnyWise.Web.CheckProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            //实时监测
            while (true)
            {
                Judge();
            }
        }
        //客户端
        static  string name = "AnyWise.DeskBI.GovernmentAffairs";
        //控制台程序
        static string console = "AnyWise.Web.synchrodata";
        static string names = "QQ";

        /// <summary>
        /// 执行判断
        /// </summary>
        public static void Judge()
        {
            while (!GetPidByProcessName(name))
            {
                int state= Hd();
                if (state == 1)
                {
                    Thread.Sleep(2000);
                }
            }
        }

        /// <summary>
        /// 程序未运行时执行的方法
        /// </summary>
        public static int Hd()
        {
            try
            {
                Process.Start(@"E:\延庆\Debug\AnyWise.DeskBI.GovernmentAffairs.exe");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }

        /// <summary>
        /// 判断程序是否在运行
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public static bool GetPidByProcessName(string processName)
        {
            Process[] arrayProcess = Process.GetProcessesByName(processName);
            //在运行返回true，不在运行返回false
            foreach (Process p in arrayProcess)
            {
                return true;
            }
            return false;
        }
    }
}
