
namespace DataAcccess.Beneficiary
{
    using DataAcccess.Interface;
    using DataAcccess.Util;
    using Entities.Core;
    using Entities.Models.Catalog;
    using Microsoft.EntityFrameworkCore;


    public class BeneficiaryDao : ICatalogDao<BeneficiaryModel>
    {
        private readonly IDataBaseContext ctx;
        public BeneficiaryDao(IDataBaseContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<List<BeneficiaryModel>> GetAll()
        {
            var beneficiary = await this.ctx.Beneficiaries.Include(e => e.Employee).ToListAsync();
            SqlValidation<BeneficiaryModel>.VailidateCountList(beneficiary, "Beneficiarios");
            return beneficiary;
        }

        public async Task<BeneficiaryModel> GetById(Guid id)
        {
            var beneficiaryById = await this.ctx.Beneficiaries.Include(e => e.Employee).Where(x => x.Id == id).FirstOrDefaultAsync();
            SqlValidation<BeneficiaryModel>.VailidateFound(beneficiaryById, "Beneficiario");
            return beneficiaryById;
        }

        public async Task<BeneficiaryModel> Post(BeneficiaryModel beneficiary)
        {
            var dataGuid = new Guid();
            beneficiary.Id = new Guid();
            this.ctx.Beneficiaries.Add(beneficiary);
            await ((DataBaseContext)this.ctx).SaveChangesAsync();
            return beneficiary;
        }

        public async Task<BeneficiaryModel> Put(Guid id, BeneficiaryModel beneficiary)
        {
            var beneficiaryById = await this.ctx.Beneficiaries.Where(e => e.Id == id).FirstOrDefaultAsync();
            SqlValidation<BeneficiaryModel>.VailidateFound(beneficiaryById, "Beneficiario");
            beneficiaryById.Name = beneficiary.Name;
            beneficiaryById.FirstName = beneficiary.FirstName;
            beneficiaryById.SeconLastName = beneficiary.SeconLastName;
            beneficiaryById.Relationship = beneficiary.Relationship;
            await ((DataBaseContext)this.ctx).SaveChangesAsync();
            return beneficiaryById;
        }
    }
}
