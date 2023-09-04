using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {
            
            using (var reader = XmlReader.Create("Employees.xml")) {
                var serializer = new DataContractSerializer(typeof(Employee[]));
                var employees = serializer.ReadObject(reader) as Employee[];
                foreach (var employee in employees) {
                    Console.WriteLine(employee);
                }
            }
        }
    }
}
