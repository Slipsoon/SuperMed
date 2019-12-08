using System;
using System.Collections.Generic;
using SuperMed.DAL;

namespace SuperMed.Models.Entities
{
    public class Patient : IEntity
    {
        public int Id { get; set; }

        public string PatientId { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public int Age
        {
            get
            {
                var now = DateTime.Now;
                var age = now.Year - BirthDate.Year;

                if (DateTime.Now.Year < BirthDate.Year)
                    age -= 1;

                return age;
            }
        }

        public ICollection<Appointment> Appointments { get; set; }

        public Patient()
        {
            Appointments = new List<Appointment>();
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}