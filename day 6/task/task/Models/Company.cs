namespace task.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual List<Drug>? Drugs { get; set; } = new List<Drug>();

    }
}
