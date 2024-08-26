using _06Publicaciones.config;
using _06Publicaciones.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06Publicaciones.Views.Tiendas
{
    public partial class frm_tiendas : Form
    {
        public frm_tiendas()
        {
            InitializeComponent();
        }

        private bool ValidarTextBox(params TextBox[] cajadetexto)
        {
            foreach (var caja in cajadetexto)
            {
                if (string.IsNullOrWhiteSpace(caja.Text))
                {
                    ErrorHandler.ManejarErrorGeneral(null, "Complete la informacion");
                    return false;
                }
            }
            return true;
        }

        private void LimpiarForm()
        {
            txt_id_tienda.Clear();
            txt_nombre_tienda.Clear();
            txt_ciudad_tienda.Clear();
            txt_estado_tienda.Clear();
            txt_direccion_tienda.Clear();
            txt_cpostal_tienda.Clear();
        }

        public void CargaTiendas()
        {
            var listaTiendas = Tienda.ListTiendas();
            lst_Tiendas.DataSource = null;
            lst_Tiendas.DataSource = listaTiendas;
            lst_Tiendas.DisplayMember = "NombreTienda";
            lst_Tiendas.ValueMember = "IdTienda";
        }

        private void frm_tiendas_Load(object sender, EventArgs e)
        {
            CargaTiendas();
        }

        private void btn_guardar_tienda_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarTextBox(txt_id_tienda, txt_nombre_tienda, txt_direccion_tienda, txt_ciudad_tienda, txt_estado_tienda, txt_cpostal_tienda))
                {
                    return;
                }

                var tienda = new Tienda
                {
                    IdTienda = txt_id_tienda.Text,
                    NombreTienda = txt_nombre_tienda.Text,
                    Direccion = txt_direccion_tienda.Text,
                    Ciudad = txt_ciudad_tienda.Text,
                    Estado = txt_estado_tienda.Text,
                    CodigoPostal = txt_cpostal_tienda.Text,
                };

                var tienda_guardada = Tienda.InsertarTienda(tienda);
                if (tienda_guardada != null)
                {
                    ErrorHandler.ManejarInsertar();
                }
                else
                {
                    CargaTiendas();
                    LimpiarForm();
                    MessageBox.Show("Se guardo la tienda con exito");
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ManejarErrorGeneral(ex, "");
            }

        }

        private void btn_limpiar_tienda_Click(object sender, EventArgs e)
        {
            LimpiarForm();
        }
    }
}
