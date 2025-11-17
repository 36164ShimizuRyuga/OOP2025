using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    public abstract class ConverterBase {
        //nameで与えられた単位が自分のものか判断
        public abstract bool IsMyUnit(string name);
        
        //メートルとの比率
        protected abstract double Ratio { get; }
        //距離の単位
        public abstract string UnitName { get; }
        //メートルからの変換
        public double FromMeter(double meter) => meter / Ratio;
        //メートルへの変換
        public double ToMeter(double feet) => feet * Ratio; 

    }
}
