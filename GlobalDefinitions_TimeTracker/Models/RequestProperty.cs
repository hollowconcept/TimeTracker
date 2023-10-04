using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDefinitions_TimeTracker.Models
{
    public class RequestProperty
    {
        public long Id { get; set; }

        public long RequestTypeId { get; set; }

        public long RequestTypeRequestId { get; set; }

        public long InitiatorUserId { get; set; }

        public long StatusId { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
