using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ABP.ProductManagement.Sample
{
    /// <summary>
    /// 這種複合Key 只用於 關聯式資料庫
    /// </summary>
    public class UserRole : Entity
    {
        public Guid UserId { get; set; }

        public Guid RoleId { get; set; }

        public override object[] GetKeys() // 非範型 代表有複合Key 所以要實作 GeyKeys
        {
            return new object[] { UserId, RoleId };
        }
    }
}
