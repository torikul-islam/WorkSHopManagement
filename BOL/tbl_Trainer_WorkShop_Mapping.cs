using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class tbl_Trainer_WorkShop_Mapping
    {
        public int SerialNo { get; set; }
        public int TrainerId { get; set; }
        public int WorkShopId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
