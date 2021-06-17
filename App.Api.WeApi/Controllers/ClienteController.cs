using App.Api.Datos.Interface;
using App.Api.Dto.Dtos;
using App.Api.Model.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Api.WeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepositorio _clienteRepositorio;
        private IMapper _mapp;

        public ClienteController(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            this._mapp = mapper;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
        {
            try
            {
                var clientes = await _clienteRepositorio.Get();                
                return _mapp.Map<List<ClienteDto>>(clientes.FindAll(e => e.Estado == Model.Enums.EstadoEnum.Activo));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var cliente = await _clienteRepositorio.Find(Convert.ToString(id));
            if (cliente == null)
            {
                return NotFound();
            }
            return _mapp.Map<ClienteDto>(cliente);
        }

        // POST api/<ClienteController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Post([FromBody]ClienteDto clienteDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cliente = _mapp.Map<Cliente>(clienteDto);
                    var newCliente = await _clienteRepositorio.Add(cliente);
                    if (newCliente == null)
                    {
                        return BadRequest();
                    }
                    var newClientDto = _mapp.Map<ClienteDto>(newCliente);
                    return CreatedAtAction(nameof(Post), new { Identificador = newClientDto.Identificador}, newClientDto );
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }

        // PUT api/<ClienteController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Put([FromBody]ClienteDto clienteDto)
        {

            try
            {
                var cliente = _mapp.Map<Cliente>(clienteDto);
                var updateCliente = await _clienteRepositorio.Update(cliente);
                if (!updateCliente)
                {
                    return BadRequest();
                }
                return _mapp.Map<ClienteDto>(cliente);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _clienteRepositorio.Delete(Convert.ToString(id));
                if (!result)
                {
                    return BadRequest();
                }
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
