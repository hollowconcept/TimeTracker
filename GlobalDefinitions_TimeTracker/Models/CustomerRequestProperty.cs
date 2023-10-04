using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDefinitions_TimeTracker.Models
{
    public class CustomerRequestProperty
    {
        [Key]
        public long Id { get; set; }                                                                              /* Antrags ID */

        [Required]
        public long InitiatorUserId { get; set; }                                                                 /* Antragsersteller ID */

        [Required]
        public long WorkflowStatusId { get; set; }                                                                /* Aktueller Status vom Antrag */

        [Required]
        [MaxLength(200, ErrorMessage = "Maximal 200 Zeichen sind erlaubt!")]
        public string CustomerName { get; set; }                                                                  /* Kundennamen */

        [MaxLength(50, ErrorMessage = "Maximal 50 Zeichen sind erlaubt!")]
        public string CustomerNumber { get; set; }                                                                /* Zugehörige Kundennummer */

        [MaxLength(150, ErrorMessage = "Maximal 150 Zeichen sind erlaubt!")]
        public string ResponsibleSalesRepresentative { get; set; }                                                /* Zuständiger Vertriebsmitarbeiter für den Kunden */

        [Required]
        [DataType(DataType.Date)]
        public DateTime LastUpdate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
    }
}
