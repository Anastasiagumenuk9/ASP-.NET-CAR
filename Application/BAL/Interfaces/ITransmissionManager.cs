using MODELS.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interfaces
{
    public interface ITransmissionManager
    {
        TransmissionViewModel GetById(int id);


        IEnumerable<TransmissionViewModel> GetTransmissions();

        void Insert(TransmissionViewModel item);

        void Update(TransmissionViewModel item);

        void Delete(int id);
    }
}
