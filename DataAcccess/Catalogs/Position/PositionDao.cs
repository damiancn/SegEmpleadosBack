namespace DataAcccess.Catalogs.Position
{
    using DataAcccess.Interface;
    using DataAcccess.Util;
    using Entities.Core;
    using Entities.Models.Catalog;
    using Microsoft.EntityFrameworkCore;

    public class PositionDao : ICatalogDao<PositionModel>
    {
        private readonly IDataBaseContext ctx;
        public PositionDao(IDataBaseContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<List<PositionModel>> GetAll()
        {
            var position = await this.ctx.Positions.Where(e=> e.Active == true).ToListAsync();
            SqlValidation<PositionModel>.ValidateCountList(position, "Posiciones");
            return position;
        }

        public async Task<PositionModel> GetById(Guid id)
        {
            var positionId = await this.ctx.Positions.Where(e => e.Active == true).Where(e =>e.Id == id).FirstOrDefaultAsync();
            SqlValidation<PositionModel>.ValidateFound(positionId, "Posición");
            return positionId;
        }

        public async Task<PositionModel> Post(PositionModel position)
        {
            position.Id = new Guid();
            this.ctx.Positions.Add(position);
            await ((DataBaseContext)this.ctx).SaveChangesAsync();
            return position;
        }

        public async Task<PositionModel> Put(Guid id, PositionModel position)
        {
            var positionById = await this.ctx.Positions.Where(e => e.Id == id).FirstOrDefaultAsync();
            SqlValidation<PositionModel>.ValidateFound(positionById, "Posición");
            positionById.Name = position.Name;
            positionById.Active = position.Active;
            await ((DataBaseContext)this.ctx).SaveChangesAsync();
            return positionById;
        }
    }
}
