using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _06Publicaciones.config;

namespace _06Publicaciones.Views.Autores
{
    public partial class frm_Autores : Form
    {
        public frm_Autores()
        {
            InitializeComponent();
        }

        private void frm_Autores_Load(object sender, EventArgs e)
        {

        }
        private void ButtonInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                var autor = new Autor
                {
                    IdAutor = textBoxIdAutor.Text,
                    Apellido = textBoxApellido.Text,
                    Nombre = textBoxNombre.Text,
                    Telefono = textBoxTelefono.Text,
                    Direccion = textBoxDireccion.Text,
                    Ciudad = textBoxCiudad.Text,
                    Estado = textBoxEstado.Text,
                    CodigoPostal = textBoxCodigoPostal.Text
                };

                Autor.Insertar(autor);
                MessageBox.Show("Autor insertado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "Error al insertar el autor.");
            }
        }
        private void ButtonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxIdAutor.Clear();
            textBoxApellido.Clear();
            textBoxNombre.Clear();
            textBoxTelefono.Clear();
            textBoxDireccion.Clear();
            textBoxCiudad.Clear();
            textBoxEstado.Clear();
            textBoxCodigoPostal.Clear();
        }
    }
}
