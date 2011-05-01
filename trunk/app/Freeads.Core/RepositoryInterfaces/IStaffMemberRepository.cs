using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SharpArch.Core.PersistenceSupport;

namespace Freeads.Core.RepositoryInterfaces
{
    public interface IStaffMemberRepository : IRepository<StaffMember>
    {
        List<StaffMember> FindAllMatching(string filter);
    }
}
