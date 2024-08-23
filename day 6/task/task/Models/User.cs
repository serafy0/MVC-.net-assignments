using System.ComponentModel.DataAnnotations;
namespace task.Models
{
        public class User
        {
            public int ID { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Range(0, 120)]
            public int Age { get; set; }
        }
    
}
