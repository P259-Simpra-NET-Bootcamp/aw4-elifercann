using AutoMapper;
using Serilog;
using SimApi.Base;
using SimApi.Data;
using SimApi.Data.Uow;
using SimApi.Schema;

namespace SimApi.Operation.TestCustomer
{
    public class TestCustomerService : BaseService<Customer, CustomerRequest, CustomerResponse>,  ITestCustomerService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public TestCustomerService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public ApiResponse Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<List<CustomerResponse>> GetAll()
        {
            try
            {
                var entityList = unitOfWork.DapperRepository<Customer>().GetAll();
                var mapped = mapper.Map<List<Customer>, List<CustomerResponse>>(entityList);
                return new ApiResponse<List<CustomerResponse>>(mapped);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "GetAll Exception");
                return new ApiResponse<List<CustomerResponse>>(ex.Message);
            }
        }

        public ApiResponse<CustomerResponse> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse Insert(CustomerRequest request)
        {
            throw new NotImplementedException();
        }

        public ApiResponse Update(int Id, CustomerRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
