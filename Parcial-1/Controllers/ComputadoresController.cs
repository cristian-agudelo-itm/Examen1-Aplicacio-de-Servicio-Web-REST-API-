using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Parcial_1.Models;
using Parcial_1.Clases;

namespace Parcial_1.Controllers
{
    [RoutePrefix("api/Computadores")]
    public class ComputadoresController : ApiController
    {
        private clsEmpleados servicioComputador = new clsEmpleados();

        [HttpGet]
        [Route("consultar")]
        public IHttpActionResult Consultar()
        {
            var computadores = servicioComputador.ConsultarTodos();
            if (computadores == null || !computadores.Any())
                return NotFound();
            return Ok(computadores);
        }

        [HttpGet]
        [Route("consultar/{id}")]
        public IHttpActionResult Consultar(int id)
        {
            var computador = servicioComputador.ConsultarUno(id);
            if (computador == null)
                return NotFound();
            return Ok(computador);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IHttpActionResult Eliminar(int id)
        {
            var resultado = servicioComputador.EliminarUno(id);
            if (!resultado)
                return NotFound();
            return Ok("Computador eliminado correctamente.");
        }

        [HttpPost]
        [Route("agregar")]
        public IHttpActionResult Agregar([FromBody] Computador computador)
        {
            if (computador == null)
                return BadRequest("Los datos del computador no pueden ser nulos.");

            var resultado = servicioComputador.AgregarUno(computador);
            if (resultado == null)
                return InternalServerError();
            return Created("api/Computadores/consultar/" + resultado.id_computador, resultado);
        }

        [HttpPut]
        [Route("actualizar")]
        public IHttpActionResult Actualizar([FromBody] Computador computador)
        {
            if (computador == null || computador.id_computador <= 0)
                return BadRequest("Datos de entrada inválidos.");

            var resultado = servicioComputador.ActualizarUno(computador);
            if (resultado == null)
                return NotFound();
            return Ok(resultado);
        }
    }
}
