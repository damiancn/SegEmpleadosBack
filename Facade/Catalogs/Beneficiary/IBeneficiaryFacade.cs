
namespace Facade.Beneficiary
{
    using Dtos.Beneficiary;
    using Dtos.Commons;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IBeneficiaryFacade
    {
        Task<ResponseDto<List<BeneficiaryDto>>> GetAll();
        Task<ResponseDto<BeneficiaryDto>> GetById(Guid id);
        Task<ResponseDto<BeneficiaryDto>> Post(BeneficiaryDto employee);
        Task<ResponseDto<BeneficiaryDto>> Put(Guid id, BeneficiaryDto employee);
    }
}
