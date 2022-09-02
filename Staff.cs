using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalc
{
	internal abstract class Staff
	{
		public Staff(int yearlyInterestRate, int maxInterestRate)
		{ 
			this.yearlyInterestRate = yearlyInterestRate;
			this.maxInterestRate = maxInterestRate;
		}
		public int yearlyInterestRate, maxInterestRate;
		public string Name { get; set; }
		public DateTime startDate { get; set; }
		public decimal baseSalary { get; set; }
		public IChiefStaff chief { get; set; }
		public virtual decimal GetSalaryOnDate(DateTime dateTime)
		{
			if (dateTime < startDate)
				return 0;

			int yearsWorked = (int)Math.Round((double)(dateTime.Subtract(startDate).Days / 365), MidpointRounding.ToZero);

			int effectiveInterestRate = Math.Min(yearsWorked * yearlyInterestRate, maxInterestRate);

			return baseSalary * (1.0m + effectiveInterestRate/100);
		}
	}
}
