using PrintDocument.Core.Entities;

namespace PrintDocument.Core.Interface
{
    public interface IJwtUtilities
    {
        string GenerateJwtToken(User user);
    }
}
