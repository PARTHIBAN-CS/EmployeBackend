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
    //[Route("api/[controller]")]
    public class EmployesController : ControllerBase
    {


        private List<Employes> _employes = new List<Employes>
        {
            new Employes {rollno=1, firstname = "Arun" ,lastname=  "A", gender= "male", phoneno="9876543211", mail = "arun@gmail.com" , password = "SynapseArun" },
            // new Login { mail = "jadav@gmail.com" , password = "SynapseJadav" },
            // new Login { mail = "ritu@gmail.com" , password = "SynapseRitu" },
            // new Login { mail = "kumar@gmail.com" , password = "Synapsekumar" },
            // new Login { mail = "barat@gmail.com" , password = "SynapseBarat" },            

        };
        private readonly EmployeContext _context;
        // private StudentsContext _student;
        public EmployesController(EmployeContext context)
        {
            _context = context;
            if (_context.Employes.Count() == 0)
            {
                _context.Employes.Add(new Employes { rollno = 1, firstname = "Arun", lastname = "A", gender = "male", phoneno = "9876543211", mail = "arun@gmail.com", password = "SynapseArun" }); _context.SaveChanges();
            }
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAll()
        {
            return Ok(_employes);
        }

        [HttpPut]
        [Route("api/[controller]/detail")]
        public IActionResult GetById(Employes login)
        {
            var log = _context.Employes.Where(b => b.mail == login.mail).Where(b => b.password == login.password);
            if (log == null)

                return NotFound();

            return Ok(log);
        }

        // [HttpPost]
        // [Route("api/[controller]/Create")]
        // public int AddLogin(Employes employes)
        // {  
        //     //var product1 = _context.Employes.Count(a=>a.mail==employes.mail);
        //     try  
        //     {
        //          _context.Employes.Add(employes);  
        //          _context.SaveChanges();  
        //          var rollno = employes.rollno;
        //          return rollno;
        //     } catch  
        //     {  
        //         throw;  
        //     }

        // }
        [HttpPost]
        [Route("api/Employes/Create")]
        public IActionResult AddLogin(Employes employes)
        {
            var product1 = _context.Employes.Count(a => a.mail == employes.mail);
            try
            {
                if (_context.Employes.Count(a => a.mail == employes.mail) == 0)
                {
                    _context.Employes.Add(employes);
                    _context.SaveChanges();

                    return Ok(product1);
                }

            }
            catch
            {
                throw;
            }
            return Ok(product1);
        }

        [HttpGet]
        [Route("api/Employes/rollno")]
        public List<Employes> GetAllvalue()

        {
            var result = (from s in _context.Employes
                          select new Employes
                          {
                              rollno = s.rollno,
                              firstname = s.firstname,
                              lastname = s.lastname,
                              gender = s.gender,
                              phoneno = s.phoneno,
                              mail = s.mail,
                              password = s.password,

                          }).OrderBy(s => s.rollno)

                            .ToList();
            return result;
        }

        [HttpPut]
        [Route("api/Employes/Edit/{rollno}")]

        //To Update the records of a particluar employee    
        public int UpdateStudents(int rollno, Employes employes)
        {
            try
            {
                var result = _context.Employes.SingleOrDefault(b => b.rollno == rollno);
            
                if (result != null)
                {
                    result.firstname = employes.firstname;
                    result.lastname = employes.lastname;
                    result.gender = employes.gender;
                    result.phoneno = employes.phoneno;
                    result.mail = employes.mail;
                    result.password = employes.password;

                    _context.SaveChanges();


                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]  
        [Route("api/Employes/Delete/{rollno}")] 
         //To Delete the record of a particular employee    
        public int DeleteStudents(int rollno)  
        {  
            try  
            {  
              Employes emp = _context.Employes.Where(b => b.rollno == rollno).First();
                // Student emp = _context.Employes.Find(rollno);  
               _context.Employes.Remove(emp);  
                _context.SaveChanges();  
                // StudentImage ee =_context.StudentImages.Find(rollno);
                return 1;  
            }  
            catch  
            {  
                throw;  
            }  
        }  

        [HttpGet]
        [Route("api/[controller]/{rollno}")]
        public IActionResult GetById(int rollno)
        {
            var product = _context.Employes.Find(rollno);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

    }
}