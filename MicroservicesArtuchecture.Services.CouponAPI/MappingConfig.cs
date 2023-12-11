using AutoMapper;
using MicroservicesArtuchecture.Services.CouponAPI.Models.Contracts;
using MicroservicesArtuchecture.Services.CouponAPI.Models.Entities;

namespace MicroservicesArtuchecture.Services.CouponAPI
{
    public  class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponContract,CouponEntity>();
                config.CreateMap<CouponEntity, CouponContract>();
            });
            return mappingConfig;
        }
    }
}
