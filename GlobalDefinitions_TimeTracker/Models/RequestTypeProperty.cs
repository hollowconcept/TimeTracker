using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDefinitions_TimeTracker.Models
{
    public class RequestTypeProperty
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Maximal 500 Zeichen sind erlaubt !")]
        public string Description { get; set; }
    }
}
