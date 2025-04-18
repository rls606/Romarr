namespace Romarr.Application.Common.Interfaces;

public interface IFileSystemService
{
    Task<List<DriveInfo>> GetMountedDrives();

    List<DirectoryInfo> GetDirectories(string path);
}