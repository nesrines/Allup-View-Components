﻿using Allup.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace Allup.Controllers;
public class AboutController : Controller
{
    private readonly AppDbContext _context;
    public AboutController(AppDbContext context) { _context = context; }

    public async Task<IActionResult> Index()
    {
        return View();
    }
}