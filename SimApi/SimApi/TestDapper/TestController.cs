using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimApi.Base;
using SimApi.Data.Repository;
using SimApi.Operation;
using SimApi.Operation.TestCustomer;
using SimApi.Schema;

namespace SimApi.Service.TestDapper
{
    [EnableMiddlewareLogger]
    [ResponseGuid]
    [Route("simapi/v1/[controller]")]
    [ApiController]
    public class TestController:ControllerBase
    {
        private readonly ITestCustomerService customerService;
        public TestController(ITestCustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet]
        public ApiResponse<List<CustomerResponse>> GetAll()
        {
            var customerList = customerService.GetAll();
            return customerList;
        }
    }
}
