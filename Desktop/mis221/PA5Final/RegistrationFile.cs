namespace PA5Final
{
    public class RegistrationFile
    {
        private Registration[] registrations;

        public RegistrationFile(Registration[] registrations)
        {
            this.registrations = registrations;
        }

        public void GetAllRegistrations()
        {
            Registration.SetCount(0);

            StreamReader inFile = new StreamReader("registration.txt");
            string line = inFile.ReadLine();

            while (line != null)
            {
                string[] temp = line.Split('#');

                Registration[Registration.GetCount()] = new Registration(temp[0], temp[1], temp[2], temp[3], temp[4], bool.Parse(temp[5]));

                Registration.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }

        public void SaveAllRegistrations()
        {
            StreamWriter outFile = new StreamWriter("registration.txt");

            for (int i = 0; i < Registration.GetCount(); i++)
            {
                outFile.WriteLine(registrations[i].ToFile());
            }

            outFile.Close();
        }
    }
}
