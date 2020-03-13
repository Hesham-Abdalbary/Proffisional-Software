using AutoMapper;
using MiniShoppingCartApplication.Models;
using MiniShoppingCartApplication.Repository;
using MiniShoppingCartApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniShoppingCartApplication.Services
{
    public class CustomerOrderService
    {
        private CustomerOrderRepository _repo;
        public CustomerOrderService()
        {
            _repo = new CustomerOrderRepository();
        }

        public List<CustomerOrderDto> GetAll()
        {
            var customerOrders = _repo.GetAll();
            var customerOrdersModels = Mapper.Map<List<CustomerOrder>, List<CustomerOrderDto>>(customerOrders);
            return customerOrdersModels;
        }

        public CustomerOrderDto GetByID(int customerOrderID)
        {
            var customerOrderEntity = _repo.GetByID(customerOrderID);
            var customerOrderModel = Mapper.Map<CustomerOrder, CustomerOrderDto>(customerOrderEntity);
            return customerOrderModel;
        }

        public int Add(CustomerOrderDto customerOrderDto)
        {
            var customerOrderEntity = Mapper.Map<CustomerOrderDto, CustomerOrder>(customerOrderDto);
            var addCustomerOrderResult = _repo.Add(customerOrderEntity);
            return addCustomerOrderResult;
        }

        public int Update(CustomerOrderDto customerOrderDto)
        {
            var customerOrderEntity = Mapper.Map<CustomerOrderDto, CustomerOrder>(customerOrderDto);
            var updateCustomerOrderResult = _repo.Update(customerOrderEntity);
            return updateCustomerOrderResult;
        }

        public int Delete(int customerOrderID)
        {
            var deleteResult = _repo.Delete(customerOrderID);
            return deleteResult;
        }
    }
}
