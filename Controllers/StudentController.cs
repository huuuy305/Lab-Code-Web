using Lap1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;


namespace Lap1.Controllers
{
     [Route("abc/def")]
    [Route("Admin/Student")]
    public class StudentController : Controller
    {

        private List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            listStudents = new List<Student>(){
                new Student() {Id = 1, Name = "Khanh Lai", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "Hà Nội", Email = "lai@gmail.com"},
                new Student() {Id = 2, Name = "Hải Nam", Branch = Branch.CE, Gender = Gender.Male, IsRegular = true, Address = "A1-2018", Email = "nam@gmail.com"},
                new Student() {Id = 3, Name = "Thanh Tú", Branch = Branch.BE, Gender = Gender.Female, IsRegular = false, Address = "A2-2018", Email = "tu@gmail.com"},
                new Student() {Id = 4, Name = "Ngọc Long", Branch = Branch.IT, Gender = Gender.Male, IsRegular = false, Address = "A3-2018", Email = "long@gmail.com"},
            };
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet("Add")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>() {
                new SelectListItem() {Text = "IT", Value = "1"},
                new SelectListItem() {Text = "BE", Value = "2"},
                new SelectListItem() {Text = "CE", Value = "3"},
                new SelectListItem() {Text = "EE", Value = "4"}
            };
            return View();
        }

        [HttpPost("Add")]
        public IActionResult Create(Student student)
        {

            if (ModelState.IsValid)
            {
                student.Id = listStudents.Count > 0 ? listStudents.Max(s => s.Id) + 1 : 1;
                listStudents.Add(student);
                return View("Index", listStudents);
            }
            return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
