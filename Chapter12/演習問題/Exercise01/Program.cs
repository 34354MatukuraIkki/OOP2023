using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
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

            using (var stream = new FileStream("employees.json", FileMode.Create, FileAccess.Write)) {
                var serializer = new DataContractJsonSerializer(employees.GetType());
                serializer.WriteObject(stream, employees);
            }
        }
    }
}
