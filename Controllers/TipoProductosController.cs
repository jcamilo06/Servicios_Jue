using Servicios_Jue.Clases;
using Servicios_Jue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicios_Jue.Controllers
{
    [RoutePrefix("api/TipoProductos")]
    public class TipoProductosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<TIpoPRoducto> ConsultarTodos()
        {
            clsTipoProducto TipoProducto = new clsTipoProducto();
            return TipoProducto.ConsultarTodos();
        }
        [HttpGet]
        [Route("Consultar")]
        public TIpoPRoducto Consultar(int Codigo)
        {
            clsTipoProducto TipoProducto = new clsTipoProducto();
            return TipoProducto.Consultar(Codigo);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] TIpoPRoducto tipoProducto)
        {
            clsTipoProducto TipoProducto = new clsTipoProducto();
            TipoProducto.tipoProducto = tipoProducto;
            return TipoProducto.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] TIpoPRoducto tipoProducto)
        {
            clsTipoProducto TipoProducto = new clsTipoProducto();
            TipoProducto.tipoProducto = tipoProducto;
            return TipoProducto.Actualizar();
        }
        [HttpPut]
        [Route("Inactivar")]
        public string Inactivar(int Codigo)
        {
            clsTipoProducto TipoProducto = new clsTipoProducto();
            return TipoProducto.ModificarActivo(Codigo, false);
        }
        [HttpPut]
        [Route("Activar")]
        public string Activar(int Codigo)
        {
            clsTipoProducto TipoProducto = new clsTipoProducto();
            return TipoProducto.ModificarActivo(Codigo, true);
        }
        /*
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] TIpoPRoducto tipoProducto)
        {
            clsTipoProducto TipoProducto = new clsTipoProducto();
            Producto.producto = producto;
            return Producto.Eliminar();
        }
        [HttpDelete]
        [Route("EliminarCodigo")]
        public string EliminarCodigo(int Codigo)
        {
            clsTipoProducto TipoProducto = new clsTipoProducto();
            return Producto.Eliminar(Codigo);
        }
        */
    }
}