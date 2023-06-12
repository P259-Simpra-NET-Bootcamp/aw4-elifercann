using SimApi.Data;
using SimApi.Schema;

namespace SimApi.Operation.TestCustomer
{
    public interface ITestCustomerService:IBaseService<Customer, CustomerRequest, CustomerResponse>
    {
    }
}
