using Dapper;
using Fast.Route.Models;
using Fast.Route.Models.Client;
using Fast.Route.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Route.Repository
{
    public class ClientRepository: BaseRepository
    {
        private readonly StatusModel _defaultStatusModel;
        public ClientRepository(AppSettings appSettings) : base(appSettings) 
        {
            _defaultStatusModel = new StatusModel
            {
                StatusCode = "00",
                StatusMessage = "No es posible conectar con el servidor remoto"
            };
        }

        public async Task<ItemCollectionModel<ClientModel>> Get(ParameterModel parameter)
        {
            ItemCollectionModel<ClientModel> response = new();

            try
            {
                response = new ItemCollectionModel<ClientModel>
                {
                    Items = new List<ClientModel>(
                        await Connection.QueryAsync<ClientModel>("USP_CLIENT_SEL", new
                        {
                            DESCRIPTION = parameter.Description ?? ""
                        }, commandTimeout: 0, commandType: CommandType.StoredProcedure)
                    )
                };
            }
            catch (Exception ex)
            {
                response = new ItemCollectionModel<ClientModel>
                {
                    StatusCode = _defaultStatusModel.StatusCode,
                    StatusMessage = _defaultStatusModel.StatusMessage
                };
            }
            return response;
        }

        public async Task<ItemModel<ClientModel>> GetById(ParameterModel parameter)
        {
            ItemModel<ClientModel> response = new();

            try
            {
                response = new ItemModel<ClientModel>
                {
                    Item = await Connection.QueryFirstAsync<ClientModel>("USP_CLIENT_SEL_BYID", new
                    {
                        DESCRIPTION = parameter.Description ?? ""
                    }, commandTimeout: 0, commandType: CommandType.StoredProcedure)
                };
            }
            catch (Exception ex)
            {
                response = new ItemModel<ClientModel>
                {
                    StatusCode = _defaultStatusModel.StatusCode,
                    StatusMessage = _defaultStatusModel.StatusMessage
                };
            }
            return response;
        }

    }
}
