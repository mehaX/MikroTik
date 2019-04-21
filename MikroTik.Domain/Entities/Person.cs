namespace MikroTik.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public int ServerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
