using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalc
{
	internal class Sales : ChiefStaff
	{
		public Sales() : base(1, 35, 0.3m)
		{ }

		public override void AddSubordinate(Staff subordinate, int level)
		{
			subordinates.Add(subordinate);
			base.AddSubordinate(subordinate, level);
		}
	}
}
