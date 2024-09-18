using System;
using McfApi.DTOs;
using McfApi.Exceptions;
using McfApi.Models;
using McfApi.Repositories;

namespace McfApi.Services
{
    public class BPKBService : IBPKBService
    {
        private readonly IBPKBRepository _repository;
        private readonly IPersistence _persistence;
        private readonly IUserService _userService;

        public BPKBService(IBPKBRepository repository, IPersistence persistence, IUserService userService)
        {
            _repository = repository;
            _persistence = persistence;
            _userService = userService;
        }

        public async Task<int> CreateDataBpkb(BPKBDto entity)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                var userData = await _userService.GetUserById(entity.user_id);
                var data = new BPKBModel
                {
                    agreement_number = entity.agreement_number,
                    branch_id = entity.branch_id,
                    bpkb_no = entity.bpkb_no,
                    bpkb_date_in = entity.bpkb_date_in,
                    bpkb_date = entity.bpkb_date,
                    faktur_no = entity.faktur_no,
                    faktur_date = entity.faktur_date,
                    police_no = entity.police_no,
                    location_id = entity.location_id,
                    created_by = userData.user_name, // pakai user_name
                    created_on = Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd HH:mm:ss")),
                };

                var result = await _repository.SaveAsync(data);
                if (result == null)
                {
                    throw new Exception("Error Insert Data");
                }
                var response = await _persistence.SaveChangesAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BPKBModel> GetBpkbByAgreementNumber(int agreement_number)
        {
            var result = await _repository.FindByIdAsync(agreement_number);

            return result;
        }

        public async Task<IEnumerable<BPKBModel>> GetListBpkb()
        {
            var result = await _repository.FindAllAsync();

            if (result.Count == 0)
            {
                return Enumerable.Empty<BPKBModel>();
            }

            return result;
        }

        public async Task<int> UpdateDataBpkb(BPKBDto entity)
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                var userData = await _userService.GetUserById(entity.user_id);
                var currentBpkb = await _repository.FindByIdAsync(entity.agreement_number);

                if (currentBpkb == null)
                {
                    throw new NotFoundException("Not Found Data");
                }

                currentBpkb.agreement_number = entity.agreement_number;
                currentBpkb.branch_id = entity.branch_id;
                currentBpkb.bpkb_no = entity.bpkb_no;
                currentBpkb.bpkb_date_in = entity.bpkb_date_in;
                currentBpkb.bpkb_date = entity.bpkb_date;
                currentBpkb.faktur_no = entity.faktur_no;
                currentBpkb.faktur_date = entity.faktur_date;
                currentBpkb.police_no = entity.police_no;
                currentBpkb.location_id = entity.location_id;
                currentBpkb.last_updated_by = userData.user_name; // pakai user_name
                currentBpkb.last_updated_on = Convert.ToDateTime(dateTime.ToString("yyyy-MM-dd HH:mm:ss"));

                var result = _repository.Update(currentBpkb);
                if (result == null)
                {
                    throw new Exception("Error Update Data");
                }
                var response = await _persistence.SaveChangesAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

