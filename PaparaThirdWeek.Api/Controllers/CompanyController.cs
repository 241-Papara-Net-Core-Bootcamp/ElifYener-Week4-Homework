using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaparaThirdWeek.Domain.Entities;
using PaparaThirdWeek.Services.Abstracts;
using PaparaThirdWeek.Services.Concretes;
using PaparaThirdWeek.Services.DTOs;
using System;
using System.Threading.Tasks;

namespace PaparaThirdWeek.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            this.companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet("Companies")]
        public async Task<IActionResult> GetAll()
        {
            var result = await companyService.GetAll();
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await companyService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CompanyDto companyDto)
        {
            var mappedModel = _mapper.Map<Company>(companyDto);
            mappedModel.CreatedBy = "Elif";
            mappedModel.CreatedDate = System.DateTime.Now;
            
            await companyService.Add(mappedModel);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompanyDto companyDto, int id)
        {
            var mappedModel = _mapper.Map<Company>(companyDto);
            mappedModel.LastUpdateAt = System.DateTime.Now;

            await companyService.Update(mappedModel, id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await companyService.Delete(id);
            return Ok();
        }
    }
}
