using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CORSOpenPolicy")]
    public class EmployeeController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IEmployeeRepository _employee;
        public EmployeeController(IWebHostEnvironment env, IEmployeeRepository employee)
        {
            _env = env;
            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
            
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> Get()
        {
            var xData = await _employee.GetEmployee();
            return Ok(xData);
        }


        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> Post(Employee emp)
        {

            var result = await _employee.InsertEmployee(emp);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }

            return Ok("Added Successfully");
        }


        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Put(Employee emp)
        {
            var result = await _employee.UpdateEmployee(emp);
            if (result == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Updated Successfully");
        }


        [HttpDelete("{id}")]
        
        public JsonResult Delete(int id)
        {
            var result = _employee.DeleteEmployee(id);
            return new JsonResult("Deleted Successfully");
        }


        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    stream.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception ex)
            {
                return new JsonResult("anonymous.png");
            }
        }       
    }
}
