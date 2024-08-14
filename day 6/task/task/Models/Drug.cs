using System.ComponentModel.DataAnnotations.Schema;

namespace task.Models;

public class Drug
{
    public int ID { get; set; }
    public string Name { get; set; }

    public string ImagePath { get; set; }

    public DateTime ManufactureDate { get; set; }
    public DateTime ExpirationDate { get; set; }

    public int? CompanyID { get; set; }
    public virtual Company? Company { get; set; }

}
