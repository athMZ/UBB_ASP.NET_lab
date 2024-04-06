using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Trips.DAL.Infrastructure;
using Trips.DAL.Interfaces;

namespace Trips.DAL.Services
{
	public class FileService : IFileService
	{
		private readonly PhotoServerParams _photoServerParams;

		public FileService(IOptions<PhotoServerParams> options)
		{
			_photoServerParams = options.Value;
		}

		public int WriteFile(IFormFile file)
		{
			throw new NotImplementedException();
		}

		public bool CheckIfFileExists(string path)
		{
			throw new NotImplementedException();
		}

		public void DeleteFile(string path)
		{
			throw new NotImplementedException();
		}

		public string GetFileUrl(string path)
		{
			throw new NotImplementedException();
		}

		public string GetFilePath(string fileName)
		{
			throw new NotImplementedException();
		}

	}
}
