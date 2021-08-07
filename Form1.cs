using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercio01
{
    public partial class frmPagoEmpleado : Form
    {
        //Declarando variables goblales
        double sueldo;
        double comision;
        public frmPagoEmpleado()
        {
            InitializeComponent();
            tHora.Enabled = true;
        }

        private void tHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void frmPagoEmpleado_Load(object sender, EventArgs e)
        {
            //Mostrando la fecha actual
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoria = cboCategoria.Text;

            switch (categoria)
            {
                case "E1": sueldo = 2500; break;
                case "E2": sueldo = 2250; break;
                case "E3": sueldo = 2000; break;
            }
            lblSueldo.Text = sueldo.ToString("C");
        }

        private void cboImporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            string importe = cboImporte.Text;
            switch (importe)
            {
                case "≥9000": comision = sueldo * 11 /100; break;
                case "≥ 6000 y <9000":  comision = sueldo * 9/100; break;
                case "≥ 3000 y < 6000": comision = sueldo * 7/100; break;
                case "<3000": comision = sueldo * 5/100; break;
            }
            lblComision.Text = comision.ToString("C");
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            //Capturando los datos
            string empleado = txtEmpleado.Text;
            string categoria = cboCategoria.Text;
            string sueldo1 = lblSueldo.Text;
            string comision1 = lblComision.Text;

            //calculando sueldo bruto
            double sueldoBruto = sueldo + comision;
            //calculando descuento
            double descuento = sueldoBruto * 15 / 100;
            //calculando sueldo net0
            double sueldoneto = sueldoBruto - descuento;

            //Impresion de planilla
            ListViewItem fila = new ListViewItem(empleado);
            fila.SubItems.Add(categoria);
            fila.SubItems.Add(sueldo1.ToString());
            fila.SubItems.Add(comision1.ToString());
            fila.SubItems.Add(sueldoBruto.ToString("C"));
            fila.SubItems.Add(descuento.ToString("C"));
            fila.SubItems.Add(sueldoneto.ToString("C"));

            lvEmpleados.Items.Add(fila);

            //Limpiando los controles
            txtEmpleado.Clear();
            cboCategoria.SelectedIndex = -1;
            lblSueldo.Text = (0).ToString("C");
            txtEmpleado.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta seguro de salir?", "Pago de Empleados", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (r == DialogResult.Yes) this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
