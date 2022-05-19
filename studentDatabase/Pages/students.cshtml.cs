using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using studentDatabase.Pages;
using studentDatabase.Data;
using studentDatabase.Models;

namespace studentDatabase.Pages

{
    public class studentsModel : PageModel
    {
        public ApplicationDbContext _context { set; get; }

        public List<student> Allstudents { get; set; }
        [BindProperty]
        public student Newstudent{get; set;}
        public studentsModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            Allstudents = _context.students.ToList();
        }
        public void OnpostAddStudetn()
        {
            _context.students.Add(Newstudent);
            _context.SaveChanges();
            Allstudents = _context.students.ToList();
        }
    }
}
