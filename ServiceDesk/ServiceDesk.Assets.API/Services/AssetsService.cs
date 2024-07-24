using ServiceDesk.Assets.Storage.Entities;
using ServiceDesk.Assets.Storage;
using CrudBase;

using ServiceDesk.Assets.CrossCutting.Dtos;
using AutoMapper;
using ServiceDesk.Assets.API.Interfaces;
    using ServiceDesk.Assets.API.Builders;

namespace ServiceDesk.Assets.API.Services
{
    public class AssetsService : IAssetsService      /* : BaseService<Asset>*/
    {
        private readonly IMapper _mapper;
        private readonly AssetsDbContext _context;

        public AssetsService(IMapper mapper,AssetsDbContext context) /*: base(context)*/
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<CrudOperationResult<List<AssetDto>>> GetAll()
        {
            throw new NotImplementedException();
        }


        //public async Task<CrudOperationResult<List<AssetDto>>> GetAll()
        //{
        //    var sourceList = _context.Assets.ToList();

        //    var list = _mapper.Map<List<AssetDto>>(sourceList);

        //    // Używamy budowniczego do stworzenia wyniku
        //    var result = new CrudOperationResultBuilder<List<AssetDto>>()
        //        .WithStatus(CrudOperationResultStatus.Success)
        //        .WithResult(list)
        //        .WithMessage("Operacja zakończona sukcesem.")
        //        .Build();

        //    return result;
        //}





    }
}
