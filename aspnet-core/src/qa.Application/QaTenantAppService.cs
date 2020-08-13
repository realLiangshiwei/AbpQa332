using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Uow;
using Volo.Saas;
using Volo.Saas.Host;
using Volo.Saas.Host.Dtos;

namespace qa
{
    [Dependency(ReplaceServices = true)]
    [RemoteService(isEnabled: false)]
    public class QaTenantAppService : TenantAppService
    {
        private readonly IRepository<QaTenant, int> _qaTenantRepository;

        private readonly ITenantRepository _tenantRepository;

        private readonly ITenantManager _tenantManager;

        public QaTenantAppService(
            ITenantRepository tenantRepository,
            IEditionRepository editionRepository,
            ITenantManager tenantManager,
            IDataSeeder dataSeeder,
            IRepository<QaTenant, int> qaTenantRepository) : base(tenantRepository, editionRepository, tenantManager, dataSeeder)
        {
            _qaTenantRepository = qaTenantRepository;
            _tenantManager = tenantManager;
            _tenantRepository = tenantRepository;
        }

        public override async Task<SaasTenantDto> CreateAsync(SaasTenantCreateDto input)
        {
            using (var uow = UnitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
            {
                var tenant = await _tenantManager.CreateAsync(input.Name);
                input.MapExtraPropertiesTo(tenant);
                await _tenantRepository.InsertAsync(tenant);

                var rand = new Random();
                var qaTenant = new QaTenant(6100 + rand.Next(0, 99)) { AbpTenantId = tenant.Id };
                await _qaTenantRepository.InsertAsync(qaTenant);

                await uow.CompleteAsync();
                return ObjectMapper.Map<Tenant, SaasTenantDto>(tenant);
            }
        }

        //public async Task DeleteAsync(Guid id)
        //{
        //    using (var uow = UnitOfWorkManager.Begin(requiresNew: true, isTransactional: true))
        //    {
        //        var tenant = await _qaTenantRepository.Include(x=>x.AbpTenant).FirstOrDefaultAsync(x => x.Id == id);
        //        var abpTenant = tenant.AbpTenant;
        //        await _qaTenantRepository.DeleteAsync(tenant);
        //        await _abpTenantRepository.HardDeleteAsync(abpTenant);
        //        await uow.CompleteAsync();
        //    }
        //}
    }
}