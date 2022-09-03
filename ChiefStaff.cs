using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalc
{
	internal abstract class ChiefStaff : Staff
	{
		decimal subordinatePremiumRate;
		public ChiefStaff(int yearlyInterestRate, int maxInterestRate, decimal subordinatePremiumRate) : base(yearlyInterestRate, maxInterestRate)
		{
			this.subordinatePremiumRate = subordinatePremiumRate;
		}

		protected List<Staff> subordinates = new List<Staff>();

		public override decimal GetSalaryOnDate(DateTime dateTime)
		{
			return base.GetSalaryOnDate(dateTime) + subordinatePremiumRate * subordinates.Sum(s => s.GetSalaryOnDate(dateTime))/100;
		}
		public virtual void AddSubordinate(Staff subordinate, int level)
		{
			if (Chief != null)
			{
				Chief.AddSubordinate(subordinate, level + 1);
			}
		}
	}
}
