using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Product_catalog_with_categories_Client.Models.Config;
using ProductCatalogData.Models;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Product_catalog_with_categories_Client.Services
{
    public class ProductCatalogService
    {
        private readonly IOptions<ProductcatalogwithcategoriesWebAPIConfig> _pcWebAPIConfig;

        public ProductCatalogService(IOptions<ProductcatalogwithcategoriesWebAPIConfig> pcWebAPIConfig)
        {
            _pcWebAPIConfig = pcWebAPIConfig;
        }


        public async Task<bool> AddElectronic(Electronic electronic)
        {
            return await AddItem("Electronics", electronic);
        }

        public async Task<bool> AddComputer(Computer computer)
        {
            return await AddItem("Computers", computer);
        }

        public async Task<bool> AddItem<T>(string method, T item)
        {
            using var httpClient = new HttpClient();

            httpClient.Timeout = TimeSpan.FromSeconds(5);

            //httpClient.DefaultRequestHeaders.Add("Authoreization", $"Token {_cordraConfig.value.AuthorizationToken}");
            try
            {

                var response = await httpClient.PutAsJsonAsync((string)_pcWebAPIConfig.Value.Endpoint + method, item);
                //new StringContent(jsonData), Encoding.UTF8, "application/json"));

                var responseData = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }

            }
            catch { }
            return false;
        }

        public async Task<bool> RemoveElectronic(int Id)
        {
            return await RemoveItem("Electronics", Id);
        }

        public async Task<bool> RemoveComputer(int Id)
        {
            return await RemoveItem("Computers", Id);
        }

        public async Task<bool> RemoveItem(string method, int Id)
        {
            using var httpClient = new HttpClient();

            httpClient.Timeout = TimeSpan.FromSeconds(5);

            //httpClient.DefaultRequestHeaders.Add("Authoreization", $"Token {_cordraConfig.value.AuthorizationToken}");
            try
            {

                var response = await httpClient.DeleteAsync((string)_pcWebAPIConfig.Value.Endpoint + method + "/" + Id);
                //new StringContent(jsonData), Encoding.UTF8, "application/json"));

                var responseData = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }

            }
            catch { }
            return false;
        }

        public async Task<Electronic> GetElectronic(int Id)
        {
            return await GetItem<Electronic>("Electronics", Id);
        }

        public async Task<Computer> GetComputer(int Id)
        {
            return await GetItem<Computer>("Computers", Id);
        }

        public async Task<T> GetItem<T>(string method, int Id) where T : class
        {
            using var httpClient = new HttpClient();

            httpClient.Timeout = TimeSpan.FromSeconds(10);

            //httpClient.DefaultRequestHeaders.Add("Authoreization", $"Token {_cordraConfig.value.AuthorizationToken}");
            try
            {

                var response = await httpClient.GetAsync((string)_pcWebAPIConfig.Value.Endpoint + method + "/" + Id);
                //new StringContent(jsonData), Encoding.UTF8, "application/json"));

                var responseData = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<T>(responseData);

                    return result;
                }

            }
            catch { }
            return null;
        }

        public async Task<bool> EditElectronic(Electronic electronic)
        {
            return await EditItem("Electronics", electronic);
        }

        public async Task<bool> EditComputer(Computer computer)
        {
            return await EditItem("Computers", computer);
        }

        public async Task<bool> EditItem<T>(string method, T item) where T : IItem
        {
            using var httpClient = new HttpClient();

            httpClient.Timeout = TimeSpan.FromSeconds(10);

            //httpClient.DefaultRequestHeaders.Add("Authoreization", $"Token {_cordraConfig.value.AuthorizationToken}");
            try
            {

                var response = await httpClient.PostAsJsonAsync((string)_pcWebAPIConfig.Value.Endpoint + method + "/" + item.Id, item);
                //new StringContent(jsonData), Encoding.UTF8, "application/json"));

                var responseData = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }

            }
            catch { }
            return false;
        }

        public async Task<List<Electronic>> GetElectronics()
        {
            return await GetAll<Electronic>("Electronics");
        }

        public async Task<List<Computer>> GetComputers()
        {
            return await GetAll<Computer>("Computers");
        }

        public async Task<List<T>> GetAll<T>(string method)
        {
            using var httpClient = new HttpClient();

            httpClient.Timeout = TimeSpan.FromSeconds(10);

            //httpClient.DefaultRequestHeaders.Add("Authoreization", $"Token {_cordraConfig.value.AuthorizationToken}");
            try
            {

                var response = await httpClient.GetAsync((string)_pcWebAPIConfig.Value.Endpoint + method);
                //new StringContent(jsonData), Encoding.UTF8, "application/json"));

                var responseData = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<List<T>>(responseData);

                    return result;
                }

            }
            catch { }
            return null;
        }

    }
}
