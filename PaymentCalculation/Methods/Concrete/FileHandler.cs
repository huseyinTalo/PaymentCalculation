using Newtonsoft.Json;
using PaymentCalculation.Base.Entities.Abstract;
using PaymentCalculation.Base.Entities.Concrete;
using PaymentCalculation.Base.Methods.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaymentCalculation.Base.Methods.Concrete
{
    public class FileHandler : IFileHandler
    {
        public (ICollection<Officer> officers, ICollection<Administrator> administrators) ReadJson(string filePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(jsonContent))
                {
                    return (new List<Officer>(), new List<Administrator>());
                }

                List<Personnel>? personnelData = JsonConvert.DeserializeObject<List<Personnel>>(
                    jsonContent,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    });

                var officers = new List<Officer>();
                var administrators = new List<Administrator>();

                if (personnelData != null)
                {
                    foreach (var item in personnelData)
                    {
                        if (item.Title == Enums.Title.Adminastrator)
                        {
                            Administrator admin = new Administrator();
                            admin.WorkHours = item.WorkHours;
                            admin.Bonus = item.Bonus;
                            admin.PerHourRate = item.PerHourRate;
                            admin.EmploymentDate = item.EmploymentDate;
                            admin.Birthday = item.Birthday;
                            admin.FirstName = item.FirstName;
                            admin.LastName = item.LastName;
                            admin.Id = item.Id;
                            admin.Title = item.Title;
                            admin.Payment = item.Payment;
                            

                            administrators.Add(admin);
                        }
                        else if (item.Title == Enums.Title.Officer)
                        {
                            Officer officer = new Officer();
                            officer.WorkHours = item.WorkHours;
                            officer.Bonus = item.Bonus;
                            officer.PerHourRate = item.PerHourRate;
                            officer.EmploymentDate = item.EmploymentDate;
                            officer.Birthday = item.Birthday;
                            officer.FirstName = item.FirstName;
                            officer.LastName = item.LastName;
                            officer.Id = item.Id;
                            officer.Title = item.Title;
                            officer.Payment = item.Payment;
                            officers.Add(officer);                         
                        }
                    }
                }

                return (officers, administrators);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading personnel file: {ex.Message}");
                return (new List<Officer>(), new List<Administrator>());
            }
        }

        public string WriteJson(ICollection<Officer> officers, ICollection<Administrator> administrators)
        {
            try
            {
                var personnelContainer = new PersonnelContainer
                {
                    Officers = officers,
                    Administrators = administrators
                };

                DateTime now = DateTime.Now;
                string monthName = now.ToString("MMMM");
                string year = now.ToString("yyyy");
                string timestamp = now.ToString("dd_HHmmss");

                string currentDir = Directory.GetCurrentDirectory();
                string projectDir = Path.GetFullPath(Path.Combine(currentDir, @"..\..\..\"));
                string payrollData = Path.Combine(projectDir, "PayrollData");
                if (!Directory.Exists(payrollData))
                {
                    Directory.CreateDirectory(payrollData);
                }
                string fileName = $"personnel_payroll_{monthName}_{year}_{timestamp}.json";
                string filePath = Path.Combine(payrollData, fileName);

                // Newtonsoft.Json serialization settings
                var settings = new Newtonsoft.Json.JsonSerializerSettings
                {
                    Formatting = Newtonsoft.Json.Formatting.Indented,
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto // Helps with inheritance
                };

                string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(personnelContainer, settings);
                File.WriteAllText(filePath, jsonString);

                Console.WriteLine($"Personnel data successfully written to: {filePath}");
                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing personnel data to file: {ex.Message}");
                throw;
            }
        }
    }
}
