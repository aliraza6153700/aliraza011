using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AliRaza011.Data;
using AliRaza011.Models;

namespace AliRaza011.Controllers
{
    public class ordermodelsController : Controller
    {
        private readonly storedbContext _context;

        public ordermodelsController(storedbContext context)
        {
            _context = context;
        }

        // GET: ordermodels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ordermodel.ToListAsync());
        }

        // GET: ordermodels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordermodel = await _context.ordermodel
                .FirstOrDefaultAsync(m => m.id == id);
            if (ordermodel == null)
            {
                return NotFound();
            }

            ViewBag.Total = ordermodel.dis_quantity * ordermodel.price;
            return View(ordermodel);
        }

        // GET: ordermodels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ordermodels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,dis_quantity,price")] ordermodel ordermodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordermodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordermodel);
        }


      

        // GET: ordermodels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordermodel = await _context.ordermodel
                .FirstOrDefaultAsync(m => m.id == id);
            if (ordermodel == null)
            {
                return NotFound();
            }

            return View(ordermodel);
        }

        // POST: ordermodels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordermodel = await _context.ordermodel.FindAsync(id);
            _context.ordermodel.Remove(ordermodel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ordermodelExists(int id)
        {
            return _context.ordermodel.Any(e => e.id == id);
        }
    }
}
