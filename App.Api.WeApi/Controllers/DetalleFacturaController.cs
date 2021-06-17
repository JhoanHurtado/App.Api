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
    public class DetalleFacturaController : ControllerBase
    {
        private IDetalleFacturaRepositorio _detalleFacturaRepositorio;
        private IMapper _mapp;

        public DetalleFacturaController(IDetalleFacturaRepositorio detalleFacturaRepositorio, IMapper mapper)
        {
            _detalleFacturaRepositorio = detalleFacturaRepositorio;
            this._mapp = mapper;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleFacturaDto>>> Get()
        {
            try
            {
                var facturasDetalle = await _detalleFacturaRepositorio.Get();
                return _mapp.Map<List<DetalleFacturaDto>>(facturasDetalle);
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
        public async Task<ActionResult<DetalleFacturaDto>> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var facturaDetalles = await _detalleFacturaRepositorio.Find(Convert.ToString(id));
            if (facturaDetalles == null)
            {
                return NotFound();
            }
            return _mapp.Map<DetalleFacturaDto>(facturaDetalles);
        }

        // POST api/<ClienteController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleFacturaDto>> Post([FromBody] DetalleFacturaDto DetalleFacturaDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var facturaDetalle = _mapp.Map<DetalleFactura>(DetalleFacturaDto);
                    var newFacturaDetalle = await _detalleFacturaRepositorio.Add(facturaDetalle);
                    if (newFacturaDetalle == null)
                    {
                        return BadRequest();
                    }
                    var newDetalleFacturaDto = _mapp.Map<DetalleFacturaDto>(newFacturaDetalle);
                    return CreatedAtAction(nameof(Post), new { Id = newDetalleFacturaDto.Id }, newDetalleFacturaDto );
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
        public async Task<ActionResult<DetalleFacturaDto>> Put(int id, [FromBody] DetalleFacturaDto DetalleFacturaDto)
        {

            try
            {
                var facturaDetalle = _mapp.Map<DetalleFactura>(DetalleFacturaDto);
                var updateFacturaDetalle = await _detalleFacturaRepositorio.Update(facturaDetalle);
                if (!updateFacturaDetalle)
                {
                    return BadRequest();
                }
                return _mapp.Map<DetalleFacturaDto>(facturaDetalle);
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
                var result = await _detalleFacturaRepositorio.Delete(Convert.ToString(id));
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
