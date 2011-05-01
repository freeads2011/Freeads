using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc; 
using System.Collections.Generic;
using NUnit.Framework;
using MvcContrib.TestHelper;
using SharpArch.Core.PersistenceSupport;
using Rhino.Mocks;

using Freeads.Core;
using Freeads.Web.Controllers;
using Freeads.Core.RepositoryInterfaces;


namespace Tests.Freeads.Web.Controllers
{
    [TestFixture]
    public class StaffMembersControllerTests
    {
        [Test]
        public void CanListFilteredStaffMembers()
        {
            StaffMembersController controller =
                new StaffMembersController(
                   CreateMockStaffMemberRepository());


            ViewResult result =
                controller.ListStaffMembersMatching("martin")
                    .AssertViewRendered()
                    .ForView("ListStaffMembersMatchingFilter");

            Assert.That(result.ViewData, Is.Not.Null);
            Assert.That(result.ViewData.Model as List<StaffMember>, Is.Not.Null);
            Assert.That((result.ViewData.Model as List<StaffMember>).Count, Is.EqualTo(4));
        }

        /// <summary>
        /// In most cases, we'd simply return
        /// IRepository<MyEntity>, but since we're
        /// leveraging a custom Repository method, we need a
        /// custom Repository interface.
        /// </summary>
        public IStaffMemberRepository CreateMockStaffMemberRepository()
        {
            MockRepository mocks = new MockRepository();
            IStaffMemberRepository mockedRepository = mocks.StrictMock<IStaffMemberRepository>();
            Expect.Call(mockedRepository.FindAllMatching(null))
                .IgnoreArguments()
                .Return(CreateStaffMembers());

            mocks.Replay(mockedRepository);

            return mockedRepository;
        }

        private List<StaffMember> CreateStaffMembers()
        {
            List<StaffMember> staffMembers =
                new List<StaffMember>();

            staffMembers.Add(new StaffMember("ABC123"));
            staffMembers.Add(new StaffMember("DEF456"));
            staffMembers.Add(new StaffMember("GHI789"));
            staffMembers.Add(new StaffMember("Abracadabera"));

            return staffMembers;
        }
    }
}
