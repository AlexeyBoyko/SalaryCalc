// See https://aka.ms/new-console-template for more information
using SalaryCalc;

Console.WriteLine("Hello, World!");


/*
  * Есть компания, у компании могут быть сотрудники. Сотрудник характеризуется именем, датой поступления на работу, базовой ставкой (для простоты, это значение по-умолчанию одинаково для всех видов сотрудников).
Сотрудники бывают 3 видов - Employee, Manager, Sales. У каждого сотрудника может быть начальник. У каждого сотрудника    кроме Employee могут быть подчинённые.
Зарплата сотрудника Employee - это базовая ставка плюс 3% за каждый год работы в компании, но не больше 30% суммарной надбавки
Зарплата сотрудника Manager - это базовая ставка плюс 5% за каждый год работы в компании (но не больше 40% суммарной надбавки) плюс 0,5% зарплаты всех подчинённых первого уровня
Зарплата сотрудника Sales - это базовая ставка плюс 1% за каждый год работы в компании (но не больше 35% суммарной надбавки) плюс 0,3% зарплаты всех подчинённых  всех уровней
У сотрудников (кроме Employee) может быть любое количество подчинённых любого вида.
 
Требуется: составить архитектуру классов, описывающих данную модель, а также реализовать алгоритм расчета зарплаты каждого сотрудника на произвольный момент времени (а также подсчёт суммарной зарплаты всех сотрудников фирмы в целом) с помощью c# (веб сервис/консоль/пользовательский интерфейс на выбор, это не существенно для данной задачи).
*/
int companySize = 10000;
Staff[] staffs = new Staff[companySize];
Sales director = new Sales();
staffs[0] = director;
Random random = new Random();
for (int i = 1; i < staffs.Length; i++)
{	
	int r = random.Next(1,4);
	switch(r)
	{
		case 1:
			staffs[i] = new Employee();
			break;
		case 2:
			staffs[i] = new Manager();
			break;
		case 3:
			staffs[i] = new Sales();
			break;
	}
	Staff newChief;
	do
	{
		r = random.Next(0, i);
		newChief = staffs[r];
	}
	while (newChief is not ChiefStaff);

	staffs[i].Chief = (ChiefStaff)newChief;
}

Console.WriteLine(director.CurrentSalary);
Console.WriteLine(director.GetTotalCompanySalary(DateTime.Now));
