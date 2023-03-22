using Bogus;
using TestDataGeneration;

var faker = new Faker("ru");

var data = new Faker<Student>()
    .RuleFor(s => s.FullName, f => f.Person.FullName)
    .RuleFor(s => s.Group, f => f.Company.CompanyName())
    .RuleFor(s => s.Birthday, f => f.Person.DateOfBirth);

var output = data.Generate(10000);
List<Student> students = output.ToList();


for (int i = 0; i < students.Count; i++)
{
    Console.WriteLine($"ФИО: {students[i].FullName}");
    Console.WriteLine($"Группа: {students[i].Group}");
    Console.WriteLine($"Дата рождения: {students[i].Birthday}");
}