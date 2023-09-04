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
            var employees = new Employee[] {
            new Employee {
                Id = 34354,
                Name = "松倉一輝",
                HireDate = DateTime.Today,
            },

            new Employee {
                Id = 34321,
                Name = "吉岡亮",
                HireDate = DateTime.Now,
            }
            };
        
            using (var writer = XmlWriter.Create("Employees.xml")) {
                var serializer = new DataContractSerializer(employees.GetType());
                serializer.WriteObject(writer, employees);
            }
        }
    }
}
