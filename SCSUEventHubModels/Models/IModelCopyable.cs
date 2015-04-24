using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCSUEventHubModels.Models
{
    public interface IModelCopyable<T>
    {
        void CopyAttributes(T other);
    }
}
