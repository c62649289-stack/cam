using System.Diagnostics.Contracts;

namespace Lab6
{
    public class Car
    {
        private string make;
        private string model;
        private bool powerOn;
        private int remainingMiles;
        private int speed;


        public Car(string carMake, string carModel)
        {
            make = carMake;
            model = carModel;

            powerOn = false;
            remainingMiles = 110;
            speed = 0;
        }
        public int GetSpeed()
        {
            return speed;
        }
        public int GetMiles()
        {
            return remainingMiles;
        }
        public string GetMake()
        {
            return make;
        }
        public string GetModel()
        {
            return model;
        }
        public void SetMiles(int miles)
        {
            remainingMiles = miles;
        }
        public void Power()
        {
            powerOn = !powerOn;
        }
        public void IncreaseSpeed()

        {
            speed = speed + 1;
        }
        public void DecreaseSpeed()
        {
            speed = speed - 1;
        }

        public string ToString()
        {
            if (powerOn == true)
            {
                return "A" + make + "" + model + "has been turned on";
            }
            else
            {
                return "A" + make + "" + model + "has been turned off";
            }
        }
    }
}