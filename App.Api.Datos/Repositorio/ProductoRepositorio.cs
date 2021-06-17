using App.Api.Datos.Interface;
using App.Api.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Api.Datos.Repositorio
{
    public class ProductoRepositorio : RepositorioGenerico<Producto>, IProductoRepositorio
    {
        public ProductoRepositorio(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
