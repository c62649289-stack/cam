//main 
int age = 16;
if(CanDrive(age))
{
	System.Consloe.WriteLine("Just take my car!"); 
}
else{
	System.console.WriteLine("Better take an Uber");
}
 //end main

 static bool CanDrive(int age)
	{
		Systerm.Console.WriteLine("Have you passed your driver's test?");
		sting userInput = Console.ReadLine();
		if (age >= 16 && userInput == "Yes")
		{
		return true;	
		}
return false;
	}