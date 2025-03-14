using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using Parcial_1.Models;

namespace Parcial_1.Clases
{
    public class clsEmpleados
    {
        private ITM_VentasEntities context = new ITM_VentasEntities();

        public List<Computador> ConsultarTodos()
        {
            try
            {
                return context.Computador.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener computadores: " + ex.Message);
                return new List<Computador>();
            }
        }

        public Computador ConsultarUno(int id)
        {
            try
            {
                return context.Computador.FirstOrDefault(u => u.id_computador == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el computador: " + ex.Message);
                return null;
            }
        }

        public bool EliminarUno(int id)
        {
            try
            {
                var computador = context.Computador.FirstOrDefault(u => u.id_computador == id);
                if (computador == null) return false;
                
                context.Computador.Remove(computador);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar computador: " + ex.Message);
                return false;
            }
        }

        public Computador AgregarUno(Computador computador)
        {
            try
            {
                if (computador == null) return null;
                
                computador.id_computador = 0;
                context.Computador.Add(computador);
                context.SaveChanges();
                return computador;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar computador: " + ex.Message);
                return null;
            }
        }

        public Computador ActualizarUno(Computador computador)
        {
            try
            {
                if (computador == null || computador.id_computador <= 0) return null;
                
                var existente = context.Computador.FirstOrDefault(u => u.id_computador == computador.id_computador);
                if (existente == null) return null;
                
                context.Computador.AddOrUpdate(computador);
                context.SaveChanges();
                return computador;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar computador: " + ex.Message);
                return null;
            }
        }
    }
}