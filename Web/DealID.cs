using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DHMSClass.Web
{
    public class DealID
    {
        string str;//声明字符串类型的变量str
        int Year, Month, Day, Hour, Minute, second;//声明int类型的变量
        public string Deal_ID()//创建一个string类型的方法
        {
            //分别赋值
            Year = DateTime.Now.Year;
            Month = DateTime.Now.Month;
            Day = DateTime.Now.Day;
            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;

            //创建随机数
            Random Rnum = new Random();
            int num1 = Rnum.Next(0, 9);
            int num2 = Rnum.Next(0, 9);
            int num3 = Rnum.Next(0, 9);
            int num4 = Rnum.Next(0, 9);

            int[] num = new int[10] { Year, Month, Day, Hour, Minute, second, num1, num2, num3, num4 };//定义一个包含所有int变量的数组
            for (int i = 0; i < num.Length; i++)//用循环连接数组里的内容
            {
                str += num[i].ToString();//将内容连接到str中
            }
            return str;//返回str的值
        }
    }
}