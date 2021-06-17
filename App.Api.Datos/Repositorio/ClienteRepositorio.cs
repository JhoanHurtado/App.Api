using App.Api.Datos.Interface;
using App.Api.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace App.Api.Datos.Repositorio
{
    public class ClienteRepositorio : RepositorioGenerico<Cliente>, IClienteRepositorio
    {
        private AppDbContext _dbContext;

        public ClienteRepositorio(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new async Task<bool> Delete(string id)
        {
            var cliente =   _dbContext.Clientes.Find(id);
            cliente.Estado = Model.Enums.EstadoEnum.Inactivo;
            _dbContext.Entry(cliente).State = EntityState.Modified;
            try
            {
                return  await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
