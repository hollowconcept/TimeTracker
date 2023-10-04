using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDefinitions_TimeTracker.Models
{
    public class EnumProperty
    {
        public enum EnumSelect
        {
            Default = 0,
            NoItems = 1,
            Error = 2,
            Success = 3
        }

        public enum EnumUpdate
        {
            Default = 0,
            NotExists = 1,
            Error = 2,
            Success = 3
        }

        public enum EnumInsert
        {
            Default=0,
            Exists=1,
            Error=2,
            Success=3
        }

        public enum EnumProjectStatus
        {
            WorkInProgress=1,
            OnHold=2,
            Close=3
        }

        public enum EnumRequestTypes
        {
            CustomerRequest = 1,
            ProjectRequest = 2
        }

        public enum EnumRequestWorkflowStatus
        { 
            Erstellt=1,
            InBearbeitung=2,
            Genehmigt=3,
            Abgelehnt=4,
            Geschlossen=5
        }
    }
}
