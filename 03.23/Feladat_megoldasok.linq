string[] people = {"Nemet Viktor", "Toronya Bertalan", "Veres Marcell", "Polonkai David", "Bolyki Balazs"};
people.Take(3).Dump();
people.OrderByDescending(x => x).Dump();
people.Where(x => x.Contains("L") || x.Contains("l")).Count().Dump();  //Count
var taskE = people.Where(x => x.Split(" ")[0].Length >5);
taskE.Select(x => x.Split(" ")[1]).Dump();


int[] numbers = {0,1,2,3,4,5,6,7,8,9,10};
numbers.Where(x => x%2 == 0).Select(x => x*x).Dump();
double average = numbers.Average().Dump();

numbers.Where(x => x>average).Dump();

numbers.Where(x => x > average).Select(x => new{x, Diff = Math.Abs(x - average)}).Dump();
