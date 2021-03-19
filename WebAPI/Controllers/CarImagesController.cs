using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {

        ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] ImageFile imageFile , [FromForm] CarImage carImage)
        {

            var result = _carImageService.Add(imageFile, carImage);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] ImageFile imageFile ,[FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(imageFile,carImage);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("getbycarid")]
        public IActionResult GetByCarId([FromForm]int carId)
        {
            var result = _carImageService.GetByCarId(carId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpGet("getcarimagepathbycarid")]
        public IActionResult GetCarImagePathByCarId(int carId)
        {
            var result = _carImageService.GetCarImageByCarId(carId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpPost("getbyid")]
        public IActionResult GetById([FromForm] int id)
        {
            var result = _carImageService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        


    }
}
