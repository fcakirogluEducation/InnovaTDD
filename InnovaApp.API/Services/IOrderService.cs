using InnovaApp.API.Repositories;
using System.Threading.Tasks;

namespace InnovaApp.API.Services
{
    public interface IOrderService
    {
        Task CreateOrder(Order order);
    }
}