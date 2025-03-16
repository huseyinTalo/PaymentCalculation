using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Base.Entities.Concrete
{
    public class PersonnelContainer
    {
        public ICollection<Officer> Officers { get; set; } = new HashSet<Officer>();
        public ICollection<Administrator> Administrators { get; set; } = new HashSet<Administrator>();
    }
}
