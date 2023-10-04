using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDefinitions_TimeTracker.Models
{
    public class BusinessAreaProperty
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Maximal 200 Zeichen sind erlaubt!")]
        public string BusinessAreaName { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Maximal 500 Zeichen sind erlaubt!")]
        public string Description { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
    }
}
