using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
//using NUnit.Framework.SyntaxHelpers;
using SharpArch.Testing.NUnit.NHibernate;

using Freeads.Core;
using Freeads.Core.RepositoryInterfaces;
using Freeads.Data; 

namespace Tests.Freeads.Data
{
    [TestFixture]
    [Category("DB Tests")]
    public class StaffMemberRepositoryTests : RepositoryTestsBase
    {
        protected override void LoadTestData()
        {
            AddStaffMember("thistest_Filter", "Mike", "Park");
            AddStaffMember("ABC123", "_test_FiLtEr_", "Vance");
            AddStaffMember("GHI789", "Lynette", "Knackstedt");
            AddStaffMember("DEF456", "Gerry",
                "Lundquistest_filtER");
        }

        protected override void SetUp()
        {
            ServiceLocatorInitializer.Init();
            base.SetUp();
        } 

        [Test]
        public void CanLoadStaffMembersMatchingFilter()
        {
            List<StaffMember> matchingStaffMembers =
                staffMemberRepository
                    .FindAllMatching("TEST_FiLtEr");
            Assert.That(matchingStaffMembers.Count,
                Is.EqualTo(3));
        }

        private void AddStaffMember(string employeeNumber,
            string firstName, string lastName)
        {
            StaffMember staffMember =
                new StaffMember(employeeNumber)
                {
                    FirstName = firstName,
                    LastName = lastName
                };

            staffMemberRepository.SaveOrUpdate(staffMember);
            FlushSessionAndEvict(staffMember);
        }

        private IStaffMemberRepository staffMemberRepository =
            new StaffMemberRepository();
    }
}
