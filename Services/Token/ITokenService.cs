using Eureka.Models;

namespace Eureka.Api.Services.Auth;

public interface ITokenService
{
    string GenerateToken(Candidate candidate);
}