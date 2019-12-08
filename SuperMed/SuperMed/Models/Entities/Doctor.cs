using System.Collections.Generic;
using SuperMed.Auth;
using SuperMed.DAL;

namespace SuperMed.Models.Entities
{
    public class Doctor : IEntity
    {
        public int Id { get; set; }

        public string DoctorId { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }
        
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        public string PersonId { get; set; }
        public ApplicationUser Person { get; set; }

        public List<Appointment> Appointments { get; set; }

        public Doctor()
        {
            Appointments = new List<Appointment>();
        }
    }
}
