﻿using System.Globalization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var dateTime = DateTime.Now;
            DisplayDatePattern1(dateTime);
            DisplayDatePattern2(dateTime);
            DisplayDatePattern3(dateTime);
        }

        private static void DisplayDatePattern1(DateTime dateTime) {
            //2024/03/09 19:03
            //string.Formatを使った例
            var s1 = dateTime.ToString("yyyy/MM/dd hh:mm");
            Console.WriteLine(s1);
        }

        private static void DisplayDatePattern2(DateTime dateTime) {
            //2024年03月09日　19時03分09秒
            //DateTime.ToStringを使った例
            var s2 = dateTime.ToString("yyyy年MM月dd日 hh時mm分ss秒");
            Console.WriteLine(s2);


        }

        private static void DisplayDatePattern3(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var s3 = dateTime.ToString("ggyy年MM月dd日(dddd)",culture);
            Console.WriteLine(s3);
        }
    }
}
