using System;
using System.Collections.Generic;

namespace JurisTempus.ViewModels
{
  public class ClientViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactName { get; set; }
    public string Phone { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string CityTown { get; set; }
    public string StateProvince { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    public ICollection<CaseViewModel> Cases { get; set; }
  }
}
