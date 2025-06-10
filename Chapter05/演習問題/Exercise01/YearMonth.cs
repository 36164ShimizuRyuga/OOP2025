using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01{
    //5.1.1
   public class YearMonth(int Year, int Month){
     
        //5.1.2
        //設定された西暦が２１世紀か判断する
        //Yearが2001～2100年の間ならtrue,それ以外ならfalseを返す
        public bool Is21Century => Year >= 2001 && Year <= 2100;

        //5.1.3
        public YearMonth AddOneMonth() {

            if(Month < 12) {
                return new YearMonth(Year, Month + 1);//Monthが12以外
            } else {
                return new YearMonth(Year + 1, 1);//Monthが12
            }
        /*    int newYear = Year;
            int newMonth = Month + 1;

            if (newMonth > 12) {
                newYear++;
                newMonth = 1;
            }

            return new YearMonth(newYear, newMonth);*/
        }
        //5.1.4
        public override string ToString() => $"{Year}年{Month}月";
        
    }
}
