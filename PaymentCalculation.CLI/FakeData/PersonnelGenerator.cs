using Bogus;
using PaymentCalculation.Base.Entities.Abstract;
using PaymentCalculation.Base.Entities.Concrete;
using PaymentCalculation.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaymentCalculation.CLI.FakeData
{
    public class PersonnelGenerator
    {
        public static ICollection<Personnel> GeneratePersonnelList(int count)
        {
            var faker = new Faker("en");

            var officerFaker = new Faker<Officer>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Birthday, f => f.Date.Past(50, DateTime.Today.AddYears(-18)))
                .RuleFor(p => p.EmploymentDate, f => f.Date.Between(DateTime.Today.AddYears(-30), DateTime.Today))
                .RuleFor(p => p.Title, f => f.PickRandom<Title>())
                .RuleFor(p => p.WorkHours, f => f.Random.Int(160, 180))
                .RuleFor(p => p.PerHourRate, f => f.Random.Double(500, 1500))
                .RuleFor(p => p.Bonus, f => f.Random.Double(5000, 15000));

            var administratorFaker = new Faker<Administrator>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.Birthday, f => f.Date.Past(50, DateTime.Today.AddYears(-18)))
                .RuleFor(p => p.EmploymentDate, f => f.Date.Between(DateTime.Today.AddYears(-30), DateTime.Today))
                .RuleFor(p => p.Title, f => f.PickRandom<Title>())
                .RuleFor(p => p.WorkHours, f => f.Random.Int(160, 180))
                .RuleFor(p => p.PerHourRate, f => f.Random.Double(500, 1500))
                .RuleFor(p => p.Bonus, f => f.Random.Double(5000, 15000));

            List<Personnel> personnel = new List<Personnel>();
            var officers = officerFaker.Generate(count);
            var administrators = administratorFaker.Generate(count / 10);
            personnel.AddRange(officers);
            personnel.AddRange(administrators);
            return personnel;
        }

        public static void SaveToJsonFile(ICollection<Personnel> personnelList, string filePath)
        {
            if (File.Exists(filePath))
            {
                return;
            }
            var json = JsonSerializer.Serialize(personnelList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
