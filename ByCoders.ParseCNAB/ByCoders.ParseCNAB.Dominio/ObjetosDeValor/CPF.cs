using Flunt.Notifications;

namespace ByCoders.ParseCNAB.Dominio.ObjetosDeValor
{
    public class CPF : Notifiable<Notification>
    {
        protected CPF() { }

        public CPF(string numero)
        {
            if (!ValidarCPF(numero))
                AddNotification("CPF", "CPF inválido!");

           Numero = numero;
        }

        public string Numero { get; private set; }

        private bool ValidarCPF(string numero)
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            numero = numero.Trim();
            numero = numero.Replace(".", "").Replace("-", "");
            if (numero.Length != 11)
                return false;
            var tempCpf = numero.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            var digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return numero.EndsWith(digito);
        }
    }
}
