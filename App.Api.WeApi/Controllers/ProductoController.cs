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
    public class ProductoController : ControllerBase
    {
            private IProductoRepositorio _productoRepositorio;
            private IMapper _mapp;

            public ProductoController(IProductoRepositorio productoRepositorio, IMapper mapper)
            {
                _productoRepositorio = productoRepositorio;
                this._mapp = mapper;
            }

        // GET: api/<ClienteController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> Get()
        {
            try
            {
                var productos = await _productoRepositorio.Get();
                return _mapp.Map<List<ProductoDto>>(productos);
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
        public async Task<ActionResult<ProductoDto>> Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var producto = await _productoRepositorio.Find(Convert.ToString(id));
            if (producto == null)
            {
                return NotFound();
            }
            return _mapp.Map<ProductoDto>(producto);
        }

        // POST api/<ClienteController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoDto>> Post([FromBody] ProductoDto ProductoDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var producto = _mapp.Map<Producto>(ProductoDto);
                    var newProducto = await _productoRepositorio.Add(producto);
                    if (newProducto == null)
                    {
                        return BadRequest();
                    }
                    var newProductoDto = _mapp.Map<ProductoDto>(newProducto);
                    return CreatedAtAction(nameof(Post), new { Id = newProductoDto.Id }, newProductoDto );
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
        public async Task<ActionResult<ProductoDto>> Put(int id, [FromBody] ProductoDto ProductoDto)
        {

            try
            {
                var producto = _mapp.Map<Producto>(ProductoDto);
                var updateProducto = await _productoRepositorio.Update(producto);
                if (!updateProducto)
                {
                    return BadRequest();
                }
                return _mapp.Map<ProductoDto>(producto);
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
                    var result = await _productoRepositorio.Delete(Convert.ToString(id));
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
