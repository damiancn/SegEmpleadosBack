namespace Facade.Catalogs.Position
{
    using Dtos.Catalogs.Position;
    using Dtos.Commons;
    public interface IPositionFacade
    {
        Task<ResponseDto<List<PositionDto>>> GetAll();
        Task<ResponseDto<PositionDto>> GetById(Guid id);
        Task<ResponseDto<PositionDto>> Post(PositionDto position);
        Task<ResponseDto<PositionDto>> Put(Guid id, PositionDto position);
    }
}
