using SuperMed.DAL;

namespace SuperMed.Models.Entities
{
    public class Specialization : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}