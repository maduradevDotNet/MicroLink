using Microlink.Front.Models;

namespace Microlink.Front.Service.IService
{
    public interface IBaseService
    {
       Task<ResponseDto?> SendRequest(RequestDto requestDto);
    }
}
