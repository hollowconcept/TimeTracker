using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDefinitions_TimeTracker.Models
{
    public class CustomerProperty
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Request")]
        public long RequestId { get; set; }                                                                     /* Über welchen Antrag wurde der Kunde freigegeben ? */

        [ForeignKey("User")]
        public long InitiatorUserId { get; set; }                                                               /* Wer war der Initiator für den Kunden? */

        [Required()]
        [ConcurrencyCheck]
        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string CustomerName { get; set; }                                                                /* Kundenname */

        [Required()]
        [ConcurrencyCheck]
        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string CustomerNumber { get; set; }                                                              /* Zugehörige Kundennummer */

        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string ResponsibleSalesRepresentative { get; set; }                                              /* Zuständiger Vertriebsmitarbeiter für das Projekt */

        [DefaultValue(true)]
        public bool Active { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
    }
}
