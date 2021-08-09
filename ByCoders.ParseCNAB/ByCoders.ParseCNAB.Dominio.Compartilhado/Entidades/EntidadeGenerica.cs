using Flunt.Notifications;

namespace ByCoders.ParseCNAB.Dominio.Compartilhado.Entidades
{
    public class EntidadeGenerica : Notifiable<Notification>
    {
        public EntidadeGenerica(int id = 0)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
