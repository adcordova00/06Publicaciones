using System;
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

        public void CargarAutores() {

            var listaAutores = Autor.ObtenerTodos();
            lst_autores.DataSource = null;
            lst_autores.DataSource = listaAutores;
            lst_autores.DisplayMember = "NombreCompleto";
            lst_autores.ValueMember = "IdAutor";
        }

        private void frm_Autores_Load(object sender, EventArgs e)
        {
            CargarAutores();
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

                var insertado = Autor.Insertar(autor);
                if (insertado != null)
                {
                    ErrorHandler.ManejarInsertar();
                }
                else {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "");
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

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
