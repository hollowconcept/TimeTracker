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
    public class ProjectProperty
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Customer")]
        public long CustomerId { get; set; }                                                                    /* Jedes Projekt gehört zu einem Kunden */

        public long InitiatorUserId { get; set; }                                                               /* ID vom Antragsersteller */

        public long ProjectStatusId { get; set; }                                                               /* Status des aktuellen Projektes */

        public List<ProjectChangeHistoryProperty> ListProjectChangeHistory { get; set; }                        /* Die Änderungshistorie vom Projekt */

        [Required()]
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

        [DataType(DataType.Date)]
        public DateTime LastUpdate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        public ProjectProperty()
        {
            ListProjectChangeHistory = new List<ProjectChangeHistoryProperty>();
        }
    }
}
