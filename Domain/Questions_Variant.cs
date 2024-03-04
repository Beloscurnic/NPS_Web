using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Questions_Variant
    {
        public int Questions_VariantID { get; set; }
        public int Key { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; } //json


        public int? QuestionID { get; set; }
        public virtual Question? _Question { get; set; }
    }
}
