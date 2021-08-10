using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JurisTempus.Data;
using Microsoft.EntityFrameworkCore;
using JurisTempus.ViewModels;
using AutoMapper;
using JurisTempus.Data.Entities;

namespace JurisTempus.Controllers
{
  public class HomeController : Controller
 {
    private readonly ILogger<HomeController> _logger;
    private readonly BillingContext _context;
    private readonly IMapper _mapper;



    public HomeController(ILogger<HomeController> logger, BillingContext context, IMapper mapper)
    {
      _logger = logger;
      _context = context;
      _mapper = mapper;
    }

    public IActionResult Index()
    {
      var result = _context.Clients
        .Include(c => c.Address)
        .Include(c => c.Cases)
        .ToArray();
      var vms = _mapper.Map<ClientViewModel[]>(result);

      return View(vms);
    }

    [HttpGet("editor/{id:int}")]
    public async Task<IActionResult> ClientEditor(int id)
    {
      var result = await _context.Clients
        .Include(c => c.Address)
        .Where(c => c.Id == id)
        .FirstOrDefaultAsync();

      return View(_mapper.Map<ClientViewModel>(result));
    }

    [HttpPost("editor/{id:int}")]
    public async Task<IActionResult> ClientEditor(int id, ClientViewModel clientViewModel)
    {
      if (ModelState.IsValid)
      {
        var client = await _context.Clients
          .Include(c => c.Address)
          .Where(c => c.Id == id)
          .FirstOrDefaultAsync();

        if (client != null)
        {
          // Update the database
          _mapper.Map(clientViewModel, client);
          if (await _context.SaveChangesAsync() > 0)
          {
            return RedirectToAction("Index");
          }
        }
      }
      else
      {
        // Create a new one
        var newClient = _mapper.Map<Client>(clientViewModel);
        _context.Add(newClient);

        if (await _context.SaveChangesAsync() > 0)
        {
          return RedirectToAction("Index");
        }
      }

      return View();
    }

    [HttpGet("timesheet")]
    public IActionResult Timesheet()
    {
      return View();
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
