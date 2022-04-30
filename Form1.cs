using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        CN_Productos objetoCN = new();
        private string idProducto;
        private bool Editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerProds();
        }

        private void LeerProds()
        {
            CN_Productos objeto = new();
            dataGridView1.DataSource = objeto.LeerProd();
        }


        private void LimpiarForm()
        {

            txtProd.Clear();
            txtDesc.Clear();
            txtPrec.Clear();
            txtExis.Clear();
            txtProd.Clear();
            txtEsta.Clear();
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            { //Insertar
                if (Editar == false)
                {
                    try
                    {
                        objetoCN.InsProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text);
                        MessageBox.Show("Registro insertar exitosamente");
                        LeerProds();
                        LimpiarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Registro no pudo ser insertado, el motivo es:" + ex);
                    }
                }

                //Editar
                if (Editar == true)
                {
                    try
                    {
                        objetoCN.ActProd(txtProd.Text, txtDesc.Text, txtPrec.Text, txtExis.Text, txtEsta.Text, idProducto);
                        MessageBox.Show("Registro actualizado exitosamente");
                        LeerProds();
                        LimpiarForm();
                        Editar = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("registro no pudo ser actualizado, el motivo es:" + ex);
                    }

                }
            }
        }

        private void BtnEditarClick(object sender, EventArgs e)
        {
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Editar = true;
                    txtProd.Text = dataGridView1.CurrentRow.Cells["nomProd"].Value.ToString();
                    txtDesc.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();
                    txtPrec.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                    txtExis.Text = dataGridView1.CurrentRow.Cells["cantidad"].Value.ToString();
                    txtEsta.Text = dataGridView1.CurrentRow.Cells["estado"].Value.ToString();
                    idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                }
                else
                    MessageBox.Show("favor selecionar una fila");
            }
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            {

                if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["idProducto"].Value.ToString();
                objetoCN.EliProd(idProducto);
                MessageBox.Show("Eliminado correctamente");
                LeerProds();
            }
            else
                MessageBox.Show("seleccione una fila por favor");
        }
    }

    private void BtnCerrar_Click (object sender, EventArgs e)
    {
        Close();

    }

    }
}


