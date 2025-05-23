namespace DataAcccess.Security.Pages
{
    using DataAcccess.Interface;
    using DataAcccess.Util;
    using Entities.Core;
    using Entities.Models.Security;
    using Microsoft.EntityFrameworkCore;

    public class PageDao : ICatalogDao<PageModel>
    {
        private readonly IDataBaseContext ctx;
        public PageDao(IDataBaseContext ctx)
        {
            this.ctx = ctx;
        }
        public async Task<List<PageModel>> GetAll()
        {
            var page = await this.ctx.Pages.Where(e => e.Active).ToListAsync();
            SqlValidation<PageModel>.ValidateCountList(page, "Página");
            return page;
        }
        public async Task<PageModel> GetById(Guid id)
        {
            var pageId = await this.ctx.Pages.Where(e => e.Active).Where(e => e.Id == id).FirstOrDefaultAsync();
            SqlValidation<PageModel>.ValidateFound(pageId, "Página");
            return pageId;
        }

        public async Task<PageModel> Post(PageModel page)
        {
            page.Id = new Guid();
            this.ctx.Pages.Add(page);
            await ((DataBaseContext)this.ctx).SaveChangesAsync();
            return page;
        }

        public async Task<PageModel> Put(Guid id, PageModel page)
        {
            var pageId = await this.ctx.Pages.Where(e => e.Id == id).FirstOrDefaultAsync();
            SqlValidation<PageModel>.ValidateFound(pageId, "Página");
            pageId.Name = page.Name;
            pageId.Icon = page.Icon;
            pageId.Code = page.Code;
            pageId.Active = page.Active;
            await((DataBaseContext)this.ctx).SaveChangesAsync();
            return pageId;
        }
    }
}
