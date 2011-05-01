using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernate.Criterion; 
using SharpArch.Data.NHibernate;
using Freeads.Core;
using Freeads.Core.RepositoryInterfaces;

namespace Freeads.Data
{
    public class StaffMemberRepository : Repository<StaffMember>, IStaffMemberRepository
    {
        public List<StaffMember> FindAllMatching(string filter)
        {
            ICriteria criteria =
                Session.CreateCriteria(typeof(StaffMember))
                .Add(
                    Expression.Or(Expression.InsensitiveLike("EmployeeNumber", filter, MatchMode.Anywhere),
                    Expression.Or(Expression.InsensitiveLike("FirstName", filter, MatchMode.Anywhere),
                    Expression.InsensitiveLike("LastName", filter, MatchMode.Anywhere)))
                 )
                .AddOrder(
                    new NHibernate.Criterion.Order("LastName", true)
                );

            return criteria.List<StaffMember>() as List<StaffMember>;
        }
    }
}
