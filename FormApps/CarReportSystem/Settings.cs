using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    [Serializable]
    public class Settings {
        // 設定した色情報を格納
        public int MainFormBackColor { get; set; }
    }
}
    
