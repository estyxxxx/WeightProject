using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightModel.model
{
    [Table("Card")]
    public class Card
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public int? SubscriberID { get; set; }
        [ForeignKey(nameof(SubscriberID))]
        public Subscriber SubscribersCard { get; set; }
        public DateTime OpenDate { get; set; }
        public double BMI { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}
