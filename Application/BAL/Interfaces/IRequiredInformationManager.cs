using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface IRequiredInformationManager
    {
        RequiredInformationViewModel GetById(int id);


        IEnumerable<RequiredInformationViewModel> GetRequiredInformation();

        void Insert(RequiredInformationViewModel item);

        void Update(RequiredInformationViewModel item);

        void Delete(int id);
    }
}
