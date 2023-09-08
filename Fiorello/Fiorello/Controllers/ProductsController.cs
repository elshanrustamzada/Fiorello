﻿using Fiorello.DAL;
using Fiorello.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiorello.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _db;
        public ProductsController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _db.Products.ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
                return NotFound();
            Product product = await _db.Products.Include(x=>x.ProductDetail).FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                return BadRequest();
            return View(product);
        }
    }
}
