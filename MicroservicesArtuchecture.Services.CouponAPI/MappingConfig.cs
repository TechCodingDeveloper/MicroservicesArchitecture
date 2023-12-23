using AutoMapper;
using MicroservicesArtuchecture.Services.CouponAPI.Storage.Contracts;
using MicroservicesArtuchecture.Services.CouponAPI.Storage.Entities;

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
