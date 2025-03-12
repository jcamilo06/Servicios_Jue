using Servicios_Jue.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_Jue.Clases
{
    public class clsTipoProducto
    {
        private DBSuperEntities dbSuper = new DBSuperEntities();
        public TIpoPRoducto tipoProducto { get; set; }
        public List<TIpoPRoducto> ConsultarTodos()
        {
            return dbSuper.TIpoPRoductoes.ToList();
        }
        public TIpoPRoducto Consultar(int Codigo)
        {
            return dbSuper.TIpoPRoductoes.Where(x => x.Codigo == Codigo).FirstOrDefault();
        }
        public string Insertar()
        {
            try
            {
                dbSuper.TIpoPRoductoes.Add(tipoProducto); // Agrega el objeto empleado a la lista de productos. Todavía no se agrega a la base de datos. Se debe invocar el método saveChanges
                dbSuper.SaveChanges();
                return "Tipo de producto insertado correctamente";
            }
            catch(Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                TIpoPRoducto tipoProd = Consultar(tipoProducto.Codigo);
                if (tipoProd == null)
                {
                    return "El tipo producto no existe en la base de datos";
                }
                tipoProd.Nombre = tipoProducto.Nombre;
                tipoProd.Nombre = tipoProducto.Nombre;
                dbSuper.SaveChanges();
                return "Tipo de producto actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}