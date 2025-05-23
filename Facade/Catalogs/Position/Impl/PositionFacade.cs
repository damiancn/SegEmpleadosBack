namespace Facade.Catalogs.Position.Impl
{
    using Dtos.Catalogs.Position;
    using Dtos.Commons;
    using Services.Interface;
    public class PositionFacade: IPositionFacade
    {
        private readonly IGenericService<PositionDto> modelService;
        public PositionFacade(IGenericService<PositionDto> modelService)
        {
            this.modelService = modelService;
        }

        public async Task<ResponseDto<List<PositionDto>>> GetAll()
        {
            return new ResponseDto<List<PositionDto>>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Búsqueda exitosa de Posiciones",
                Dto = await this.modelService.GetAll(),
            };
        }

        public async Task<ResponseDto<PositionDto>> GetById(Guid id)
        {
            return new ResponseDto<PositionDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Búsqueda exitosa de Posición",
                Dto = await this.modelService.GetById(id),
            };
        }

        public async Task<ResponseDto<PositionDto>> Post(PositionDto position)
        {
            return new ResponseDto<PositionDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Se generó la nueva posición con éxito",
                Dto = await this.modelService.Post(position),
            };
        }
        public async Task<ResponseDto<PositionDto>> Put(Guid id,PositionDto position)
        {
            return new ResponseDto<PositionDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Se actualizo la posición con éxito",
                Dto = await this.modelService.Put(id, position)
            };
        }
    }
}
