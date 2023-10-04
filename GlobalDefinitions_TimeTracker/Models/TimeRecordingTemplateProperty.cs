using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDefinitions_TimeTracker.Models
{
    public class TimeRecordingTemplateProperty
    {
        public long TemplateId { get; set; }

        public long UserId { get; set; }

        public long CustomerId { get; set; }

        public long ProjectId { get; set; }

        public long BusinessAreaId { get; set; }

        public string ExecutedActivity { get; set; }

        public string TemplateName { get; set; }
    }
}
