using System;
using System.Linq;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        private double ValidarNumero(string strNumero)
        {
            double ret;
            if (!double.TryParse(strNumero, out ret))
            {
                ret = 0;
            }
            return ret;
        }

        private bool EsBinario(string binario)
        {
            foreach (var item in binario)
            {
                if (item != '1' && item != '0')
                {
                    return false;
                }
            }
            return true;
        }

        public string BinarioDecimal(string binario)
        {
            if (EsBinario(binario))
            {
                int numDecimal = 0;
                int exponente = 0;
                int i;
                char[] vecBiario = binario.ToArray();

                for (i = vecBiario.Length - 1; i >= 0; i--)
                {
                    if (vecBiario[i] == '1')
                    {
                        numDecimal += (int)Math.Pow(2, exponente);
                    }
                    exponente++;
                }
                return numDecimal.ToString();
            }
            else
            {
                return "Valor invalido";
            }
        }

        public string DecimalBinario(double numero)
        {
            int resto;
            int cociente = (int)Math.Abs(numero);
            string binario = "";
            do
            {
                resto = cociente % 2;
                cociente = cociente / 2;
                binario += resto;

            } while (cociente >= 2);

            binario += cociente;

            binario = Reverse(binario);

            return binario;
        }

        public string DecimalBinario(string numero)
        {
            string binario = "Valor invalido";
            double numeroDouble;
            if (double.TryParse(numero, out numeroDouble))
            {
                binario = DecimalBinario(numeroDouble);
            }
            return binario;
        }

        private static string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
    }
}