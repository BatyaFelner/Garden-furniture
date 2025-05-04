 namespace IDal
{
    public interface IDal<T>
    {
        Task<List<T>> GetAllAsync();
    }
        public interface ICategoryDal: IDal<Dto.Category>
        {
            //Task<List<Dto.Category>> GetCategoryAsync();
        }
    public interface ICompanyDal : IDal<Dto.Company>
    {
    }

    public interface IProductDal:IDal<Dto.Product>
        {
            Task<List<Dto.Product>> GetProductsByCategoryAsync(int categoryId);
        Task<Dto.Product> GetByIdAsync(int Id);
        Task<List<Dto.Product>> filterAsync(int? CodeCat = 0, int? minPrice = 0, int? maxprice = 0, int? codeComp = 0);
        Task<List<Dto.Product>> selectNewasAsync();

    }

    public interface IClientDal : IDal<Dto.Client>
    {
       Task<Dto.Client> GetClientByIdAsync(string Id);
        Task<bool> RegisterAsync(Dto.Client client);
     
    }
    public interface IbuyDal : IDal<Dto.Buy>
    {
        Task<Dto.Buy> addbuyAsync(Dto.Buy b);
        Task<Dictionary<string, int>> SaveBUy(int idBuy);
        Task<List<Dto.Buy>> GetByIdcleinAsync(string id);

    }
    public interface IpurchaseDetailsDal : IDal<Dto.PurchaseDetail>
    {
        Task<List<Dto.Product>> addPurchaseDetailsAsync(List<Dto.Product> purchaseDetails, short buyId);
        

    }
}



