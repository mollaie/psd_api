using Microsoft.AspNetCore.Mvc;
using psd_api.Dtos;
using psd_api.Services;
using psd_merge.Services;

namespace psd_api.Controllers;
[ApiController]
[Route("[controller]")]
public class PsdConvertorController : ControllerBase
{
    private readonly IMerge _merge;

    public PsdConvertorController(IMerge merge)
    {
        _merge = merge;
    }
    
    [HttpGet]
    public ActionResult Index()
    {
        return Ok("Here is the PSD Convertor");
    }

    [HttpPost]
    public async Task<ActionResult> Convert( InputMetaDto dto)
    {

        var mapper = new Mapper(dto);
        var mappedDto = await mapper.Map();
        
        var result = await _merge.ConvertToPsd(mappedDto);
        
        if (result)
            return Ok("Convertor is working");
        else
            return BadRequest("Something went wrong");
    }
}