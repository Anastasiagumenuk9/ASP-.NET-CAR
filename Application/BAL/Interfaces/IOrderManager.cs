using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface IOrderManager
    {
        OrderViewModel GetById(int id);


        IEnumerable<OrderViewModel> GetOrders();

        void Insert(OrderViewModel item);

        void Update(OrderViewModel item);

        void Delete(int id);
    }
}
