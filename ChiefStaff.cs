using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalc
{
	internal class ChiefStaff : Staff
	{
		decimal subordinatePremiumRate;
		public ChiefStaff(int yearlyInterestRate, int maxInterestRate, decimal subordinatePremiumRate) : base(yearlyInterestRate, maxInterestRate)
		{
			this.subordinatePremiumRate = subordinatePremiumRate;
		}

		protected List<Staff> subordinates;

		public override decimal GetSalaryOnDate(DateTime dateTime)
		{
			return base.GetSalaryOnDate(dateTime) + subordinatePremiumRate * subordinates.Sum(s => s.GetSalaryOnDate(dateTime))/100;
		}		
	}
}
