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
    public class ProjectRequestProperty
    {
        [Key]
        public long Id { get; set; }                                                                             /* Antrags ID */

        [Required]
        [ForeignKey("User")]
        public long InitiatorUserId { get; set; }

        [Required]
        [ForeignKey("WorkflowStatus")]
        public long WorkflowStatusId { get; set; }                                                               /* Aktueller Status vom Antrag */

        [Required]
        [ForeignKey("Customer")]
        public long CustomerId { get; set; }                                                                     /* Kunde muss ausgewählt werden */

        [Required]
        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string ProjectName { get; set; }                                                                  /* Projektname wird vom Projektantragsersteller vergeben */

        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string OrderNumberInternal { get; set; }                                                          /* Bestellnummer (Intern) wird vom zuständigen Vertriebsmitarbeiter bereitgestellt */

        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string OrderNumberExternal { get; set; }                                                          /* Bestellnummer (Extern) wird vom zuständigen Vertriebsmitarbeiter bereitgestellt */

        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string ResponsibleSalesRepresentative { get; set; }                                               /* Zuständiger Vertriebsmitarbeiter für das Projekt */

        [DataType(DataType.Date)]
        public DateTime ProjectStartTime { get; set; }                                                           /* Startdatum vom Projekt */

        [DataType(DataType.Date)]
        public DateTime ProjectEndTime { get; set; }                                                             /* Enddatum vom Projekt */

        [DefaultValue(false)]
        public bool ProjectHasDeadline { get; set; }
    }
}
