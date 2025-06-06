using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01{
    //5.1.1
   public class YearMonth{
        public int Year { get; init; }
        public int Month { get; init; }

        public YearMonth(int year,int month) {
            Year = year;
            Month = month;

        }
        //5.1.2
        //設定された西暦が２１世紀か判断する
        //Yearが2001～2100年の間ならtrue,それ以外ならfalseを返す
        public bool Is21Century => Year >= 2001 && Year <= 2100;

        //5.1.3
        public YearMonth AddOneMonth() {
            int newYear = Year;
            int newMonth = Month + 1;

            if (newMonth > 12) {
                newYear++;
                newMonth = 1;
            }

            return new YearMonth(newYear, newMonth);
        }
        //5.1.4
        public override string ToString() =>
            
        }
    }
}
