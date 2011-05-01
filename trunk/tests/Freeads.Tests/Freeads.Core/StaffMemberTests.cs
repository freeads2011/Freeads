using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
//using NUnit.Framework.SyntaxHelpers;  // not needed for at least NUnit 2.5.2 and greater
using Freeads.Core;
using SharpArch.Core; 

namespace Tests.Freeads.Core
{
    [TestFixture]
    public class StaffMemberTests
    {
        [Test]
        public void CanCreateStaffMember()
        {
            string employeeNumber = "ABC123";
            string firstName = "Karel";
            string lastName = "Čapek";
            StaffMember staffMember =
                new StaffMember(employeeNumber)
                {
                    FirstName = firstName,
                    LastName = lastName
                };

            Assert.That(staffMember.EmployeeNumber, Is.EqualTo(employeeNumber));
            Assert.That(staffMember.FirstName, Is.EqualTo(firstName));
            Assert.That(staffMember.LastName, Is.EqualTo(lastName));
        }

        [Test]
        [ExpectedException(typeof(PreconditionException))]
        public void CannotCreateStaffMemberWithInvalidEmployeeId()
        {
            new StaffMember("  ");
        }

        [Test]
        public void CanCompareStaffMembers()
        {
            string employeeNumber = "ABC123";
            StaffMember staffMember = new StaffMember(employeeNumber);
            Assert.That(staffMember, Is.EqualTo(new StaffMember(employeeNumber)));
        }
    }
}


