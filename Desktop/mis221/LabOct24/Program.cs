using LabOct24;

Student myStudent = new Student("Bob", 25);
myStudent.IncCreditHours(20);
myStudent.SetGrade("Super Senior");

Student jake = new Student("Jake", 40);
jake.SetGrade("???");
jake.SetCreditHours(2000);

System.Console.WriteLine($"{jake.GetAge()}");