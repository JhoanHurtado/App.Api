using App.Api.Datos.Interface;
using App.Api.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Api.Datos.Repositorio
{
    public class FacturaRepositorio : RepositorioGenerico<Factura>, IFacturaRepositorio
    {
        public FacturaRepositorio(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
