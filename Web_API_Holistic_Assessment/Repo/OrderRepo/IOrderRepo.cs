using Web_API_Holistic_Assessment.DTOs.OrderDTO;

namespace Web_API_Holistic_Assessment.Repo.OrderRepo
{
    public interface IOrderRepo
    {
        IEnumerable<OrdersDTO> GetAll();
        void Add(OrderForProduct orderDTO);   
        void Update(OrderForProduct orderForProduct , int id, int productId);
        void Delete(int id);
    }
}
