using Web_API_Holistic_Assessment.DTOs.CustomerDTOs;

namespace Web_API_Holistic_Assessment.Repo.CustomerRepo
{
    public interface ICutomerRepo
    {
        void AddCustomer(PostCustomer customerPost);
        PostCustomer GetCustomerById(int id);
    }
}
