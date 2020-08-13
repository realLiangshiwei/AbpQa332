using System;
using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Timing;
using Volo.Abp.Users;

namespace AbxEps.CentralTools.Common
{
    [Dependency(ReplaceServices = true)]
    public class LogAuditPropertySetter : IAuditPropertySetter, ITransientDependency
    {
        private readonly AuditPropertySetter _auditPropertySetter;
        private ICurrentUser CurrentUser { get; }

        private string GetCreatorName => CurrentUser.UserName != null && CurrentUser.UserName.Length > 10 ? CurrentUser.UserName.Left(10) : CurrentUser.UserName;

        private string GetLastModifierName => CurrentUser.UserName != null && CurrentUser.UserName.Length > 10 ? CurrentUser.UserName.Left(10) : CurrentUser.UserName;

        private string GetDeleterName => CurrentUser.UserName != null && CurrentUser.UserName.Length > 10 ? CurrentUser.UserName.Left(10) : CurrentUser.UserName;

        public LogAuditPropertySetter(ICurrentUser currentUser, ICurrentTenant currentTenant, IClock clock)
        {
            _auditPropertySetter = new AuditPropertySetter(currentUser, currentTenant, clock);
            CurrentUser = currentUser;
        }

        public void SetCreationProperties(object targetObject)
        {
            _auditPropertySetter.SetCreationProperties(targetObject);
            SetCreatorName(targetObject);
            SetModificationProperties(targetObject);
        }

        public void SetModificationProperties(object targetObject)
        {
            _auditPropertySetter.SetModificationProperties(targetObject);
            SetLastModifierName(targetObject);
        }

        public void SetDeletionProperties(object targetObject)
        {
            _auditPropertySetter.SetDeletionProperties(targetObject);
            SetDeleterName(targetObject);
        }

        private void SetCreatorName(object targetObject)
        {
            if (!CurrentUser.Id.HasValue)
            {
                return;
            }

            if (targetObject is IMultiTenant multiTenantEntity)
            {
                if (multiTenantEntity.TenantId != CurrentUser.TenantId)
                {
                    return;
                }
            }

            if (targetObject is IMayHaveCreatorName mayHaveCreatorNameObject)
            {
                if (!string.IsNullOrWhiteSpace(mayHaveCreatorNameObject.CreatorName))
                {
                    return;
                }

                mayHaveCreatorNameObject.CreatorName = GetCreatorName;
            }
        }

        private void SetLastModifierName(object targetObject)
        {
            if (!CurrentUser.Id.HasValue)
            {
                return;
            }

            if (targetObject is IMultiTenant multiTenantEntity)
            {
                if (multiTenantEntity.TenantId != CurrentUser.TenantId)
                {
                    return;
                }
            }

            if (targetObject is IMayHaveLastModifierName mayHaveLastModifierNameObject)
            {
                if (!string.IsNullOrWhiteSpace(mayHaveLastModifierNameObject.LastModifierName))
                {
                    return;
                }

                mayHaveLastModifierNameObject.LastModifierName = GetLastModifierName;
            }
        }

        private void SetDeleterName(object targetObject)
        {
            if (!CurrentUser.Id.HasValue)
            {
                return;
            }

            if (targetObject is IMultiTenant multiTenantEntity)
            {
                if (multiTenantEntity.TenantId != CurrentUser.TenantId)
                {
                    return;
                }
            }

            if (targetObject is IMayHaveDeleterName mayHaveDeleterNameObject)
            {
                if (!string.IsNullOrWhiteSpace(mayHaveDeleterNameObject.DeleterName))
                {
                    return;
                }

                mayHaveDeleterNameObject.DeleterName = GetDeleterName;
            }
        }
    }
}
