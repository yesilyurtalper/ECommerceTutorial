using System.Text;
using ECommerce.Web.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using static ECommerce.Web.StaticData;

namespace ECommerce.Web.Services
{
    public class ItemService : BaseService, IItemService 
    {
        public ItemService(IHttpClientFactory httpFactory) : base(httpFactory, StaticData.APIClient.ItemAPI)
        {
        }

        public async Task<Tout> GetAsync<Tout>(string relativeUrl, string accessToken)
        {
            return await SendAsync<Tout>(new ApiRequest
            {
                ApiMethod = StaticData.APIMethod.GET,
                RelativeUrl = relativeUrl,
                AccessToken = accessToken
            });
        }

        public async Task<Tout> CreateItemAsync<Tout,Tin>(string relativeUrl, Tin item, string accessToken)
        {
            return await SendAsync<Tout>(new ApiRequest
            {
                ApiMethod = StaticData.APIMethod.PUT,
                Data = item,
                RelativeUrl = relativeUrl,
                AccessToken = accessToken
            });
        }

        public async Task<Tout> DeleteItemAsync<Tout>(string relativeUrl, int id, string accessToken)
        {
            return await SendAsync<Tout>(new ApiRequest
            {
                ApiMethod = StaticData.APIMethod.DELETE,
                RelativeUrl = relativeUrl,
                Data = id,
                AccessToken = accessToken
            });
        }  

        public async Task<Tout> UpdateItemAsync<Tout,Tin>(string relativeUrl, Tin item, string accessToken)
        {
            return await SendAsync<Tout>(new ApiRequest
            {
                ApiMethod = StaticData.APIMethod.POST,
                RelativeUrl = relativeUrl,
                Data = item,
                AccessToken = accessToken
            });
        }
    }
}
