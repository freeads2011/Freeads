using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpArch.Core;
using SharpArch.Core.DomainModel;

namespace Freeads.Core
{
    public class StaffMember : Entity
    {
        protected StaffMember() { } 

        public StaffMember(string employeeNumber)
        {
            Check.Require(!string.IsNullOrEmpty(employeeNumber)
                && employeeNumber.Trim() != String.Empty,
                "employeeNumber must be provided");
            EmployeeNumber = employeeNumber;
        }
 
        [DomainSignature]
        public virtual string EmployeeNumber { get; protected set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}
