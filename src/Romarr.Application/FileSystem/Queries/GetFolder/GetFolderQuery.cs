using ErrorOr;
using MediatR;
using Romarr.Application.FileSystem.Queries.Common;

namespace Romarr.Application.FileSystem.Queries.GetFolder;

 public record GetFolderQuery(string Path) : IRequest<ErrorOr<List<Folder>>>;