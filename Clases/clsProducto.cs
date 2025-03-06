using Servicios_Jue.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_Jue.Clases
{
    public class clsProducto
    {
        private DBSuperEntities dbsuper = new DBSuperEntities(); // Es el atributo (propiedad) para gestionar la conexión a la base de datos
        public PRODucto producto { get; set; }
        public string Insertar()
        {
            try
            {
                dbsuper.PRODuctoes.Add(producto); // Agrega el objeto empleado a la lista de productos. Todavía no se agrega a la base de datos. Se debe invocar el método saveChanges
                dbsuper.SaveChanges();
                return "Producto insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el producto: " + ex.Message;
            }

        }
        public string Actualizar()
        {
            try
            {
                // Antes de actualizar un elemento, se debe consultar para verificar que exista, y ahí si poderlo actualizar
                PRODucto prod = Consultar(producto.Codigo);
                if (prod == null)
                {
                    return "El producto con el código ingresado no existe, por lo tanto no se puede actualizar";
                }
                // 
                dbsuper.PRODuctoes.AddOrUpdate(producto); //Actualiza el objeto empleado en la lista de empleadoes. Todavía no se actualiza en la base de datos
                dbsuper.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se actualizó correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo actualizar el producto: " + ex.Message;
            }

        }
        public List<PRODucto> ConsultarTodos()
        {
            return dbsuper.PRODuctoes
                    .OrderBy(p => p.Nombre) //OrderBy() es una función que permite ordenar los elementos de una lista de acuerdo a un criterior específico
                    .ToList(); //ToList() es una función que convierte una lista de datos en una lista de objetos
        }
        public List<PRODucto> ConsultarXCodigo(int Cod)
        {
            return dbsuper.PRODuctoes
                .Where(p => p.Codigo == Cod)
                .OrderBy(p => p.Nombre) //OrderBy() es una función que permite ordenar los elementos de una lista de acuerdo a un criterior específico
                .ToList(); //ToList() es una función que convierte una lista de datos en una lista de objetos
        }
        public List<PRODucto> ConsultarXTipoProducto(int Cod)
        {
            return dbsuper.PRODuctoes
                .Where(p => p.CodigoTipoProducto == Cod)
                .OrderBy(p => p.Nombre) //OrderBy() es una función que permite ordenar los elementos de una lista de acuerdo a un criterior específico
                .ToList(); //ToList() es una función que convierte una lista de datos en una lista de objetos
        }
        public PRODucto Consultar(int Codigo)
        {
            //Expresiones lambda. => permite definir funciones anónimas o instancias de objetos, sin la creación formal, dependiendo de la lista a la cual se hace referencia
            //FirsOrDefault. Es una función que permite consultar el primer elemento de una lista que cumple las condiciones solicitadas
            return dbsuper.PRODuctoes.FirstOrDefault(p => p.Codigo == Codigo);

        }

        public string Eliminar()
        {
            try
            {
                //Antes de eliminar se debe verificar si el empleado existe
                PRODucto prod = Consultar(producto.Codigo);
                if (prod == null)
                {
                    return "El producto con el código ingresado no existe, por lo tanto no se puede actualizar";
                }
                //El empleado existe lo podemos eliminar. Se elimina el objeto empleado que se busca, no el que se envía como parámetro
                dbsuper.PRODuctoes.Remove(prod); // Eliminar el objeto empleado de la lista de empleadoes. Todavía no se elimina de la base de datos. Se debe invocar el guardar cambios 
                dbsuper.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se eliminó el producto correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el producto: " + ex.Message;
            }

        }
        public string Eliminar(int Codigo)
        {
            try
            {
                //Antes de eliminar se debe verificar si el empleado existe
                PRODucto prod = Consultar(Codigo);
                if (prod == null)
                {
                    return "El producto con el código ingresado no existe, por lo tanto no se puede actualizar";
                }
                //El empleado existe lo podemos eliminar. Se elimina el objeto empleado que se busca, no el que se envía como parámetro
                dbsuper.PRODuctoes.Remove(prod); // Eliminar el objeto empleado de la lista de empleadoes. Todavía no se elimina de la base de datos. Se debe invocar el guardar cambios 
                dbsuper.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se eliminó el producto correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el producto: " + ex.Message;
            }
        }
        public string ModificarEstado(int Codigo, bool Activo)
        {
            try
            {
                PRODucto prod = Consultar(Codigo);
                if (prod == null)
                {
                    return "El codigo del producto no existe en la base de datos";
                }
                prod.Activo = Activo;
                dbsuper.SaveChanges();
                if (Activo)
                {
                    return "Se activó correctamente el producto";
                }
                else
                {
                    return "Se desactivó correctamente el producto";
                }
            }
            catch (Exception ex)
            {
                return "Hubo un error al modificar el estado del producto: " + ex.Message;
            }
        }
    }
}