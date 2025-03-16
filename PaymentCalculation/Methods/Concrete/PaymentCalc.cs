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
    public class PaymentCalc : IPaymentCalc
    {
        public (ICollection<Officer> officers, ICollection<Administrator> administrators) CalculatePayroll(ICollection<Officer> officers, ICollection<Administrator> administrators)
        {
            PersonnelContainer personnelContainer = new PersonnelContainer()
            {
                Administrators = administrators,
                Officers = officers
            };

            if (personnelContainer.Administrators.Count > 0)
            {
                foreach (var administrator in personnelContainer.Administrators)
                {
                    double perHourRate = Math.Max(administrator.PerHourRate, 500);
                    administrator.Payment = perHourRate * administrator.WorkHours + administrator.Bonus;
                }
            }

            if (personnelContainer.Officers.Count > 0)
            {
                foreach (var officer in personnelContainer.Officers)
                {
                    const int NORMAL_WORK_HOURS = 160;
                    const double OVERTIME_MULTIPLIER = 1.5;

                    double normalPayment;
                    double overtimePayment = 0;

                    if (officer.WorkHours <= NORMAL_WORK_HOURS)
                    {
                        normalPayment = officer.PerHourRate * officer.WorkHours;
                    }
                    else
                    {
                        normalPayment = officer.PerHourRate * NORMAL_WORK_HOURS;
                        double overtimeHours = officer.WorkHours - NORMAL_WORK_HOURS;
                        overtimePayment = overtimeHours * officer.PerHourRate * OVERTIME_MULTIPLIER;
                    }

                    officer.Payment = normalPayment + overtimePayment;
                }
            }

            return (personnelContainer?.Officers ?? new List<Officer>(),
                        personnelContainer?.Administrators ?? new List<Administrator>());

        }
    }
}
