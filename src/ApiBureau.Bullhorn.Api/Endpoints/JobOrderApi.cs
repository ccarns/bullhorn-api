﻿using ApiBureau.Bullhorn.Api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBureau.Bullhorn.Api.Endpoints
{
    public class JobOrderApi
    {
        private readonly BullhornClient _bullhornApi;
        public static readonly string DefaultFields = "id,dateAdded,dateLastModified,status,title,source,owner,isOpen,isDeleted,clientContact,clientCorporation";

        public JobOrderApi(BullhornClient bullhornApi) => _bullhornApi = bullhornApi;

        public async Task<JobOrderDto> GetAsync(int id, string? fields = null)
        {
            var query = $"JobOrder/{id}?fields={fields ?? DefaultFields}";

            return await _bullhornApi.EntityAsync<JobOrderDto>(query);
        }

        public async Task<List<JobOrderDto>> GetAsync(List<int> ids, string? fields = null)
        {
            if (ids.Count == 1)
                return new List<JobOrderDto> { await GetAsync(ids[0], fields ?? DefaultFields) };

            var query = $"JobOrder/{string.Join(",", ids)}?fields={fields ?? DefaultFields}";

            return await _bullhornApi.EntityAsync<List<JobOrderDto>>(query);
        }

        public async Task<List<JobOrderDto>> GetNewAndUpdatedFromAsync(long timestampFrom)
        {
            var query = $"JobOrder?fields={DefaultFields}&where=dateAdded>{timestampFrom} OR dateLastModified>{timestampFrom}";

            return await _bullhornApi.QueryAsync<JobOrderDto>(query);
        }
    }
}
