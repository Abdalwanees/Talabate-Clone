using AutoMapper;
using Talabate.Clone.API.DTOs;
using Microsoft.Extensions.Configuration;
using Talabate.Clone.Core.Entites;

namespace Talabate.Clone.API.Helpers
{
    public class PictureUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;
        private const string ApiBaseUrlKey = "ApiBaseUrl";

        public PictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            return !string.IsNullOrEmpty(source.PictureUrl)
                ? $"{_configuration[ApiBaseUrlKey]}/{source.PictureUrl}"
                : string.Empty;
        }
    }
}
