namespace Facade.Security.Pages.Impl
{
    using Dtos.Commons;
    using Dtos.Security.Page;
    using Services.Interface;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PageFacade : IPageFacade
    {
        private readonly IGenericService<PageDto> modelService;

        public PageFacade(IGenericService<PageDto> modelService)
        {
            this.modelService = modelService;
        }
        public async Task<ResponseDto<List<PageDto>>> GetAll()
        {
            return new ResponseDto<List<PageDto>>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Búsqueda exitosa de páginas",
                Dto = await this.modelService.GetAll(),
            };
        }

        public async Task<ResponseDto<PageDto>> GetById(Guid id)
        {
            return new ResponseDto<PageDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Búsqueda exitosa de la página",
                Dto =await this.modelService.GetById(id)
            };
        }

        public async Task<ResponseDto<PageDto>> Post(PageDto page)
        {
            return new ResponseDto<PageDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Se generó la nueva página",
                Dto = await this.modelService.Post(page)
            };
        }

        public async Task<ResponseDto<PageDto>> Put(Guid id, PageDto page)
        {
            return new ResponseDto<PageDto>
            {
                MesageError = null,
                Ok = true,
                Mesage = "Se actualizó la página con éxito",
                Dto = await this.modelService.Put(id,page)
            };
        }
    }
}
