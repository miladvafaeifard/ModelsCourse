using System;
using JurisTempus.Data.Entities;

namespace JurisTempus.ViewModels
{
  public class ClientViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactName { get; set; }
    public string Phone { get; set; }
  }
}
