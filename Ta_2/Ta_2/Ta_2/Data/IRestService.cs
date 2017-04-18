using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ta_2.Data
{
    public interface IRestService
    {
        Task<List<Movie>> RefreshDataAsync();
    }
}
