using Microsoft.AspNetCore.Http;

namespace Trips.DAL.Interfaces;

public interface IFileService
{
	public int WriteFile(IFormFile file);
	public bool CheckIfFileExists(string path);
	public void DeleteFile(string path);
	public string GetFileUrl(string path);
	public string GetFilePath(string fileName);

}