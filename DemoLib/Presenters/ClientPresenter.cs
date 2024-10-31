// DemoLib.Presenters/ClientPresenter.cs
using DemoLib.Models;
using DemoLib.Views;
using System.Collections.Generic;

namespace DemoLib.Presenters
{
    public class ClientPresenter
    {
        private IClientsModel model_;
        private List<IClientView> views_ = new List<IClientView>();

        public ClientPresenter(IClientsModel model)
        {
            model_ = model;
            model_.UpdatedClients += Model__UpdatedClients;
        }

        public void UpdateClient(Client updatedClient)
        {
            var clients = model_.GetClients();
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].ID == updatedClient.ID)
                {
                    clients[i] = updatedClient;
                    break;
                }
            }

            if (model_ is MemoryClientsModel memoryModel)
            {
                memoryModel.NotifyClientsUpdated();
            }
        }

        public void Model__UpdatedClients()
        {
            List<Client> clients = model_.GetClients();
            for (int i = 0; i < clients.Count; i++)
            {
                Client client = clients[i];
                IClientView clientView = views_[i];
                clientView.LoadClient(client);
            }
        }

        public void AddView(IClientView view)
        {
            views_.Add(view);
        }
    }
}
