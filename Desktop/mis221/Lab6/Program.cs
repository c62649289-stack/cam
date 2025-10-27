using Lab6;

//Declare and instatiate a car object
Car oldCar = new Car("Honda", "Civic"); 

//Turn the power on
oldCar.Power();

//Display the state of the car
Console.WriteLine(oldCar.ToString());

//Prompt the user for input and store it in the remaining miles variable
Console.WriteLine("How many miles are left in the tank?");
int userInput = int.Parse(Console.ReadLine());

//Change the remaining miles on the car
oldCar.SetMiles(userInput);


//Display the remaing miles on the car
Console.WriteLine($"Remaining Miles: {oldCar.GetMiles()}");

//Increase the speed of the car by 60 miles
for(int i = 0; i < 60; i++){
    oldCar.IncreaseSpeed();
}

//Display the current speed
Console.WriteLine("Speed: " + oldCar.GetSpeed());
Pause();
Console.WriteLine("Too fast! Lowering the speed.");
Pause();

//Decrease the speed
while(oldCar.GetSpeed() > 0){
    oldCar.DecreaseSpeed();
}

Console.WriteLine($"Speed: {oldCar.GetSpeed()}");

//Set a new value for remaining miles
oldCar.SetMiles(0);

Console.WriteLine($"Remaining Miles: {oldCar.GetMiles()}");
Console.WriteLine("Oh no, the car broke down...Now how will I get to Atlanta?");
Pause();


//HERE IS WHERE YOU DO TASK 5


Car newCar = new Car("Scion", "TC");

newCar.Power();

System.Console.WriteLine(newCar.ToString());

Console.WriteLine("How many miles are left in the tank?");
int newMiles = int.Parse(Console.ReadLine());

newCar.SetMiles(newMiles);

for (int i = 0; i < 20; i++)
{
    newCar.IncreaseSpeed();
}


System.Console.WriteLine($"Remaining Miles: {newCar.GetMiles()}");
System.Console.WriteLine($"Current Speed: {newCar.GetSpeed()}");

static void Pause()
{
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
}

