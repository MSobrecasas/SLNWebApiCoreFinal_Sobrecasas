using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SWAdventureWorks_Sobrecasas.Models;
using System.Linq;

namespace SWAdventureWorks_Sobrecasas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AdventureWorks2019Context context;

        public DepartmentController(AdventureWorks2019Context context)
        {
            this.context = context;
        }

        //GET: api/department
        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return context.Departments.ToList();
        }

        //GET: api/department
        [HttpGet("{id}")]
        public ActionResult<Department> GetById(int id)
        {
            Department department = (from d in context.Departments
                           where d.DepartmentId == id
                           select d).SingleOrDefault();
            return department;
        }

        //GET: api/department/name/{name}
        [HttpGet("name/{name}")]
        public ActionResult<Department> GetByName(string name)
        {
            Department department = (from d in context.Departments
                           where d.Name == name
                           select d).SingleOrDefault();
            return department;
        }

        // POST : api/department
        [HttpPost]
        public ActionResult Post(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Departments.Add(department);
            context.SaveChanges();
            return Ok();
        }

    }
}
