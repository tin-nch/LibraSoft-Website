using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LibraSoftSolution.API.Utilities;
using System.IO;
using LibraSoftSolution.ViewModels.ContactForm;
using LibraSoftSolution.Models;

namespace LibraSoftSolution
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public string _baseAddress = SettingUrl.GetBaseAddress();
        protected BaseApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            //var sessions = _httpContextAccessor
            //    .HttpContext
            //    .Session
            //    .GetString(SystemConstants.AppSettings.Token);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_baseAddress);

            HttpResponseMessage response;
            string body;
            try
            {
                response = await client.GetAsync(url);
            }
            catch (Exception)
            {
                Object bodyOB = new { ErrorCode = 1, Content = "" };
                body = JsonConvert.SerializeObject(bodyOB);
                return JsonConvert.DeserializeObject<TResponse>(body);
            }

            body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(body,
                typeof(TResponse));

                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }

        public async Task<List<T>> GetListAsync<T>(string url, bool requiredLogin = false)
        {
            //var sessions = _httpContextAccessor
            //   .HttpContext
            //   .Session
            //   .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(url);
            var body = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = (List<T>)JsonConvert.DeserializeObject(body, typeof(List<T>));
                return data;
            }
            throw new Exception(body);
        }

        protected async Task<TResponse> AddAsync<TResponse, T>(string url, T data)
        {
            //var sessions = _httpContextAccessor
            //    .HttpContext
            //    .Session
            //    .GetString(SystemConstants.AppSettings.Token);

            string json = JsonConvert.SerializeObject(data);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();        
            client.BaseAddress = new Uri(_baseAddress);                                                               
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            HttpResponseMessage response;
            string body;
            try
            {
                response = await client.PostAsync(url, httpContent);
            }
            catch (Exception)
            {
                Object bodyOB = new { ErrorCode = 1, Content = "" };
                body = JsonConvert.SerializeObject(bodyOB);
                return JsonConvert.DeserializeObject<TResponse>(body);
            }

            body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                TResponse myDeserializedObjList = (TResponse)JsonConvert.DeserializeObject(body,
                typeof(TResponse));

                return myDeserializedObjList;
            }
            return JsonConvert.DeserializeObject<TResponse>(body);
        }

        protected async Task<RequestResponse> AddFileAsync(string url, IFormFile file)
        {
            //var sessions = _httpContextAccessor
            //    .HttpContext
            //    .Session
            //    .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_baseAddress);

            string body;
            HttpResponseMessage response;
            if (file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    //Get the file steam from the multiform data uploaded from the browser
                    await file.CopyToAsync(memoryStream);

                    //Build an multipart/form-data request to upload the file to Web API
                    using var form = new MultipartFormDataContent();
                    using var fileContent = new ByteArrayContent(memoryStream.ToArray());
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    form.Add(fileContent, "file", file.FileName);

                    response = await client.PostAsync(url, form);

                    body = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        RequestResponse myDeserializedObjList = (RequestResponse)JsonConvert.DeserializeObject(body,
                typeof(RequestResponse));

                        return myDeserializedObjList;
                    }
                }
            }
            RequestResponse obj = new RequestResponse() {
                ErrorCode = ErrorCode.GeneralFailure,
                Content = "Error"
            };
            return obj;
        }

        public async Task<bool> Delete(string url)
        {
            //var sessions = _httpContextAccessor
            //   .HttpContext
            //   .Session
            //   .GetString(SystemConstants.AppSettings.Token);
            var client = _httpClientFactory.CreateClient();
            //client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
