using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraDeResistencia
{
    public partial class Form1 : Form
    {
        enum cantidadBandas
        {
            cuatro = 4,
            cinco = 5,
            seis = 6
        }
        List<RadioButton> radioButtons;
        cantidadBandas cantidad;

        public Form1() { 
            InitializeComponent();
            radioButtons = new List<RadioButton>()
            {
                negro_banda1,
                marron_banda1,
                rojo_banda1,
                naranja_banda1,
                amarillo_banda1,
                verde_banda1,
                azul_banda1,
                violeta_banda1,
                gris_banda1,
                blanco_banda1,
                negro_banda2,
                marron_banda2,
                rojo_banda2,
                naranja_banda2,
                amarillo_banda2,
                verde_banda2,
                azul_banda2,
                violeta_banda2,
                gris_banda2,
                blanco_banda2,
                negro_banda3,
                marron_banda3,
                rojo_banda3,
                naranja_banda3,
                amarillo_banda3,
                verde_banda3,
                azul_banda3,
                violeta_banda3,
                gris_banda3,
                blanco_banda3,
                mult_1,
                mult_10,
                mult_100,
                mult_1K,
                mult_10k,
                mult_100k,
                mult_1M,
                mult_10M,
                mult_100M,
                mult_1G,
                mult_01,
                mult_001,
                tolerancia_1,
                tolerancia_2,
                tolerancia_05,
                tolerancia_025,
                tolerancia_01,
                tolerancia_005,
                tolerancia_5,
                tolerancia_10,
                ppm_100,
                ppm_50,
                ppm_25,
                ppm_15,
                ppm_10,
                ppm_5
            };

            foreach (RadioButton item in radioButtons)
            { 
                item.CheckedChanged += delegate (object sender, EventArgs e) { calcularResistencia(); };
            }
        }
        private void chb_4bandas_CheckedChanged(object sender, EventArgs e) => actualizarBandas(cantidadBandas.cuatro); 
        private void chk_5bandas_CheckedChanged(object sender, EventArgs e) => actualizarBandas(cantidadBandas.cinco); 
        private void chk_6bandas_CheckedChanged(object sender, EventArgs e) => actualizarBandas(cantidadBandas.seis);

        void actualizarBandas(cantidadBandas bandas)
        {
            cantidad = bandas;
            switch (cantidad)
            {
                case cantidadBandas.cuatro:
                        gb3raBanda.Visible = gbPPM.Visible = false;
                    break;
                case cantidadBandas.cinco:
                        gb3raBanda.Visible = true;
                        gbPPM.Visible = false;
                    break;
                case cantidadBandas.seis:
                        gb3raBanda.Visible = gbPPM.Visible = true;
                    break;
            }
            calcularResistencia();
        }

        void calcularResistencia()
        {
            string ohm = "",
                   unidad = "",
                   tolerancia = "",
                   ppm = "";
            double multiplicador = 0;

            /*Obteniendo en valor de las bandas*/
            //1ra banda
            if (negro_banda1.Checked)           ohm = "0";
            else if (marron_banda1.Checked)     ohm = "1";
            else if (rojo_banda1.Checked)       ohm = "2";
            else if (naranja_banda1.Checked)    ohm = "3";
            else if (amarillo_banda1.Checked)   ohm = "4";
            else if (verde_banda1.Checked)      ohm = "5";
            else if (azul_banda1.Checked)       ohm = "6";
            else if (violeta_banda1.Checked)    ohm = "7";
            else if (gris_banda1.Checked)       ohm = "8";
            else if (blanco_banda1.Checked)     ohm = "9";
            //2da banda
            if (negro_banda2.Checked)           ohm += "0";
            else if (marron_banda2.Checked)     ohm += "1";
            else if (rojo_banda2.Checked)       ohm += "2";
            else if (naranja_banda2.Checked)    ohm += "3";
            else if (amarillo_banda2.Checked)   ohm += "4";
            else if (verde_banda2.Checked)      ohm += "5";
            else if (azul_banda2.Checked)       ohm += "6";
            else if (violeta_banda2.Checked)    ohm += "7";
            else if (gris_banda2.Checked)       ohm += "8";
            else if (blanco_banda2.Checked)     ohm += "9";
            //3ra banda
            if (gb3raBanda.Visible)
            {
                if (negro_banda3.Checked)           ohm += "0";
                else if (marron_banda3.Checked)     ohm += "1";
                else if (rojo_banda3.Checked)       ohm += "2";
                else if (naranja_banda3.Checked)    ohm += "3";
                else if (amarillo_banda3.Checked)   ohm += "4";
                else if (verde_banda3.Checked)      ohm += "5";
                else if (azul_banda3.Checked)       ohm += "6";
                else if (violeta_banda3.Checked)    ohm += "7";
                else if (gris_banda3.Checked)       ohm += "8";
                else if (blanco_banda3.Checked)     ohm += "9";
            }
            /* Obteniendo el multiplicador */
            if (mult_1.Checked)         { multiplicador = 1; }
            else if (mult_10.Checked)   { multiplicador = 10; }
            else if (mult_100.Checked)  { multiplicador = 100; }
            else if (mult_1K.Checked)   { multiplicador = 1000; }
            else if (mult_10k.Checked)  { multiplicador = 10000; }
            else if (mult_100k.Checked) { multiplicador = 100000; }
            else if (mult_1M.Checked)   { multiplicador = 1000000; }
            else if (mult_10M.Checked)  { multiplicador = 10000000; }
            else if (mult_100M.Checked) { multiplicador = 100000000; }
            else if (mult_1G.Checked)   { multiplicador = 1000000000; }
            else if (mult_01.Checked)   { multiplicador = 0.1; }
            else if (mult_001.Checked)  { multiplicador = 0.01; }

            /*        Obteniendo tolerancia       */
            if (tolerancia_1.Checked)       tolerancia = "1%";
            else if (tolerancia_2.Checked)  tolerancia = "2%";
            else if (tolerancia_05.Checked) tolerancia = "0.5%";
            else if (tolerancia_025.Checked)tolerancia = "0.25%";
            else if (tolerancia_01.Checked) tolerancia = "0.1%";
            else if (tolerancia_005.Checked)tolerancia = "0.05%";
            else if (tolerancia_5.Checked)  tolerancia = "5%";
            else if (tolerancia_10.Checked) tolerancia = "10%";

            /*        Obteniendo PPM       */
            if (gbPPM.Visible)
            {
                if (ppm_100.Checked)     ppm = " 100 PPM";
                else if (ppm_50.Checked) ppm = " 50 PPM";
                else if (ppm_25.Checked) ppm = " 25 PPM";
                else if (ppm_15.Checked) ppm = " 15 PPM";
                else if (ppm_10.Checked) ppm = " 10 PPM";
                else if (ppm_5.Checked)  ppm = " 5 PPM";
            }

            double totalOhm = Convert.ToDouble(ohm);
            totalOhm *= multiplicador;

            if  (totalOhm >= 1000000000) { totalOhm /= 1000000000; unidad = "G"; }
            else if (totalOhm >= 1000000) { totalOhm /= 1000000; unidad = "M"; }
            else if (totalOhm >= 1000) { totalOhm /= 1000; unidad = "K"; }

            Resultado.Text = $"{totalOhm}{unidad} Ohms {tolerancia}{ppm}";
        }

        private void negro_banda1_CheckedChanged(object sender, EventArgs e) => calcularResistencia();
    }
}
