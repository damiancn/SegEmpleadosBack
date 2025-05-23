namespace Services.Catalogs.Position
{
    using AutoMapper;
    using DataAcccess.Interface;
    using Dtos.Catalogs.Position;
    using Entities.Models.Catalog;
    using Services.Interface;

    public class PositionService : IGenericService<PositionDto>
    {
        private readonly ICatalogDao<PositionModel> positionDao;
        private readonly IMapper mapper;
        public PositionService(ICatalogDao<PositionModel> positionDao, IMapper mapper)
        {
            this.positionDao = positionDao;
            this.mapper = mapper;
        }
        public async Task<List<PositionDto>> GetAll()
        {
            return mapper.Map<List<PositionDto>>(await this.positionDao.GetAll());
        }

        public async Task<PositionDto> GetById(Guid id)
        {
            return mapper.Map<PositionDto>(await this.positionDao.GetById(id));
        }

        public async Task<PositionDto> Post(PositionDto model)
        {
            var positionDto = this.mapper.Map<PositionModel>(model);
            return mapper.Map<PositionDto>(await this.positionDao.Post(positionDto));
        }

        public async Task<PositionDto> Put(Guid id, PositionDto model)
        {
            var positionDto = this.mapper.Map<PositionModel>(model);
            return mapper.Map<PositionDto>(await this.positionDao.Put(id, positionDto));
        }
    }
}
