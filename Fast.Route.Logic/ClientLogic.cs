using Fast.Route.Models;
using Fast.Route.Models.Client;
using Fast.Route.Models.Common;
using Fast.Route.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Route.Logic
{
    public class ClientLogic
    {
        private readonly ClientRepository _clientRepository;
        public ClientLogic(AppSettings appSettings)
        {
            _clientRepository = new ClientRepository(appSettings);
        }

        public async Task<ItemCollectionModel<ClientModel>> Get(ParameterModel parameter)
        {
            return await _clientRepository.Get(parameter);
        }

        public async Task<ItemModel<ClientModel>> GetById(ParameterModel parameter)
        {
            return await _clientRepository.GetById(parameter);
        }
    }
}
