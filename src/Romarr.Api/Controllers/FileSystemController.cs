using MediatR;
using Microsoft.AspNetCore.Mvc;
using Romarr.Application.FileSystem.Queries.GetFolder;

namespace Romarr.Api.Controllers;

[Route("api/fileSystem")]
public class FileSystemController(ISender _mediator) : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetFolders(string path = "")
    {
        var result = await _mediator.Send(new GetFolderQuery(path));
        return result.Match(
            folder => Ok(folder),
            Problem);
    }
}