using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightCORE.Response
{
    public class CardByIdResponse
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double BMI { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}
