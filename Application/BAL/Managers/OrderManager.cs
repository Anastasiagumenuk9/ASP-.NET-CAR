using AutoMapper;
using BAL.Interfaces;
using MODELS.DB;
using MODELS.Interfaces;
using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Managers
{
    public class OrderManager : GenericManager, IOrderManager
    {
        public OrderManager(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork, mapper)
        {

        }

        public void Delete(int id)
        {
            Order order = unitOfWork.Orders.GetById(id);
            unitOfWork.Orders.Delete(order);
            unitOfWork.Save();
        }

        public OrderViewModel GetById(int id)
        {
            Order order = unitOfWork.Orders.GetById(id);
            return mapper.Map<Order, OrderViewModel>(order);

        }

        public IEnumerable<OrderViewModel> GetOrders()
        {
            IEnumerable<Order> orders = unitOfWork.Orders.GetAll();
            return mapper.Map<IEnumerable<Order>, List<OrderViewModel>>(orders);
            
        }

        public void Insert(OrderViewModel item)
        {
            Order order = mapper.Map<OrderViewModel, Order>(item);
            unitOfWork.Orders.Insert(order);
            unitOfWork.Save();
        }

        public void Update(OrderViewModel item)
        {
            Order order = mapper.Map<OrderViewModel, Order>(item);
            unitOfWork.Orders.Update(order);
            unitOfWork.Save();
        }
    }
}
