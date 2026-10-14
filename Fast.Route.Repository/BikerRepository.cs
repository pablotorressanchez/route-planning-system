using Dapper;
using Fast.Route.Models;
using Fast.Route.Models.Biker;
using Fast.Route.Models.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Route.Repository
{
    public class BikerRepository: BaseRepository
    {
        private readonly StatusModel _defaultStatusModel;
        public BikerRepository(AppSettings appSettings): base(appSettings) 
        {
            _defaultStatusModel = new StatusModel
            {
                StatusCode = "00",
                StatusMessage = "No es posible conectar con el servidor remoto"
            };
        }

        public async Task<ItemCollectionModel<BikerModel>> Get(ParameterModel parameter)
        {
            ItemCollectionModel<BikerModel> response = new();

            try
            {
                response = new ItemCollectionModel<BikerModel>
                {
                    Items = new List<BikerModel>(
                        await Connection.QueryAsync<BikerModel>("USP_BIKER_SEL", new
                        {
                            DESCRIPTION = parameter.Description ?? ""
                        }, commandTimeout: 0, commandType: CommandType.StoredProcedure)
                    )
                };
            }
            catch (Exception ex)
            {
                response = new ItemCollectionModel<BikerModel>
                {
                    StatusCode = _defaultStatusModel.StatusCode,
                    StatusMessage = _defaultStatusModel.StatusMessage
                };
            }
            return response;
        }

        public async Task<ItemModel<BikerModel>> GetById(ParameterModel parameter)
        {
            ItemModel<BikerModel> response = new();

            try
            {
                response = new ItemModel<BikerModel>
                {
                    Item = await Connection.QueryFirstAsync<BikerModel>("USP_BIKER_SEL_BYID", new
                    {
                        DESCRIPTION = parameter.Description ?? ""
                    }, commandTimeout: 0, commandType: CommandType.StoredProcedure)
                };
            }
            catch (Exception ex)
            {
                response = new ItemModel<BikerModel>
                {
                    StatusCode = _defaultStatusModel.StatusCode,
                    StatusMessage = _defaultStatusModel.StatusMessage
                };
            }
            return response;
        }
    }
}
