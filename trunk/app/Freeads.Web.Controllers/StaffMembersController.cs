using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;
using SharpArch.Core;
using SharpArch.Web;
using Freeads.Core;
using Freeads.Core.RepositoryInterfaces;


namespace Freeads.Web.Controllers
{
    public class StaffMembersController : Controller
    {
        public StaffMembersController(IStaffMemberRepository staffMemberRepository) {
            Check.Require(staffMemberRepository != null,"staffMemberRepository may not be null"); 
            this.staffMemberRepository = staffMemberRepository;
        }

        public ActionResult ListStaffMembersMatching(
            string filter)
        {
            List<StaffMember> matchingStaffMembers = staffMemberRepository.FindAllMatching(filter);
            return View("ListStaffMembersMatchingFilter", matchingStaffMembers);
        }

        private readonly IStaffMemberRepository staffMemberRepository;
    }
}
