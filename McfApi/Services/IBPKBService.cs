using System;
using McfApi.DTOs;
using McfApi.Models;

namespace McfApi.Services
{
	public interface IBPKBService
	{
		Task<int> CreateDataBpkb(BPKBDto entity);
		Task<int> UpdateDataBpkb(BPKBDto entity);
		Task<IEnumerable<BPKBModel>> GetListBpkb();
		Task<BPKBModel> GetBpkbByAgreementNumber(int agreement_number);
    }
}

