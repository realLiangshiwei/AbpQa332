using AbxEps.CentralTools.Common;
using System;
using Volo.Saas;

namespace qa
{
    public class QaTenant : SoftDeleteLogEntity<int>
    {
        public QaTenant(int id)
        {
            Id = id;
        }
        
        public Guid AbpTenantId { get; set; }

        public Tenant AbpTenant { get; set; }

        public string ShortName { get; set; }

        public string FullName { get; set; }

        public int CompanyId { get; set; }

        public string Comment { get; set; }

        public int? MasterId { get; set; }

        public QaTenant MasterTenant { get; set; }

        public bool? IsMaster { get; set; }
    }
}