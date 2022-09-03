using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalc
{
	internal class Manager : ChiefStaff
	{
		public Manager() : base(5, 40, 0.5m)
		{ }
		public override void AddSubordinate(Staff subordinate, int level)
		{
			if (level == 1)
			{
				subordinates.Add(subordinate);
			}
			base.AddSubordinate(subordinate, level);
		}
	}
}
