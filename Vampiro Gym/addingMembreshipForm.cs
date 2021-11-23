﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vampiro_Gym
{
    public partial class addingMembreshipForm : Form
    {
        public static string tipoMembresia;
        public static string duracionMembresia;
        public static string costo;
        public static bool validado;
        private string ventanaTipo;
        public addingMembreshipForm(string tipo)
        {
            InitializeComponent();
            this.ventanaTipo = tipo;
        }

        private void tipoMembresiaText_Enter(object sender, EventArgs e)
        {
            if (tipoMembresiaText.Text.Contains("Tipo de membresia: "))
                tipoMembresiaText.Text = "";
        }

        private void duracionText_Enter(object sender, EventArgs e)
        {
            if (duracionText.Text.Contains("Ingrese duracion en días"))
                duracionText.Text = "";
        }

        private void costoText_Enter(object sender, EventArgs e)
        {
            if (costoText.Text.Contains("Ingrese costo"))
                costoText.Text = "";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Esto se debe de reemplazar por el guardado de informacion en la base de datos
            if (!tipoMembresiaText.Text.Contains("Tipo de membresia: ") && tipoMembresiaText.Text != "")
            {
                if (!duracionText.Text.Contains("Ingrese duracion en días") && duracionText.Text != "")
                {
                    if (!costoText.Text.Contains("Ingrese costo") && costoText.Text != "")
                    {
                        validado = true;
                        tipoMembresia = tipoMembresiaText.Text;
                        duracionMembresia = duracionText.Text;
                        costo = costoText.Text;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Es necesario especificar un monto para el tipo de membresia", "Error: Sin monto especificado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Es necesario especificar la duracion de la membresia", "Error: Sin duracion especificada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Es necesario especificar el tipo de membresia", "Error: No se ha especificado tipo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult res;
            if (this.ventanaTipo != "creacion")
            {
               res = MessageBox.Show("¿Desea cancelar la actualizacion de la membresia?", "Cancenlando", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                res = MessageBox.Show("¿Desea cancelar el registro de la membresia?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    this.Close();
            }
            
        }

        private void addingMembreshipForm_Load(object sender, EventArgs e)
        {
            if (this.ventanaTipo != "creacion")
            {
                this.Text = "Vampiro Gym - Edicion";
                tipoMembresiaText.Text = membresiasForm.tipoMembresia;
                if (membresiasForm.duracionMembresia.Length == 6)
                {
                    duracionText.Text = membresiasForm.duracionMembresia.Substring(0, 1);
                }
                else if (membresiasForm.duracionMembresia.Length == 7)
                {
                    duracionText.Text = membresiasForm.duracionMembresia.Substring(0, 2);
                }
                else
                {
                    duracionText.Text = membresiasForm.duracionMembresia.Substring(0, 3);
                }
                costoText.Text = membresiasForm.costoMembresia.Remove(0,2);
            }
        }
    }
}
