using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;

namespace Assignment_8
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            // Add map creation statements here
            // Mapper.CreateMap< FROM , TO >();

            // Disable AutoMapper v4.2.x warnings
#pragma warning disable CS0618

            // AutoMapper create map statements

            Mapper.CreateMap<Models.RegisterViewModel, Models.RegisterViewModelForm>();

            //Category Mappers
            Mapper.CreateMap<Models.Category, Controllers.Category_vm>();
            Mapper.CreateMap<Controllers.Category_vm, Models.Category>();

            //Product Mappers
            Mapper.CreateMap<Models.Product, Controllers.Product_vm>();
            Mapper.CreateMap<Controllers.Product_vm, Models.Product>();

            //Promotion Mappers
            Mapper.CreateMap<Controllers.Promotion_vm, Models.Promotion>();
            Mapper.CreateMap<Models.Promotion, Controllers.Promotion_vm>();
            Mapper.CreateMap<Controllers.PromotionAddForm, Controllers.Promotion_vm>();
            Mapper.CreateMap<Controllers.Promotion_vm, Controllers.PromotionDeleteForm>();
            Mapper.CreateMap<Controllers.Promotion_vm, Controllers.PromotionEditForm>();
            Mapper.CreateMap<Controllers.Promotion_vm, Controllers.PromotionDetailsPage>();

            //Account Mappers
            Mapper.CreateMap<Models.ApplicationUser, Controllers.ApplicationUserBase>();
            Mapper.CreateMap<Controllers.UserAccount, Controllers.ApplicationUserDetail>();
            Mapper.CreateMap<Controllers.ApplicationUserDetail, Controllers.ApplicationUserEditForm>();
            Mapper.CreateMap<Controllers.ApplicationUserEdit, Controllers.ApplicationUserDetail>();



#pragma warning restore CS0618
        }
    }
}