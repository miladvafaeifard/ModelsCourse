using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JurisTempus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JurisTempus
{
  public class ContactModel : PageModel
  {
    public void OnGet()
    {

    }

    [BindProperty]
    public ContactViewModel ViewModel { get; set; }

    public void OnPost ()
    {
      if (ModelState.IsValid)
      {
        return;
      }
    }
  }
}
