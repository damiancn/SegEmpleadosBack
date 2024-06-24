namespace Services.Beneficiary
{
    using AutoMapper;
    using DataAcccess.Interface;
    using Dtos.Beneficiary;
    using Entities.Models.Catalog;
    using Services.Interface;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BeneficiaryService : IGenericService<BeneficiaryDto>
    {
        private readonly ICatalogDao<BeneficiaryModel> beneficiaryDao;
        private readonly IMapper mapper;
        public BeneficiaryService(ICatalogDao<BeneficiaryModel> beneficiaryDao, IMapper mapper)
        {
            this.beneficiaryDao = beneficiaryDao;
            this.mapper = mapper;
        }

        public async Task<List<BeneficiaryDto>> GetAll()
            {
            return this.mapper.Map<List<BeneficiaryDto>>(await this.beneficiaryDao.GetAll());
        }

        public async Task<BeneficiaryDto> GetById(Guid id)
        {
            return this.mapper.Map<BeneficiaryDto>(await this.beneficiaryDao.GetById(id));
        }

        public async Task<BeneficiaryDto> Post(BeneficiaryDto model)
        {
            var beneficiaryModel = this.mapper.Map<BeneficiaryModel>(model);
            return this.mapper.Map<BeneficiaryDto>(await this.beneficiaryDao.Post(beneficiaryModel));
        }

        public async Task<BeneficiaryDto> Put(Guid id, BeneficiaryDto model)
        {
            var beneficiaryModel = this.mapper.Map<BeneficiaryModel>(model);
            return this.mapper.Map<BeneficiaryDto>(await this.beneficiaryDao.Put(id, beneficiaryModel));
        }
    }
}
