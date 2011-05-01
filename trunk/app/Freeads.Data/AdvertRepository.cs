using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Freeads.Core;
using Freeads.Core.RepositoryInterfaces;

using SharpArch.Data.NHibernate;

namespace Freeads.Data
{
    public class AdvertRepository : Repository<Advert>, IAdvertRepository
    {
    }
}
