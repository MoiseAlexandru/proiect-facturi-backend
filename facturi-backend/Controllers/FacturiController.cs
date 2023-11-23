﻿using facturi_backend.Models.DTOs;
using facturi_backend.Services.DetaliiFacturaService;
using facturi_backend.Services.FacturaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace facturi_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturiController : ControllerBase
    {
        private readonly IFacturaService _facturaService;
        public FacturiController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _facturaService.GetFacturaById(id);
            if(result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var facturi = await _facturaService.GetAll();
            if (facturi == null)
                return NotFound();
            return Ok(facturi);
        }


        [HttpPost]
        public IActionResult CreateFactura([FromBody] FacturaReceiveDTO factura)
        {
            _facturaService.AddFactura(factura);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFactura(int id, [FromBody] FacturaReceiveDTO payload)
        {
            if(_facturaService.GetFacturaById == null)
                return NotFound(id);
            _facturaService.UpdateFacturaById(id, payload);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFactura(int id)
        {
            if (_facturaService.GetFacturaById == null)
                return NotFound();
            _facturaService.DeleteFacturaById(id);
            return Ok();
        }
    }
}