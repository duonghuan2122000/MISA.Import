using System;

namespace MISA.Import.Core.Entites
{
    /// <summary>
    /// Thông tin nhóm khách hàng.
    /// </summary>
    /// CreatedBy: dbhuan (06/05/2021)
    public class CustomerGroup
    {
        /// <summary>
        /// Id nhóm khách hàng.
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng.
        /// </summary>
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Mô tả.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ngày tạo.
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa lần cuối.
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa lần cuối.
        /// </summary>
        public string ModifiedBy { get; set; }
    }
}
