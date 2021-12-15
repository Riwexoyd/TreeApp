using System;
using System.Threading.Tasks;

using TreeApp.ApplicationServices.Models;
using TreeApp.Entities.Models;

namespace TreeApp.ApplicationServices.Services
{
    public interface ITreeService
    {
        Task<byte[]> GetTreeImageContent(Guid id);

        Task<TreeInfoModel> GetUserMainTreeInfo(string userName);
    }
}
