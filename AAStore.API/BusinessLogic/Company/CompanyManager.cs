using System;
using System.Collections.Generic;
using System.Data;
using AAStore.API.Model;
using AAStore.API.Repository.Company;

namespace AAStore.API.BusinessLogic.Company
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyManager(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public List<CompanyModel> GetCompany(int id)
        {
            DataSet DS = new DataSet();
            List<CompanyModel> list = new List<CompanyModel>();

            DS = _companyRepository.GetCompany(id);
            if(DS != null)
            {
                DataTable dt = DS.Tables[0];
                if(dt != null && dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        CompanyModel data = new CompanyModel();

                        data.CompanyName = dr["CompanyName"].ToString();
                        list.Add(data);
                    }
                }
            }
            return list;
        }

        public bool AddCompany(CompanyModel company)
        {
           var DS = _companyRepository.AddCompany(company);
            if(DS == null)
            {
                return false;
            } 
            return true;
        }

        public bool UpdateCompany(int id, CompanyModel company)
        {
            var DS = _companyRepository.UpdateCompany(id,company);
            if(DS == null)
            {
                return false;
            }
            return true;
        }

        public bool DeleteCompany(int id)
        {
            var DS = _companyRepository.DeleteCompany(id);
            if(DS == null)
            {
                return false;
            }
            return true;
        }
    }
}
