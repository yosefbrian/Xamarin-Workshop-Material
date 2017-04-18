using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ta_2.Data
{
    public class MovieManager
    {
        IRestService restService;

        public MovieManager(IRestService service)
        {
            restService = service;
        }

        public Task<List<Movie>> GetTasksAsync()
        {
            return restService.RefreshDataAsync();
        }
    }
}
