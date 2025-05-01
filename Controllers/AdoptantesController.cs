using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using practica2.Data;
 using practica2.Models;
 

namespace practica2.Controllers
{
   public class AdoptantesController : Controller
     {
         private readonly ILogger<AdoptantesController> _logger;
         private readonly ApplicationDbContext _context;
         public AdoptantesController(ILogger<AdoptantesController> logger, ApplicationDbContext context)
         {
             _logger = logger;
             _context = context;
         }
 
         // GET: Adoptantes
         public IActionResult Index()
         {
             var adoptantes = _context.Adoptantes.ToList();
             return View(adoptantes);
         }
 
         // GET: Adoptantes/Create
         public IActionResult Create()
         {
             return View();
         }
 
         // POST: Adoptantes/Create
         [HttpPost]
         [ValidateAntiForgeryToken]
         public IActionResult Create(Adoptante adoptante)
         {
             if (ModelState.IsValid)
             {
                 _context.Adoptantes.Add(adoptante);
                 _context.SaveChanges();
                 TempData["SuccessMessage"] = "✅ Adoptante registrado exitosamente.";
                 return RedirectToAction(nameof(Index));
             }
             return View(adoptante);
         }
 
         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
         public IActionResult Error()
         {
             return View("Error!");
         }
     }
}