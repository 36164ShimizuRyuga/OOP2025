using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    [Serializable]
    public class Settings {

        private static Settings instance;  //自分自身のインスタンスを格納
        


        // 設定した色情報を格納
        public int MainFormBackColor { get; set; }

        //コンストラクタ(privateにすることによりnewできなくする)
        private Settings() { }

        public static Settings getInstance() {
            if(instance == null) {
                instance = new Settings();
            }
            return instance;
        }
    }
}
    
