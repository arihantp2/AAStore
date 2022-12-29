using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AAStore.API.Model;

namespace AAStore.API.Repository.Company
{
    public interface ICompanyRepository 
    {
        public DataSet GetCompany(int id);
        public DataSet AddCompany(CompanyModel company);
        public DataSet UpdateCompany(int id , CompanyModel company);
         public DataSet DeleteCompany(int id);
    }
}