using Fast.Route.Models;
using Fast.Route.Models.Common;
using Fast.Route.Models.Program;
using Fast.Route.Models.RouteSequence;
using Fast.Route.Repository;

namespace Fast.Route.Logic
{
    public class ProgramLogic
    {
        private readonly ProgramRepository _programRepository;
        public ProgramLogic(AppSettings appSettings)
        {
            _programRepository = new ProgramRepository(appSettings);
        }

        public async Task<ItemCollectionModel<SelectValueModel>> GetEnterprises(ParameterModel parameter)
        {
            return await _programRepository.GetEnterprises(parameter);
        }

        public async Task<ItemCollectionModel<ProgramModel>> Get(ParameterModel parameter)
        {
            return await _programRepository.Get(parameter);
        }

        public async Task<ItemModel<ProgramModel>> GetById(ParameterModel parameter)
        {
            return await _programRepository.GetById(parameter);
        }

        public async Task<StatusModel> Add(ProgramModel program)
        {
            return await _programRepository.Add(program);
        }

        public async Task<StatusModel> Update(ProgramModel program)
        {
            return await _programRepository.Update(program);
        }

        public async Task<StatusModel> StatusChange(BaseCommonModel item)
        {
            return await _programRepository.StatusChange(item);
        }

        
    }
}
