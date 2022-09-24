﻿using ApiBureau.Bullhorn.Api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBureau.Bullhorn.Api.Endpoints
{
    public class CorporationUserApi
    {
        private readonly BullhornClient _bullhornApi;

        public CorporationUserApi(BullhornClient bullhornApi) => _bullhornApi = bullhornApi;

        /// <summary>
        /// Returns all users
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserDto>> GetAsync()
        {
            const string query = "CorporateUser?fields=id,firstName,lastName,name,isDeleted,departments&where=id>0";

            return await _bullhornApi.QueryAsync<UserDto>(query);
        }
    }
}
