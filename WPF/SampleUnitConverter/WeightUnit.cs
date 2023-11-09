using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    //ポンド単位を表すクラス
    public class WeightUnit : DistanceUnit {
        private static List<WeightUnit> units = new List<WeightUnit> {
            new WeightUnit{Name="oz",Coefficient=1},
            new WeightUnit{Name="lb",Coefficient=16},
        };
        public static ICollection<WeightUnit> Units { get { return units; } }

        /// <summary>
        /// グラム単位からポンド単位に変換
        /// </summary>
        /// <param name="unit">グラム単位</param>
        /// <param name="value">値</param>
        /// <returns>変換値</returns>
        public double FromGramUnit(GramUnit unit, double value) {
            return (value * unit.Coefficient) / 28.35 / this.Coefficient;
        }
    }
}
