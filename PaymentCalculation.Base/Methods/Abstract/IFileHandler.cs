using PaymentCalculation.Base.Entities.Abstract;
using PaymentCalculation.Base.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Base.Methods.Abstract
{
    public interface IFileHandler
    {
        public (ICollection<Officer> officers, ICollection<Administrator> administrators) ReadJson(string filePath);
        public string WriteJson(ICollection<Officer> officers, ICollection<Administrator> administrators);
    }
}
