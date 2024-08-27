using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async  IEnumerable<CompanyDto> GetAll()
        {
            var items = await _companyService.GetAllCompanies();
            return _mapper.Map<IEnumerable<CompanyDto>>(items);
        }

       

        // POST api/<controller>
        public async IHttpActionResult Post([FromBody] CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return BadRequest("Company data is null.");
            }

            try
            {
                var company = await _mapper.Map<Company>(companyDto);
                _companyService.AddCompany(company);
                return CreatedAtRoute("DefaultApi", new { id = company.CompanyCode }, companyDto);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/<controller>/5
        public async IHttpActionResult Put(string companyCode, [FromBody] CompanyDto companyDto)
        {
            if (companyDto == null || companyCode != companyDto.CompanyCode)
            {
                return BadRequest("Invalid company data.");
            }

            try
            {
                var existingCompany = _companyService.GetCompanyByCode(companyCode);
                if (existingCompany == null)
                {
                    return NotFound();
                }

                var updatedCompany = await _mapper.Map(companyDto, existingCompany);
                await _companyService.UpdateCompany(updatedCompany);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<controller>/5
        public async IHttpActionResult Delete(string companyCode)
        {
            try
            {
                var company = await _companyService.GetCompanyByCode(companyCode);
                if (company == null)
                {
                    return NotFound();
                }

                await _companyService.DeleteCompany(companyCode);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


    }
}