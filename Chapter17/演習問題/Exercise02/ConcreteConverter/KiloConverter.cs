using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02.ConcreteConverter {
    public class KiloConverter : Framework.ConverterBase {
        public override bool IsMyUnit(string name) {
            return name.ToLower() == "kilo" || name == UnitName;
        }

        protected override double Ratio { get { return 1000; } }
        public override string UnitName { get { return "キロ"; } }
    }
}
