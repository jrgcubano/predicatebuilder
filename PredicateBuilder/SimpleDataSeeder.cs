using PredicateBuilder.Entities;
using System;

namespace PredicateBuilder
{
    public class SimpleDataSeeder
    {
        SimpleContext _ctx;
        public SimpleDataSeeder(SimpleContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {           

            try
            {              
                for (int i = 0; i < studentNames.Length; i++)
                {
                    var nameGenderMail = SplitValue(studentNames[i]);
                    var student = new Student()
                    {
                        Email = String.Format("{0}.{1}@{2}", nameGenderMail[0], nameGenderMail[1], nameGenderMail[3]),
                        UserName = String.Format("{0}{1}", nameGenderMail[0], nameGenderMail[1]),
                        FirstName = nameGenderMail[0],
                        LastName = nameGenderMail[1],                           
                        DateOfBirth = DateTime.UtcNow.AddDays(-new Random().Next(7000, 8000)),                     
                    };

                    _ctx.Students.Add(student);                              
                }

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                throw ex;
            }

        }

        private static string[] SplitValue(string val)
        {
            return val.Split(',');
        }

        private string RandomString(int size)
        {
            Random _rng = new Random((int)DateTime.Now.Ticks);
            string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }

        static string[] studentNames = 
        { 
            "Taiseer,Joudeh,Male,hotmail.com", 
            "Hasan,Ahmad,Male,mymail.com", 
            "Moatasem,Ahmad,Male,outlook.com", 
            "Salma,Tamer,Female,outlook.com", 
            "Ahmad,Radi,Male,gmail.com", 
            "Bill,Gates,Male,yahoo.com", 
            "Shareef,Khaled,Male,gmail.com", 
            "Aram,Naser,Male,gmail.com", 
            "Layla,Ibrahim,Female,mymail.com", 
            "Rema,Oday,Female,hotmail.com",
            "Fikri,Husein,Male,gmail.com",
            "Zakari,Husein,Male,outlook.com",
            "Taher,Waleed,Male,mymail.com",
            "Tamer,Wesam,Male,yahoo.com",
            "Khaled,Hasaan,Male,gmail.com",
            "Asaad,Ibrahim,Male,hotmail.com",
            "Tareq,Nassar,Male,outlook.com",
            "Diana,Lutfi,Female,outlook.com",
            "Tamara,Malek,Female,gmail.com",
            "Arwa,Kamal,Female,yahoo.com",
            "Jana,Ahmad,Female,yahoo.com",
            "Nisreen,Tamer,Female,gmail.com",
            "Noura,Ahmad,Female,outlook.com"
        };          
    }
}
