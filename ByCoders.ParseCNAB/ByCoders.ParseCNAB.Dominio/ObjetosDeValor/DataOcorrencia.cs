using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace ByCoders.ParseCNAB.Dominio.ObjetosDeValor
{
    public class DataOcorrencia : Notifiable <Notification>
    {
        // TODO: 1- ADICIONAR FLUNT PARA NOTIFICAÇÕES (validações no construtor); 
        protected DataOcorrencia() { }

        public DataOcorrencia(int segundo, int minuto, int hora, int dia, int mes, int ano)
        {
            AddNotifications(new Contract<DataOcorrencia>()
                .Requires()
                .IsNullOrEmpty(string.Empty, "Segundo", "As posições de 46 até 47, devem conter um valor válido para os segundos.")
                .IsNullOrEmpty(string.Empty, "Minuto", "As posições de 44 até 45, devem conter um valor válido para os minutos.")
                .IsNullOrEmpty(string.Empty, "Hora", "As posições de 42 até 43, devem conter um valor válido para as horas.")
                .IsNullOrEmpty(string.Empty, "Dia", "As posições de 7 até 8, devem conter um valor válido para o dia.")
                .IsNullOrEmpty(string.Empty, "Mês", "As posições de 5 até 6, devem conter um valor válido para o mês.")
                .IsNullOrEmpty(string.Empty, "Ano", "As posições de 1 até 4, devem conter um valor válido para o ano."));

            Data = MontarData(segundo, minuto, hora, dia, mes, ano);
        }

        public DataOcorrencia(DateTime dataOcorrencia)
        {
            Data = dataOcorrencia;

            AddNotifications(new Contract<DataOcorrencia>()
                .Requires()
                .IsNullOrEmpty(string.Empty, "Data Ocorrência", "A data deve ser informada."));
        }

        public DateTime Data { get; private set; }

        private DateTime MontarData(int segundo, int minuto, int hora, int dia, int mes, int ano)
        {
            return new DateTime(ano, mes, dia, hora, minuto, segundo);
        }
    }
}
