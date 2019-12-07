using Ecommerce.Library.Repositories;

namespace EcommerceApp.Repositories
{
    public interface IUnitOfWork
    {
        ProductRepository ProductRepository { get; }
       

        bool SaveChanges();
    }
}