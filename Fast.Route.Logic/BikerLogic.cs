using Fast.Route.Models;
using Fast.Route.Models.Biker;
using Fast.Route.Models.Common;
using Fast.Route.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Route.Logic
{
    public class BikerLogic
    {
        private readonly BikerRepository _bikerRepository;
        public BikerLogic(AppSettings appSettings)
        {
            _bikerRepository = new BikerRepository(appSettings);
        }

        public async Task<ItemCollectionModel<BikerModel>> Get(ParameterModel parameter)
        {
            return await _bikerRepository.Get(parameter);
        }

        public async Task<ItemModel<BikerModel>> GetById(ParameterModel parameter)
        {
            return await _bikerRepository.GetById(parameter);
        }
    }
}
