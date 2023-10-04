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
    public class ProjectChangeHistoryProperty
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Project")]
        public long ProjectId { get; set; }                                                                     /* Original Id */

        [Required]
        [ForeignKey("Customer")]
        public long CustomerId { get; set; }                                                                    

        [Required]
        public long InitiatorUserId { get; set; }                                                               /* ID vom Antragsersteller */

        [Required]
        public long ProjectStatusId { get; set; }                                                               /* Status des aktuellen Projektes */

        [Required]
        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string ProjectName { get; set; }                                                                 /* Projektname wird vom Projektantragsersteller vergeben */

        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string OrderNumberInternal { get; set; }                                                         /* Bestellnummer (Intern) wird vom zuständigen Vertriebsmitarbeiter bereitgestellt */

        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string OrderNumberExternal { get; set; }                                                         /* Bestellnummer (Extern) wird vom zuständigen Vertriebsmitarbeiter bereitgestellt */

        [MaxLength(100, ErrorMessage = "Maximal 100 Zeichen sind erlaubt !")]
        public string ResponsibleSalesRepresentative { get; set; }                                              /* Zuständiger Vertriebsmitarbeiter für das Projekt */

        [DataType(DataType.Date)]
        public DateTime ProjectStartTime { get; set; }                                                          /* Startdatum vom Projekt */

        [DataType(DataType.Date)]
        public DateTime ProjectEndTime { get; set; }                                                            /* Enddatum vom Projekt */

        [DefaultValue(false)]
        public bool ProjectHasDeadline { get; set; }                                                            /* Für das Projekt ist eine Deadline gesetzt worden */

        [Range(0, 1000000, ErrorMessage = "Das Budget muss zwischen 0 und 1.000.000 liegen.")]
        public decimal Contingent_Budget { get; set; }                                                          /* Budget wird in Geld angegeben */

        public decimal Contingent_WorkingDays { get; set; }                                                     /* Budget wird in Arbeitstagen angegeben */

        [Required]
        public long ChangedByUserId { get; set; }                                                               /* Wer hat Änderungen vollbracht? */

        [Required]
        [DataType(DataType.Date)]
        public DateTime ChangeDate { get; set; }
    }
}
