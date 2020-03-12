using Microsoft.EntityFrameworkCore;
using Parcial2_PA2.Data;
using Parcial2_PA2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Parcial2_PA2.Controller
{
    public class LlamadaController
    {
        public bool Guardar(Llamadas llamada)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                if (llamada.LlamadaId == 0)
                {
                    paso = Insertar(llamada);
                }
                else
                if (Buscar(llamada.LlamadaId)==null)
                {
                    paso = false;
                }
                else
                {
                    paso = Modificar(llamada);
                }
            }
            catch (Exception)
            {
                throw;
            }
           
            return paso;
        }
        

        private bool Insertar(Llamadas llamada)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Llamadas.Add(llamada);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        private bool Modificar(Llamadas llamada)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete From LlamadaDetalles where LlamadaId={llamada.LlamadaId}");

                foreach (var item in llamada.Detalles)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                contexto.Llamadas.Add(llamada);
                contexto.Entry(llamada).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Llamadas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Llamadas llamadas = new Llamadas();

            try
            {
                llamadas = contexto.Llamadas.Where(e => e.LlamadaId == id).Include(d => d.Detalles).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return llamadas;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            Llamadas llamadas = new Llamadas();
            bool paso = false;

            try
            {
                llamadas = contexto.Llamadas.Find(id);
                contexto.Entry(llamadas).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public List<Llamadas> GetList(Expression<Func<Llamadas, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Llamadas> list;

            try
            {
                list = contexto.Llamadas.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

    }
}
