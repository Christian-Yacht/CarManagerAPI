﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APIassignment2.Domein;
using APIassignment2.Models;

namespace MVC_API.Controllers
{
    public class CarsController : Controller
    {

        private readonly Assignment2_DbContext _context;

        public CarsController(Assignment2_DbContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var assignment2_DbContext = _context.Cars.Include(c => c.CarCompany).Include(c => c.CarUser);
            return View(await assignment2_DbContext.ToListAsync());
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.CarCompany)
                .Include(c => c.CarUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }
        
        public IActionResult UnAssignTheUser(string userName)
        {
            var user = _context.Cars.Where(a => a.CarUser.UserName == userName).FirstOrDefaultAsync();
            ViewData["user"] = user;
            return View();
        }
        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewData["CarCompanyName"] = new SelectList(_context.Companies, "Name", "Name");
            ViewData["CarUserUserName"] = new SelectList(_context.Users, "UserName", "UserName");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Make,Model,Description,Range,MileAge,CarCompanyName,CarUserUserName")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarCompanyName"] = new SelectList(_context.Companies, "Name", "Name", car.CarCompanyName);
            ViewData["CarUserUserName"] = new SelectList(_context.Users, "UserName", "UserName", car.CarUserUserName);
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["CarCompanyName"] = new SelectList(_context.Companies, "Name", "Name", car.CarCompanyName);
            ViewData["CarUserUserName"] = new SelectList(_context.Users, "UserName", "UserName", car.CarUserUserName);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Description,Range,MileAge,CarCompanyName,CarUserUserName")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarCompanyName"] = new SelectList(_context.Companies, "Name", "Name", car.CarCompanyName);
            ViewData["CarUserUserName"] = new SelectList(_context.Users, "UserName", "UserName", car.CarUserUserName);
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .Include(c => c.CarCompany)
                .Include(c => c.CarUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
