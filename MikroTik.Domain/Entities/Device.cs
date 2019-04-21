using System.ComponentModel.DataAnnotations.Schema;

namespace MikroTik.Domain.Entities
{
    public class Device
    {
        public int Id { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        
        public string MacAddress { get; set; }
    }
}
