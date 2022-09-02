using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalc
{
	internal interface IChiefStaff
	{
		decimal GetSubordinateSalary(DateTime dateTime)
		{
			return Subordinates.Sum(s => s.GetSalaryOnDate(dateTime));		
		}
		List<Staff> Subordinates { get=> throw new NotImplementedException(); set=>throw new NotImplementedException();	}
	}
}
