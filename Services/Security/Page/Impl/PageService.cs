namespace Services.Security.Page.Impl
{
    using AutoMapper;
    using DataAcccess.Interface;
    using Dtos.Security.Page;
    using Entities.Models.Security;
    using Services.Interface;

    public class PageService : IGenericService<PageDto>
    {
        private readonly ICatalogDao<PageModel> pageDao;
        private readonly IMapper mapper;
        public PageService(ICatalogDao<PageModel> pageDao, IMapper mapper)
        {
            this.pageDao = pageDao;
            this.mapper = mapper;
        }

        public async Task<List<PageDto>> GetAll()
        {
            return mapper.Map<List<PageDto>>(await this.pageDao.GetAll());
        }

        public async Task<PageDto> GetById(Guid id)
        {
            return mapper.Map<PageDto>(await this.pageDao.GetById(id));
        }

        public async Task<PageDto> Post(PageDto model)
        {
            var pageDto = this.mapper.Map<PageModel>(model);
            return mapper.Map<PageDto>(await this.pageDao.Post(pageDto));
        }

        public async Task<PageDto> Put(Guid id, PageDto model)
        {
            var pageDto = this.mapper.Map<PageModel>(model);
            return mapper.Map<PageDto>(await this.pageDao.Put(id, pageDto));
        }
    }
}
