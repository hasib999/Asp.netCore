﻿using FirstAppAspDotNetCore.Models;
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
        [HttpGet]
        public ActionResult Admission()
        {
            return View();
        }
        [HttpPost]
        public string Admission(Student student)
        {
            string msgs="";
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-RCC9LDC;Initial Catalog=Student;Integrated Security=True");
            con.Open();
            string query = "Insert INTO Student(id,name,address,email,father_name) VALUES('"+student.Id +"','"+ student.Name + "','"+student.Address+"','"+student.Email+"','"+student.FatherName+"')";
            SqlCommand cmd = new SqlCommand(query,con);
            int rowCount = cmd.ExecuteNonQuery();
            if(rowCount>0)
            {
                msgs = "Data Saved";
            }
            else
            {
                msgs = "Not Saved";
            }
            return ViewBag.Message = msgs;
            //return View();
            //return "Name "+student.Name+ "Address"+student.Address+ "Email"+student.Email+"Father Name"+student.FatherName;
        }

        public ActionResult GetAll()
        {
            //ViewBag.Students = Studentss();
            return View(Studentss());
        }
        public List<Student>Studentss()
        {
            return new List<Student>
            {
                new Student { Name = "Hasib Shanto",RegNo = "2017",Email="hasib@gmail.com",Address="Dhaka"},
                new Student { Name = "Fahad",RegNo = "2018",Email="fahad@gmail.com",Address="Dhaka"}
        };
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
