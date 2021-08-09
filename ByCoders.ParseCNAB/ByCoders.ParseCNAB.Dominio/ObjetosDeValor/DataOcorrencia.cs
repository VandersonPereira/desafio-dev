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
                .IsNotNull(segundo, "Segundo", "As posições de 46 até 47, devem conter um valor válido para os segundos.")
                .IsNotNull(minuto, "Minuto", "As posições de 44 até 45, devem conter um valor válido para os minutos.")
                .IsNotNull(hora, "Hora", "As posições de 42 até 43, devem conter um valor válido para as horas.")
                .IsNotNull(dia, "Dia", "As posições de 7 até 8, devem conter um valor válido para o dia.")
                .IsNotNull(mes, "Mês", "As posições de 5 até 6, devem conter um valor válido para o mês.")
                .IsNotNull(ano, "Ano", "As posições de 1 até 4, devem conter um valor válido para o ano."));

            Data = MontarData(segundo, minuto, hora, dia, mes, ano);

            if (Data > DateTime.Now)
                AddNotification(new Notification("Data", "A data não pode ser superior a atual!"));
        }

        public DataOcorrencia(DateTime dataOcorrencia)
        {
            Data = dataOcorrencia;

            AddNotifications(new Contract<DataOcorrencia>()
                .Requires()
                .IsNotNull(dataOcorrencia, "Data Ocorrência", "A data deve ser informada."));

            if (Data > DateTime.Now.AddDays(1))
                AddNotification(new Notification("Data", "A data não pode ser superior a atual!"));
        }

        public DateTime Data { get; private set; }

        private DateTime MontarData(int segundo, int minuto, int hora, int dia, int mes, int ano)
        {
            return new DateTime(ano, mes, dia, hora, minuto, segundo);
        }
    }
}
