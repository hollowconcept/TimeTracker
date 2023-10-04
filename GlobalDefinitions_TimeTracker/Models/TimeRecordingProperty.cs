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
    public class TimeRecordingProperty
    {
        [Key]
        public long Id { get; set; }

        [Required()]
        [ForeignKey("User")]
        public long RecordingUserId { get; set; }                                                           /* Der User der seine Zeit erfasst */

        [Required()]
        [ForeignKey("Customer")]
        public long CustomerId { get; set; }                                                                /* Um welchen Kunden handelt es sich? */

        [Required()]
        [ForeignKey("Project")]
        public long ProjectId { get; set; }                                                                 /* Um welches Projekt handelt es sich? */

        [Required()]
        [ForeignKey("BusinessArea")]
        public long BusinessAreaId { get; set; }                                                            /* In welchem Bereich war man tätig? */

        [Required()]
        [DataType(DataType.Date)]
        public DateTime WorkingDate { get; set; }                                                           /* Arbeitstag */

        [Required()]
        [Range(0, 24, ErrorMessage = "Bitte geben Sie eine gültige Arbeitszeit zwischen 0 und 10 Stunden an.")]
        public decimal WorkingHours { get; set; }                                                           /* Arbeitsstunden */

        [MaxLength(500, ErrorMessage = "Die Beschreibung der umgesetzten Tätigkeit darf maximal 500 Zeichen lang sein.")]
        public string ExecutedActivity { get; set; }                                                        /* Umgesetzte Tätigkeit */

        [DefaultValue(true)]
        public bool Active { get; set; }                                                                    /* Zeit gelöscht */

        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
    }
}
