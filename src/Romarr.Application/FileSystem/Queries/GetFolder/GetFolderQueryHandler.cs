using ErrorOr;

using MediatR;

using Romarr.Application.Common.Interfaces;
using Romarr.Application.FileSystem.Queries.Common;

namespace Romarr.Application.FileSystem.Queries.GetFolder
{
    public class GetFolderQueryHandler(IFileSystemService fileSystemService) : IRequestHandler<GetFolderQuery, ErrorOr<List<Folder>>>
    {
        public Task<ErrorOr<List<Folder>>> Handle(GetFolderQuery request, CancellationToken cancellationToken)
        {
            var result = new List<Folder>();
            var path = request.Path;

            if (string.IsNullOrEmpty(request.Path))
            {
                path = "/";
            }

            if (Directory.Exists(path) == false)
            {
                return Task.FromResult<ErrorOr<List<Folder>>>(Error.NotFound(description: $"Path : '{path}' not exist."));
            }

            var folder = fileSystemService.GetDirectories(path).Select(e => new Folder(e.Name)).ToList();

            return Task.FromResult(ErrorOrFactory.From(folder));
        }
    }
}
