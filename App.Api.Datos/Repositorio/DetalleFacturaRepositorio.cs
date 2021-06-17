using App.Api.Datos.Interface;
using App.Api.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Api.Datos.Repositorio
{
    public class DetalleFacturaRepositorio : RepositorioGenerico<DetalleFactura>, IDetalleFacturaRepositorio
    {
        public DetalleFacturaRepositorio(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
