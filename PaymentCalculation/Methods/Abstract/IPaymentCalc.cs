using PaymentCalculation.Base.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Base.Methods.Abstract
{
    public interface IPaymentCalc
    {
        public (ICollection<Officer> officers, ICollection<Administrator> administrators) CalculatePayroll(ICollection<Officer> officers, ICollection<Administrator> administrators);
    }
}
