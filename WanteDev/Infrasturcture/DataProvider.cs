using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WanteDev.Core.DataAccess.Abstraction;
using WanteDev.Mappers;
using WanteDev.Models;

namespace WanteDev.Infrasturcture
{
    public class DataProvider
    {
        public readonly IUnitOfWork _db;
        public DataProvider(IUnitOfWork db)
        {
            _db = db;
        }

        public List<EmployerModel> GetEmployers()
        {
            var entities = Kernel.DB.EmployerRepository.GetAll();
            var employers = new List<EmployerModel>();
            EmployerMapper employerMapper = new EmployerMapper();
            for (int i = 0; i < entities.Count; i++)
            {
                var employer = entities[i];
                var employerModel = employerMapper.Map(employer);
                employerModel.NO = i + 1;
                employers.Add(employerModel);
            }

            return employers;
        }
    }
}
