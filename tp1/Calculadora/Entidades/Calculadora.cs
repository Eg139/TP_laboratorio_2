using System;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(char operador)
        {
            string ret;
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                ret = operador.ToString();
            }
            else
            {
                ret = "+";
            }
            return ret;
        }

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string operadorValido = ValidarOperador(Convert.ToChar(operador));
            double ret = 0;

            switch (operadorValido)
            {
                case "+":
                    ret = num1 + num2;
                    break;
                case "-":
                    ret = num1 - num2;
                    break;
                case "/":
                    ret = num1 / num2;
                    break;
                case "*":
                    ret = num1 * num2;
                    break;
            }
            return ret;
        }
    }
}
