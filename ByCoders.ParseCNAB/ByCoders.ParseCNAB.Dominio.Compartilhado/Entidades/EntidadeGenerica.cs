using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace ByCoders.ParseCNAB.Dominio.Compartilhado.Entidades
{
    public class EntidadeGenerica : Notifiable<Notification>
    {
        // TODO: 2 - LIMPAR USINGS 

        public EntidadeGenerica(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
