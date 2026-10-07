using System.ComponentModel.DataAnnotations;

namespace Computer.Controllers.models
{
    public class Osystem
    {
        [Key]
        [MaxLength(36)]
        public Guid ID { get; set; }
        
        public string Name { get; set; }

        public int version { get; set; }

        public DateTime RegisterTime {  get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
