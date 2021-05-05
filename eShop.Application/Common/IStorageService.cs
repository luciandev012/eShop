using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Application.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);
        Task SaveFileAsync(Stream meadiaBinaryStream, string fileName);
        Task DeleteFileAsynce(string fileName);
    }
}
