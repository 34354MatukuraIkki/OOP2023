﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleUnitConverter {
    //グラム単位を表すクラス
    public class GramUnit : DistanceUnit {
        private static List<GramUnit> units = new List<GramUnit> {
            new GramUnit{Name="g",Coefficient=1},
            new GramUnit{Name="kg",Coefficient=1000},
        };
        public static ICollection<GramUnit> Units { get { return units; } }

        /// <summary>
        /// ポンド単位からグラム単位に変換
        /// </summary>
        /// <param name="unit">ポンド単位</param>
        /// <param name="value">値</param>
        /// <returns>変換値</returns>
        public double FromWeightUnit(WeightUnit unit, double value) {
            return (value * unit.Coefficient) * 28.35 / this.Coefficient;
        }
    }
}
