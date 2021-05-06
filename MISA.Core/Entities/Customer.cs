using System;

namespace MISA.Import.Core.Entities
{
    /// <summary>
    /// Thông tin khách hàng
    /// </summary>
    /// CreatedBy: dbhuan (06/05/2021)
    public class Customer
    {
        /// <summary>
        /// Id khách hàng.
        /// </summary>
        
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng.
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// Họ và tên.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Mã thẻ thành viên.
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Id nhóm khách hàng.
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Số điện thoại.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ngày sinh.
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Tên công ty.
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế.
        /// </summary>
        public string CompanyTaxCode { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Địa chỉ.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ghi chú.
        /// </summary>
        public string Note { get; set; }

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
