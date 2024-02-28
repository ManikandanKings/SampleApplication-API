using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SampleApplication_API.Data;
using SampleApplication_API.Models.Domain;
using SampleApplication_API.Models.DTO;
using SampleApplication_API.Repository;
using System.Collections.Generic;

namespace SampleApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly SampleDBContext dbContext;
        private readonly IRegion regionRepository;
        private readonly IMapper mapper;

        public RegionController(SampleDBContext dbContext,IRegion region,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = region;
            this.mapper = mapper;
        }

      

        //Implement all in those logics in controller itself
        //[HttpGet]
        //public async Task<IActionResult> GetAllRegion()
        //{
        //    var regions = await dbContext.Region.ToListAsync();

        //    //Map domain modals to DTO
        //    var regionDto = new List<RegionResponseDto>();
        //    foreach (var region in regions)
        //    {
        //        regionDto.Add(new RegionResponseDto()
        //        {
        //            Id = region.Id,
        //            Name = region.Name
        //        });
        //    }

        //    return Ok(regionDto);//Return DTO to client

        //}

        //Using Repos to get all region info
        [HttpGet]
        public async Task<IActionResult> GetAllRegionAsync()
        {
            var regions = await regionRepository.GetAllRegionsAsync();//use repos

            //Map domain modals to DTO
            //var regionDto = new List<RegionResponseDto>();
            //foreach (var region in regions)
            //{
            //    regionDto.Add(new RegionResponseDto()
            //    {
            //        Id = region.Id,
            //        Name = region.Name
            //    });
            //}

            //use automapper instead of iteration
            var regionDto = mapper.Map<List<RegionResponseDto>>(regions);


            return Ok(regionDto);//Return DTO to client
        }

        //get single id

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegion([FromRoute] Guid id)
        {           
            var regions =  await regionRepository.GetRegionByIdAsync(id);//use repos

            if (regions == null)
            {
                return NoContent();
            }

            //var regionDto = new RegionResponseDto
            //{

            //    Id = regions.Id,
            //    Name = regions.Name
            //};
            var regionDto = mapper.Map<RegionResponseDto>(regions);
            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] RegionRequestDto regionRequestDto)
        {
            var regionresult = await regionRepository.CreateRegionAsync(regionRequestDto);

            return Ok(regionresult);

        }

        [HttpPut]
        [Route("{id:guid}")]
        public  async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] RegionRequestDto regionRequestDto)
        {

            var region = await regionRepository.UpdateRegionAsync(id,regionRequestDto);//Use repos

            if (region == null)
            {
                return NotFound();
            }
          
            return Ok(region);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var region = await regionRepository.DeleteRegionAsync(id);
            if (region == null)
            {
                return NotFound();
            }
           
            return Ok(region);
        }

    }
}
