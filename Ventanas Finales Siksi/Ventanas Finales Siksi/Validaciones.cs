using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ventanas_Finales_Siksi
{
    class Validaciones
    {
        public void soloLetras(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar))
                    e.Handled = false;

                else if (Char.IsControl(e.KeyChar))
                    e.Handled = false;

                else if (Char.IsSeparator(e.KeyChar))
                    e.Handled = false;

                else if (Char.IsPunctuation(e.KeyChar))
                    e.Handled = false;

                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {

            }
        }

        public void LetrasNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar))
                    e.Handled = false;

                else if (Char.IsNumber(e.KeyChar))
                    e.Handled = false;

                else if (Char.IsControl(e.KeyChar))
                    e.Handled = false;

                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {

            }
        }

        public void Numeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.KeyChar))
                    e.Handled = false;

                else if (Char.IsControl(e.KeyChar))
                    e.Handled = false;

                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {

            }
        }

        public void CantidadPorcentaje(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsNumber(e.KeyChar))
                    e.Handled = false;

                else if (Char.IsControl(e.KeyChar))
                    e.Handled = false;

                else if (Char.IsPunctuation(e.KeyChar))
                {
                    if (e.KeyChar == '.')
                        e.Handled = false;
                    else
                        e.Handled = true;
                }

                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
