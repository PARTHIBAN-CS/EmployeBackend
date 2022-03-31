using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    public class AttendanceController : ControllerBase
    {


        private List<Attendance> _attendance = new List<Attendance>
        {


        };
        private readonly EmployeContext _context;
        private EmployeContext _employes;
        public AttendanceController(EmployeContext context, EmployeContext employes)
        {
            _context = context;
            _employes = employes;
            if (_context.Attendance.Count() == 0)
            {
                _context.Attendance.Add(new Attendance { id = 1, firstname = "Arun", attendance = "Present" }); _context.SaveChanges();
            }
        }

        [HttpGet]
        [Route("api/Attendance/details")]
        public List<Attendance> GetAlldetail()
        {
            var query =
            (
                from s in _employes.Employes
                join m in _context.Attendance
                on s.firstname equals m.firstname
                select new Attendance
                {
                    firstname = s.firstname,
                    attendance = m.attendance,
                   
                });

            return query.ToList();
        }



        [HttpPost]
        [Route("api/Attendance/Create")]
        //To Add new employee record  
        public int AddMarklist(Attendance attendance)
        {
            try
            {
                _context.Attendance.Add(attendance);
                _context.SaveChanges();
                int id = attendance.id;
                // List<Attendance> st = new List<Attendance>();
                // st.Add(attendance);
                return id;
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        [Route("api/Attendance/Edit/{id}")]

        //To Update the records of a particluar employee    
        public int UpdateMarklists(int id, Attendance attendance)
        {
            try
            {
                var result = _context.Attendance.SingleOrDefault(b => b.id == id);
                if (result != null)
                {
                    //result.firstname = firstname;
                    result.attendance = attendance.attendance;
                    _context.SaveChanges();
                    return 1;
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }


        

        //Get the details of a particular employee    
        //Get the details of a particular employee 

        [HttpGet]
        [Route("api/[controller]/Details/id")]
        public ActionResult<List<Attendance>> GetAll1()
        {
            return _context.Attendance.OrderBy(id => id).ToList();
        }

       

    }


}

