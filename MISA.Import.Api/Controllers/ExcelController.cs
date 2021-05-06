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

        [HttpPost("import")]
        public IActionResult InsertCustomers(List<CustomerImport> customersImport)
        {
            int success = _customerService.InsertCustomers(customersImport);
            return Ok(new
            {
                totalRecord= customersImport.Count(),
                success = success,
                customers = customersImport
            });
        }
    }
}
