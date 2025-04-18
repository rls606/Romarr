using Romarr.Application.Common.Interfaces;

namespace Romarr.Infrastructure.Services;

public class FileSystemService : IFileSystemService
{
    // Not useful on Linux, but we need to implement this interface for the Windows version.
    public Task<List<DriveInfo>> GetMountedDrives()
    {
        return Task.Run(() => DriveInfo.GetDrives().Where(d => d.IsReady).Where(d => d.DriveType == DriveType.Fixed || d.DriveType == DriveType.Network || d.DriveType == DriveType.Removable).ToList());
    }

    public List<DirectoryInfo> GetDirectories(string path)
    {
        try
        {
            var directories = new DirectoryInfo(path).GetDirectories()
                                                       .OrderBy(d => d.Name)
                                                       .ToList();

            return directories;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new List<DirectoryInfo>();
    }
}