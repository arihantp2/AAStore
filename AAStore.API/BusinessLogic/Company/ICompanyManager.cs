using System;
using AAStore.API.Model;

namespace AAStore.API.BusinessLogic.Company
{
    public interface ICompanyManager
    {
        public List<CompanyModel> GetCompany(int id);
        public bool AddCompany(CompanyModel company);
        public bool UpdateCompany(int id, CompanyModel company);
        public bool DeleteCompany(int id);
          
    }
}