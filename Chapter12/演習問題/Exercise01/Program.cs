using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Exercise01 {
    class Program {
        static void Main(string[] args) {

            var employee = new Employee {
                Id = 34354,
                Name = "松倉一輝",
                HireDate = DateTime.Today,
            };

            using (var writer = XmlWriter.Create("Employee.xml")) {
                var serializer = new XmlSerializer(employee.GetType());
                serializer.Serialize(writer, employee);
            }

            using (var reader = XmlReader.Create("Employee.xml")) {
                var serializer = new XmlSerializer(typeof(Employee));
                employee = serializer.Deserialize(reader) as Employee;
                Console.WriteLine(employee);

            }
        }
    }
}
