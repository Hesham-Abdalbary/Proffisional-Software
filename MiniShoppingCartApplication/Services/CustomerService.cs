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
    public class CustomerService
    {
        private CustomerRepository _repo;
        public CustomerService()
        {
            _repo = new CustomerRepository();
        }

        public List<CustomerDto> GetAll()
        {
            var customers = _repo.GetAll();
            var customersModels = Mapper.Map<List<Customer>, List<CustomerDto>>(customers);
            return customersModels;
        }

        public CustomerDto GetByID(int customerID)
        {
            var customerEntity = _repo.GetByID(customerID);
            var customerModel = Mapper.Map<Customer, CustomerDto>(customerEntity);
            return customerModel;
        }

        public int Add(CustomerDto customerDto)
        {
            var customerEntity = Mapper.Map<CustomerDto, Customer>(customerDto);
            var addCustomerResult = _repo.Add(customerEntity);
            return addCustomerResult;
        }

        public int Update(CustomerDto customerDto)
        {
            var customerEntity = Mapper.Map<CustomerDto, Customer>(customerDto);
            var updateCustomerResult = _repo.Update(customerEntity);
            return updateCustomerResult;
        }

        public int Delete(int customerID)
        {
            var deleteResult = _repo.Delete(customerID);
            return deleteResult;
        }
    }
}
