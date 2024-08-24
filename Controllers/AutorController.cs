using System;
using System.Collections.Generic;
using System.Windows.Forms;
using _06Publicaciones.config;

namespace _06Publicaciones.Controllers
{
    public class AutorController
    {
        // Método para insertar un autor
        public void InsertarAutor(Autor autor)
        {
            try
            {
                Autor autorInsertado = Autor.Insertar(autor);
                if (autorInsertado != null)
                {
                    MessageBox.Show("Autor insertado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo insertar el autor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al insertar el autor.");
            }
        }

        // Método para actualizar un autor
        public void ActualizarAutor(Autor autor)
        {
            try
            {
                string resultado = Autor.Actualizar(autor);
                if (resultado == "OK")
                {
                    MessageBox.Show("Autor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el autor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al actualizar el autor.");
            }
        }

        // Método para eliminar un autor
        public void EliminarAutor(string idAutor)
        {
            try
            {
                string resultado = Autor.Eliminar(idAutor);
                if (resultado == "OK")
                {
                    MessageBox.Show("Autor eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el autor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al eliminar el autor.");
            }
        }

        // Método para obtener un autor por ID
        public Autor ObtenerAutorPorId(string idAutor)
        {
            try
            {
                return Autor.ObtenerPorId(idAutor);
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener el autor.");
                return null;
            }
        }

        // Método para obtener todos los autores (esto requiere que se agregue un método en la clase Autor)
        public List<Autor> ObtenerTodosLosAutores()
        {
            try
            {
                return Autor.ObtenerTodos();
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al obtener los autores.");
                return new List<Autor>();
            }
        }
    }
}
