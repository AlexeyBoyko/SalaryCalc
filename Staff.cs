using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalc
{
	internal abstract class Staff
	{		
		private decimal baseSalary = 10;

		private ChiefStaff chief;
		public Staff(int yearlyInterestRate, int maxInterestRate)
		{ 
			this.yearlyInterestRate = yearlyInterestRate;
			this.maxInterestRate = maxInterestRate;
			startDate = DateTime.Now.Date; // TODO: добавить возможность задания даты поступления на работу
		}
		public int yearlyInterestRate, maxInterestRate;
		public string Name { get; set; }
		public DateTime startDate;
		public decimal BaseSalary { get { return baseSalary; } }
		public ChiefStaff Chief { 
			get
			{
				return chief;
			}
			set
			{
				this.chief = value;
				chief.AddSubordinate(this, 1);
			}
				}
		public virtual decimal GetSalaryOnDate(DateTime dateTime)
		{
			dateTime = dateTime.Date;

			if (dateTime < startDate)
				return 0;

			int yearsWorked = (int)Math.Round((double)(dateTime.Subtract(startDate).Days / 365), MidpointRounding.ToZero);

			int effectiveInterestRate = Math.Min(yearsWorked * yearlyInterestRate, maxInterestRate);

			return baseSalary * (1.0m + effectiveInterestRate/100);
		}
		public decimal CurrentSalary
		{ get { return GetSalaryOnDate(DateTime.Now); } }
	}
}
