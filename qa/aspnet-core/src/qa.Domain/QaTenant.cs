using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.TenantManagement;

namespace qa
{
    public class QaTenant : AggregateRoot<Guid>
    {
        public QaTenant(Guid id,string name)
        {
            Id = id;
            Name = name;
        }
        
        public Guid AbpTenantId { get; set; }

        public Tenant AbpTenant { get; set; }

        public string Name { get; set; }
    }
}