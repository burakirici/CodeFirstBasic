using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstBasic.Data.Entities
{
    [Table("Games")]
    public class Game
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Platform { get; set; }
        public decimal Rating { get; set; }
    }
}
