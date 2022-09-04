using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalc
{
	internal abstract class ChiefStaff : Staff
	{
		/// <summary>
		/// кэшируем расчет на дату
		/// </summary>
		private Dictionary<DateTime, decimal> salaryOnDate = new Dictionary<DateTime, decimal>();

		decimal subordinatePremiumRate;
		public ChiefStaff(int yearlyInterestRate, int maxInterestRate, decimal subordinatePremiumRate) : base(yearlyInterestRate, maxInterestRate)
		{
			this.subordinatePremiumRate = subordinatePremiumRate;
		}

		protected List<Staff> subordinates = new List<Staff>();

		public override decimal GetSalaryOnDate(DateTime dateTime)
		{
			dateTime = dateTime.Date;

			if (salaryOnDate.ContainsKey(dateTime))
			{
				return salaryOnDate[dateTime];
			}
			decimal salary = base.GetSalaryOnDate(dateTime) + subordinatePremiumRate * subordinates.Sum(s => s.GetSalaryOnDate(dateTime)) / 100;
			salaryOnDate.Add(dateTime, salary);
			return salary;
		}
		public virtual void AddSubordinate(Staff subordinate, int level)
		{
			if (Chief != null)
			{
				Chief.AddSubordinate(subordinate, level + 1);
			}
		}
		public decimal GetTotalCompanySalary(DateTime dateTime)
		{
			return subordinates.Sum(s => s.GetSalaryOnDate(dateTime)) / 100;
		}
	}
}
