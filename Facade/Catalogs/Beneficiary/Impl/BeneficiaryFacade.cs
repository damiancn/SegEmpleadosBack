


namespace Facade.Beneficiary.Impl
{
    using Dtos.Beneficiary;
    using Dtos.Commons;
    using Services.Interface;

    public class BeneficiaryFacade : IBeneficiaryFacade
    {
        private readonly IGenericService<BeneficiaryDto> modelService;

        public BeneficiaryFacade(IGenericService<BeneficiaryDto> modelService)
        {
            this.modelService = modelService;
        }

        public async Task<ResponseDto<List<BeneficiaryDto>>> GetAll()
        {
            return new ResponseDto<List<BeneficiaryDto>>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Busqueda exitosa  Beneficiarios",
                Dto = await this.modelService.GetAll(),
            };
        }

        public async Task<ResponseDto<BeneficiaryDto>> GetById(Guid id)
        {
            return new ResponseDto<BeneficiaryDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Busqueda exitosa de Beneficiario",
                Dto = await this.modelService.GetById(id),
            };
        }

        public async Task<ResponseDto<BeneficiaryDto>> Post(BeneficiaryDto employee)
        {
            return new ResponseDto<BeneficiaryDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Se generó el beneficiario con éxito",
                Dto = await this.modelService.Post(employee),
            };
        }

        public async Task<ResponseDto<BeneficiaryDto>> Put(Guid id, BeneficiaryDto employee)
        {
            return new ResponseDto<BeneficiaryDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Se genero el cambio con éxito",
                Dto = await this.modelService.Put(id, employee),
            };
        }
    }
}
