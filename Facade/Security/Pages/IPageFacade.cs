namespace Facade.Security.Pages
{
    using Dtos.Commons;
    using Dtos.Security.Page;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPageFacade
    {
        Task<ResponseDto<List<PageDto>>> GetAll();
        Task<ResponseDto<PageDto>> GetById(Guid id);
        Task<ResponseDto<PageDto>> Post(PageDto page);
        Task<ResponseDto<PageDto>> Put(Guid id, PageDto page);
    }
}
