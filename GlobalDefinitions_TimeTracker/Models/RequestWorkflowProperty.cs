using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDefinitions_TimeTracker.Models
{
    public class RequestWorkflowProperty
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [ForeignKey("Request")]
        public long RequestId { get; set; }

        [Required]
        [ForeignKey("RequestType")]
        public long RequestTypeId { get; set; }

        [Required]
        [ForeignKey("RequestAction")]
        public long RequestActionId { get; set; }

        [Required]
        [ForeignKey("RequestStatus")]
        public long RequestStatusId { get; set; }

        [Required]
        [ForeignKey("Users")]
        public long ActionUserId { get; set; }

        [MaxLength(500, ErrorMessage = "Maximal 500 Zeichen sind erlaubt !")]
        public string UserRemark { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }
    }
}
