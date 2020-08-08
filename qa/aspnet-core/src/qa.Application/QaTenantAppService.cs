using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;

namespace qa
{
    public class QaTenantAppService : ApplicationService
    {
        private readonly IRepository<QaTenant, Guid> _qaTenantRepository;

        private readonly IRepository<Tenant, Guid> _abpTenantRepository;

        private readonly ITenantManager _tenantManager;

        public QaTenantAppService(IRepository<QaTenant, Guid> qaTenantRepository, ITenantManager tenantManager,
            IRepository<Tenant, Guid> abpTenantRepository)
        {
            _qaTenantRepository = qaTenantRepository;
            _tenantManager = tenantManager;
            _abpTenantRepository = abpTenantRepository;
        }

        public async Task<TenantDto> CreateTenant(string name)
        {
            using (var uow = UnitOfWorkManager.Begin(requiresNew: true, isTransactional:true))
            {
                var tenant = await _tenantManager.CreateAsync(name);
                await _abpTenantRepository.InsertAsync(tenant);

                var qaTenant = new QaTenant(GuidGenerator.Create(), name) {AbpTenantId = tenant.Id};
                await _qaTenantRepository.InsertAsync(qaTenant);

                await uow.CompleteAsync();
                return ObjectMapper.Map<Tenant, TenantDto>(tenant);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var uow = UnitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
            {
                var tenant = await _qaTenantRepository.Include(x=>x.AbpTenant).FirstOrDefaultAsync(x => x.Id == id);
                var abpTenant = tenant.AbpTenant;
                await _qaTenantRepository.DeleteAsync(tenant);
                await _abpTenantRepository.HardDeleteAsync(abpTenant);
                await uow.CompleteAsync();
            }
        }
    }
}