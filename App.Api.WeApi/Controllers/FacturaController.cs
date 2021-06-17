using App.Api.Datos.Interface;
using App.Api.Dto.Dtos;
using App.Api.Model.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Api.WeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private IFacturaRepositorio _facturaRepositorio;
        private IMapper _mapp;

        public FacturaController(IFacturaRepositorio facturaRepositorio, IMapper mapper)
        {
            _facturaRepositorio = facturaRepositorio;
            this._mapp = mapper;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<FacturaDto>>> Get()
        {
            try
            {
                var facturas = await _facturaRepositorio.Get();
                return _mapp.Map<List<FacturaDto>>(facturas);
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
        public async Task<ActionResult<FacturaDto>> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var factura = await _facturaRepositorio.Find(Convert.ToString(id));
            if (factura == null)
            {
                return NotFound();
            }
            return _mapp.Map<FacturaDto>(factura);
        }

        // POST api/<ClienteController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FacturaDto>> Post([FromBody] FacturaDto FacturaDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var factura = _mapp.Map<Factura>(FacturaDto);
                    var newFactura = await _facturaRepositorio.Add(factura);
                    if (newFactura == null)
                    {
                        return BadRequest();
                    }
                    var newFacturaDto = _mapp.Map<FacturaDto>(newFactura);
                    return CreatedAtAction(nameof(Post), new { Id = newFacturaDto.Id }, newFacturaDto );
                }
                catch (Exception)
                {
                    return BadRequest();
                }

            }
            return BadRequest();
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FacturaDto>> Put(int id, [FromBody] FacturaDto FacturaDto)
        {

            try
            {
                var factura = _mapp.Map<Factura>(FacturaDto);
                var updateFactura = await _facturaRepositorio.Update(factura);
                if (!updateFactura)
                {
                    return BadRequest();
                }
                return _mapp.Map<FacturaDto>(factura);
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
                var result = await _facturaRepositorio.Delete(Convert.ToString(id));
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
