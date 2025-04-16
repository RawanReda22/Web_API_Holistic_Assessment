using Web_API_Holistic_Assessment.DTOs.ProductDTOs;

namespace Web_API_Holistic_Assessment.Repo.ProductRepo
{
    public interface IProductRepo
    {
        void AddProduct(ProductOnly productOnly);   
    }
}
