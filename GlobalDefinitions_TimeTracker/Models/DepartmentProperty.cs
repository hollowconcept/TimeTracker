using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDefinitions_TimeTracker.Models
{
    public class DepartmentProperty
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Maximal 150 Zeichen sind erlaubt!")]
        public string DepartmentName { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
    }
}
