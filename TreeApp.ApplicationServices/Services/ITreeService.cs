using System;
using System.Threading.Tasks;

namespace TreeApp.ApplicationServices.Services
{
    public interface ITreeService
    {
        Task<byte[]> GetTreeImageContent(Guid id);

        Task<double> GetTreeHeight(Guid id);
    }
}
