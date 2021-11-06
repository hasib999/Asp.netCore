using FirstAppAspDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FirstAppAspDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Student student = new Student();
            student.Id = 17345522;
            student.Name = "Hasib";
            student.Email = "Hasib@gmail.com";
            student.Address = "Dhaka";
            student.FatherName = "Zahir";
            ViewBag.Student =student ;
            return View();
        }

        public string Hello(string name)
        {
            return "Hello Asp.Net Core"+name;
        }

        public string Admission(Student student)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-RCC9LDC;Initial Catalog=Student;Integrated Security=True");
            con.Open();
            string query = "Insert INTO Student(id,name,address,email,father_name) VALUES('"+student.Id +"','"+ student.Name + "','"+student.Address+"','"+student.Email+"','"+student.FatherName+"')";
            SqlCommand cmd = new SqlCommand(query,con);
            int rowCount = cmd.ExecuteNonQuery();
            if(rowCount>0)
            {
                return "Data Saved";
            }
            return "Not Saved";
            //return "Name "+student.Name+ "Address"+student.Address+ "Email"+student.Email+"Father Name"+student.FatherName;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
