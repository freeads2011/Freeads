using System;
using System.Linq;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using Freeads.Core;
using Freeads.Data.NHibernateMaps.Conventions;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate.FluentNHibernate;

namespace Freeads.Data.NHibernateMaps
{

    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {

        #region IAutoPersistenceModelGenerator Members

        public AutoPersistenceModel Generate()
        {
            return AutoMap.AssemblyOf<Class1>(new AutomappingConfiguration())
                .Conventions.Setup(GetConventions())
                .IgnoreBase<Entity>()
                .IgnoreBase(typeof(EntityWithTypedId<>))
                .UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
        }

        #endregion

        private Action<IConventionFinder> GetConventions()
        {
            return c =>
            {
                c.Add<Freeads.Data.NHibernateMaps.Conventions.ForeignKeyConvention>();
                c.Add<Freeads.Data.NHibernateMaps.Conventions.HasManyConvention>();
                c.Add<Freeads.Data.NHibernateMaps.Conventions.HasManyToManyConvention>();
                c.Add<Freeads.Data.NHibernateMaps.Conventions.ManyToManyTableNameConvention>();
                c.Add<Freeads.Data.NHibernateMaps.Conventions.PrimaryKeyConvention>();
                c.Add<Freeads.Data.NHibernateMaps.Conventions.ReferenceConvention>();
                c.Add<Freeads.Data.NHibernateMaps.Conventions.TableNameConvention>();
            };
        }
    }
}
