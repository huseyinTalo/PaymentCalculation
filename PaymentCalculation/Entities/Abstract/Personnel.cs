using PaymentCalculation.Base.Enums;

namespace PaymentCalculation.Base.Entities.Abstract
{
    public class Personnel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        private string _firstName = string.Empty;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("First name cannot be empty");
                    _firstName = string.Empty;
                    return;
                }
                _firstName = char.ToUpper(value[0]) + value.Substring(1);
            }
        }

        private string _lastName = string.Empty;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Last name cannot be empty");
                    _lastName = string.Empty;
                    return;
                }
                _lastName = char.ToUpper(value[0]) + value.Substring(1);
            }
        }

        private DateTime _birthday = DateTime.MinValue;
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if (DateTime.Today.AddYears(-18) < value)
                {
                    Console.WriteLine("Person must be at least 18 years old");
                    if (_birthday == DateTime.MinValue)
                        _birthday = DateTime.MinValue;
                    return;
                }

                _birthday = value;
            }
        }

        private DateTime _employmentDate = DateTime.MinValue;
        public DateTime EmploymentDate
        {
            get => _employmentDate;
            set
            {
                if (value > DateTime.Today)
                {
                    Console.WriteLine("Employment date cannot be in the future");
                    if (_employmentDate == DateTime.MinValue)
                        _employmentDate = DateTime.MinValue;
                    return;
                }

                _employmentDate = value;
            }
        }

        public Title Title { get; set; }
        public int WorkHours { get; set; }
        public double PerHourRate { get; set; }
        public double Payment { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public double Bonus { get; set; }
        protected Personnel()
        {
            
        }
    }
}
