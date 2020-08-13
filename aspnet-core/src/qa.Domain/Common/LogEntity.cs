using System;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbxEps.CentralTools.Common
{
    public abstract class SoftDeleteLogEntity<TKey> : LogEntity<TKey>, IMayHaveDeleterName, ISoftDelete, IDeletionAuditedObject
    {
        public virtual bool IsDeleted { get; set; }

        public virtual string DeleterName { get; set; }

        public virtual Guid? DeleterId { get; set; }

        public virtual DateTime? DeletionTime { get; set; }
    }

    public abstract class LogEntity<TKey> : AuditedEntity<TKey>, IMayHaveCreatorName, IMayHaveLastModifierName
    {
        public virtual string CreatorName { get; set; }

        public virtual string LastModifierName { get; set; }
    }

    public abstract class SoftDeleteLogEntity : LogEntity, IMayHaveDeleterName, ISoftDelete, IDeletionAuditedObject
    {
        public virtual bool IsDeleted { get; set; }

        public virtual string DeleterName { get; set; }

        public virtual Guid? DeleterId { get; set; }

        public virtual DateTime? DeletionTime { get; set; }
    }

    public abstract class LogEntity : AuditedEntity, IMayHaveCreatorName, IMayHaveLastModifierName
    {
        public virtual string CreatorName { get; set; }

        public virtual string LastModifierName { get; set; }
    }
}
