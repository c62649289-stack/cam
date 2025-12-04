using System;
using System.Collections.Generic;
using System.Linq
using System.Threading.Tasks


namespace LabOct24;
{
    public class Lab
    {
        private string name;

        private int age;
        private string grade;
        private int creditHours;

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
            grade = "Freshman";
            creditHours = 0;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
        public void SetAge()
        {
            this.age = age;
        }

        public void SetCreditHours(int creditHours)
        {
            this.creditHours = creditHours;
        }

        public string GetName()
        {
            return name;
        }
        public int GetAge()
        {
            return age;
        }
        public string GetGrade()
        {
            return grade;
        }
        public int GetCreditHours()
        {
            return creditHours;
        }
        public void IncCreditHours(int hours)
        {
            creditHours += hours;
        }

    }
}