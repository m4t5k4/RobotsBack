using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotsAPI.Models
{
    public class Robot
    {
        public int RobotID { get; set; }
        public string Name { get; set; }
        public string Serialnumber { get; set; }
        public int ManufacturerID { get; set; }
        public int CategoryID { get; set; }
        public string Image { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Category Category { get; set; }
    }
}
