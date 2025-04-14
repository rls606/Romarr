using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Romarr.Api.Controllers;

[Route("api/fileSystem")]
public class FileSystemController(ISender _mediator) : ApiController
{
    [HttpGet]
    public async Task<IActionResult> getFolders(string path)
    {
        throw new NotImplementedException();
    }
}