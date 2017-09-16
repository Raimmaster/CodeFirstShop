using CodeFirstEmployee.models;
using Newtonsoft.Json;
using Services.Repositories;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;

namespace ShopApi.controllers
{
    public class EmployeeTypeController : Controller
    {
        private readonly IRepository<EmployeeType> _typeRepository;

        public EmployeeTypeController(IRepository<EmployeeType> repository)
        {
            this._typeRepository = repository;
        }

        public HttpResponseMessage Post(EmployeeType type)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            _typeRepository.InsertEntity(type);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }

        public HttpResponseMessage Delete(EmployeeType type)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            _typeRepository.DeleteEntity(type);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }


        public HttpResponseMessage Put(EmployeeType type)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));

            _typeRepository.UpdateEntity(type);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }

        public HttpResponseMessage GetAll()
        {
            var types = _typeRepository.GetAllEntities();
            var json = JsonConvert.SerializeObject(types.ToList(), Formatting.Indented,
                new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.None,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }
                );
            var response = new HttpResponseMessage(HttpStatusCode.OK);// { Content = new StringContent(json.ToString()) };
            response.Content = new StringContent(json.ToString(), System.Text.Encoding.UTF8, "application/json");
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return response;
        }

        public HttpResponseMessage Get(int id)
        {
            var type = _typeRepository.GetById(id);
            var json = JsonConvert.SerializeObject(type, Formatting.Indented);
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(json);

            return response;
        }
    }
}