using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Services;
using MISA.Import.Core.Entites;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MISA.Import.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private ICustomerService _customerService;

        public ExcelController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Endpoint đọc dữ liệu từ file excel và đưa ra lỗi của từng khách hàng.
        /// </summary>
        /// <param name="formFile">file excel</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Danh sách khách hàng và lỗi của từng khách hàng.</returns>
        /// <response code="200">Có dữ liệu trả về.</response>
        /// <response code="400">Lỗi client.</response>
        /// <response code="500">Lỗi server</response>
        [HttpPost("reader")]
        public async Task<IActionResult> Post(IFormFile formFile, CancellationToken cancellationToken)
        {
            if(formFile == null || formFile.Length <= 0)
            {
                return BadRequest();
            }

            if(!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest();
            }

            var res = await _customerService.ReadFromExcel(formFile, cancellationToken);
            return Ok(res);
        }

        /// <summary>
        /// Endpoint thêm danh sách khách không có lỗi vào db.
        /// </summary>
        /// <param name="customersImport">Danh sách khách hàng và lỗi của từng khách hàng.</param>
        /// <returns>Số khách hàng thêm thành công.</returns>
        /// <response code="200">Thêm thành công.</response>
        /// <response code="500">Lỗi server.</response>
        [HttpPost("import")]
        public IActionResult InsertCustomers(List<CustomerImport> customersImport)
        {
            int success = _customerService.InsertCustomers(customersImport);
            return Ok(new
            {
                totalRecord= customersImport.Count(),
                success = success
            });
        }
    }
}
