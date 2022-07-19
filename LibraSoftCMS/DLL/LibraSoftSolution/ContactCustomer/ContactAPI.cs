using LibraSoftSolution.API.Utilities;
using LibraSoftSolution.Models;
using LibraSoftSolution.ViewModels.ContactForm;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using LibraSoftSolution.ViewModels.Candidate_CV;

namespace LibraSoftSolution.API.ContactCustomer
{
    public class ContactAPI : BaseApiClient, IContactAPI
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactAPI(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> AddContactForm(ContactVM contact)
        {
            var body = await AddAsync<RequestResponse, ContactVM>("api/contactform/add", contact);

            return body.Content;
        }

        public async Task<bool> AddCvForm(CandidateFormVM curriculumVitae)
        {
            var body = await AddAsync<RequestResponse, CandidateFormVM>("api/applicationform/add", curriculumVitae);


            return OutPutApi.OutPutBool<bool>(body);
        }

        //public class FileUploadResult
        //{
        //    public string fileUrl { get; set; }
        //}
        public async Task<RequestResponse> AddFile(IFormFile file)
        {
            var body = await AddFileAsync("api/applicationform/upload", file);

            return body;
        }

        public async Task<List<ContactVM>> GetContacts()
        {
            var body = await GetAsync<RequestResponse>("api/contactform");

            return OutPutApi.OutPut<ContactVM>(body);
        }

        public async Task<bool> AddCandidate(CandidateVM candidate)
        {
            var body = await AddAsync<RequestResponse, CandidateVM>("api/applicationform/add", candidate);

            return OutPutApi.OutPutBool<bool>(body);
        }
    }
}
