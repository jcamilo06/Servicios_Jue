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
    [RoutePrefix("api/Productos")]
    public class ProductosController : ApiController
    {
        // GET: Se utiliza para consultar información, no se debe modificar la base de datos
        // POST: Se utiliza para insertar información en la base de datos
        // PUT: Se utiliza para modificar (Actualizar) información en la base de datos
        // DELETE: Se utiliza para eliminar información en la base de datos

        [HttpGet] //Es el servicio que se va a exponer: GET, POST, PUT, DELETE
        [Route("ConsultarTodos")] //Es el nombre de la funcionalidad que se va a ejecutar
        public List<PRODucto> ConsultarTodos()
        {
            // Se crea una instancia de la clase clsProducto
            clsProducto Producto = new clsProducto();
            //Se invoca el método ConsultarTodos() de la clase clsProducto
            return Producto.ConsultarTodos();
        }
        [HttpGet]
        [Route("Consultar")]
        public PRODucto Consultar(int Codigo)
        {
            // Se crea una instancia de la clase clsProducto
            clsProducto Producto = new clsProducto();
            return Producto.Consultar(Codigo);
        }
        [HttpGet]
        [Route("ConsultarXCodigo")]
        public List<PRODucto> ConsultarXCodigo(int Codigo)
        {
            // Se crea una instancia de la clase clsProducto
            clsProducto Producto = new clsProducto();
            return Producto.ConsultarXCodigo(Codigo);
        }
        [HttpGet]
        [Route("ConsultarXTipoProducto")]
        public List<PRODucto> ConsultarXTipoProducto(int Tipo)
        {
            // Se crea una instancia de la clase clsProducto
            clsProducto Producto = new clsProducto();
            return Producto.ConsultarXTipoProducto(Tipo);
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] PRODucto producto)
        {
            // Se crea una instancia de la clase clsProducto
            clsProducto Producto = new clsProducto();
            // Se pasa la propiedad Producto al objeto de la clase clsProducto
            Producto.producto = producto;
            // Se invoca el método insertar
            return Producto.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] PRODucto producto)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = producto;
            return Producto.Actualizar();
        }
        [HttpPut]
        [Route("Inactivar")]
        public string Inactivar(int Codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.ModificarEstado(Codigo, false);
        }
        [HttpPut]
        [Route("Activar")]
        public string Activar(int Codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.ModificarEstado(Codigo, true);
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] PRODucto producto)
        {
            clsProducto Producto = new clsProducto();
            Producto.producto = producto;
            return Producto.Eliminar();
        }
        [HttpDelete]
        [Route("EliminarCodigo")]
        public string EliminarCodigo(int Codigo)
        {
            clsProducto Producto = new clsProducto();
            return Producto.Eliminar(Codigo);
        }
    }
}