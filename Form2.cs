using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace tienda_de_zapatos
{
    
    public partial class Form2 : Form
    {


        struct Venta
        {
            //variables publicas
            public int Año;
            public int Sucursal;
            public double Monto;


        }

        private List<Venta> ventas = new List<Venta>();
        public Form2()
        {
            //Datos
            InitializeComponent();
            //2017 año
             ventas.Add(new Venta { Año = 2017, Sucursal = 1, Monto = 10000 });
             ventas.Add(new Venta { Año = 2017, Sucursal = 2, Monto = 20000 });
             ventas.Add(new Venta { Año = 2017, Sucursal = 3, Monto = 30000 });
             ventas.Add(new Venta { Año = 2017, Sucursal = 4, Monto = 40000 });
             ventas.Add(new Venta { Año = 2017, Sucursal = 5, Monto = 5000 });
            //2018 año
            ventas.Add(new Venta { Año = 2018, Sucursal = 1, Monto = 60000 });
            ventas.Add(new Venta { Año = 2018, Sucursal = 2, Monto = 70000 });
            ventas.Add(new Venta { Año = 2018, Sucursal = 3, Monto = 80000 });
            ventas.Add(new Venta { Año = 2018, Sucursal = 4, Monto = 90000 });
            ventas.Add(new Venta { Año = 2018, Sucursal = 5, Monto = 100000 });
            //2019 año
            ventas.Add(new Venta { Año = 2019, Sucursal = 1, Monto = 110000 });
            ventas.Add(new Venta { Año = 2019, Sucursal = 2, Monto = 220000 });
            ventas.Add(new Venta { Año = 2019, Sucursal = 3, Monto = 330000 });
            ventas.Add(new Venta { Año = 2019, Sucursal = 4, Monto = 440000 });
            ventas.Add(new Venta { Año = 2019, Sucursal = 5, Monto = 550000 });
            //2020 año
            ventas.Add(new Venta { Año = 2020, Sucursal = 1, Monto = 10000 });
            ventas.Add(new Venta { Año = 2020, Sucursal = 2, Monto = 20000 });
            ventas.Add(new Venta { Año = 2020, Sucursal = 3, Monto = 30000 });
            ventas.Add(new Venta { Año = 2020, Sucursal = 4, Monto = 40000 });
            ventas.Add(new Venta { Año = 2020, Sucursal = 5, Monto = 50000 });
            //2021 año
            ventas.Add(new Venta { Año = 2021, Sucursal = 1, Monto = 10000 });
            ventas.Add(new Venta { Año = 2021, Sucursal = 2, Monto = 20000 });
            ventas.Add(new Venta { Año = 2021, Sucursal = 3, Monto = 30000 });
            ventas.Add(new Venta { Año = 2021, Sucursal = 4, Monto = 40000 });
            ventas.Add(new Venta { Año = 2021, Sucursal = 5, Monto = 50000 });
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int añoSeleccionado = int.Parse(AñoComboBox.Text);

           
            var ventasAñoSeleccionado = ventas.Where(v => v.Año == añoSeleccionado).ToList();

            if (ventasAñoSeleccionado.Count > 0)
            {
                // Mayor venta
                double mayorVenta = ventasAñoSeleccionado.Max(v => v.Monto);

                lblMayorVenta.Text = mayorVenta.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));

                //sucursal que mas vendió
                int sucursalMasVenta = ventasAñoSeleccionado
                                        .GroupBy(v => v.Sucursal)
                                        .OrderByDescending(grp => grp.Sum(v => v.Monto))
                                        .First()
                                        .Key;
               lblSucursalMasVentas.Text = sucursalMasVenta.ToString();

                //Promedio de ventas
                double promedioVentas = ventasAñoSeleccionado.Average(v => v.Monto);
                lblPromedioVentas.Text = promedioVentas.ToString("C",CultureInfo.CreateSpecificCulture("en-US"));
            }
            else
            {
                //Mensaje que aparece sino tenemos registrado el año con ventas
                MessageBox.Show($"No se encontraron ventas para el año {añoSeleccionado}.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblMayorVenta.Text = "";
            lblPromedioVentas.Text = "";
            lblSucursalMasVentas.Text = "";
            AñoComboBox.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
  //JCDeleon________________________________