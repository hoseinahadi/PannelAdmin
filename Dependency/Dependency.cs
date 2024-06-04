using Business.IMP;
using BusinessServices.Services;
using DataAccess.Repositories;
using DataAccessServices.Services;
using DomainModel.Models.Context;
using Framework.Helper;
using Framework.Password;
using Framework.Token;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using ConfigurationManager = Microsoft.Extensions.Configuration.ConfigurationManager;

namespace Dependency
{
    public static class Dependency
    {
        public static void dependency(IServiceCollection services,ConfigurationManager configuration)
        {


            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(30);
                opt.Cookie.HttpOnly = true;
                opt.Cookie.IsEssential = true;
            });





            services.AddHttpContextAccessor();

            services.AddSingleton<IHttpContextAccessor,
                HttpContextAccessor>();

            services.AddHsts(op =>
            {
                op.MaxAge = TimeSpan.FromDays(365);
                op.IncludeSubDomains = true;
            });


            
            //services.AddCors(option =>
            //{

            //    option.AddDefaultPolicy(builder =>
            //    {
            //        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            //    });
            //});




            services.Configure<CookiePolicyOptions>(option =>
            {
                option.ConsentCookie.IsEssential = true;
                option.CheckConsentNeeded = (context => true);
                option.MinimumSameSitePolicy = SameSiteMode.None;

            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
            {
                option.LoginPath = new PathString("/Account/Login");
                option.LogoutPath = new PathString("/Account/Logout");
                //option.AccessDeniedPath = new PathString("/");

            });


            services.AddHttpContextAccessor();

            var secretKey = configuration.GetValue<string>("TokenKey");
            var tokenTimeOut = configuration.GetValue<int>("TokenTimeOut");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;


                var key = System.Text.Encoding.UTF8.GetBytes(secretKey);
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.FromMinutes(tokenTimeOut),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });









            services.AddTransient<IAccessRepository, AccessRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICarrierRepository, CarrierRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IConnectionRepository, ConnectionRepository>();
            services.AddTransient<IContactUsRepository, ContactUsRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IDeliveryRepository, DeliveryRepository>();
            services.AddTransient<IDiscountRepository, DiscountRepository>();
            services.AddTransient<IFeatureRepository, FeatureRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<IGuestUserRepository, GuestUserRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IOpSystemRepository, OpSystemRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderReturnRepository, OrderReturnRepository>();
            services.AddTransient<IPageRepository, PageRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProjectActionRepository, ProjectActionRepository>();
            services.AddTransient<IProjectControllerRepository, ProjectControllerRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ITaxRepository, TaxRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWebBrowserRepository, WebBrowserRepository>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<ICategoryDiscountRepository, CategoryDiscountRepository>();
            services.AddTransient<IGenerateNewToken, GenerateToken>();
            services.AddTransient<ICategoryDiscountRepository, CategoryDiscountRepository>();
            services.AddTransient<ICategoryFeatureRepository, CategoryFeatureRepository>();
            services.AddTransient<ICountryDiscountRepository, CountryDiscountRepository>();
            services.AddTransient<IEmployeeDiscountRepository, EmployeeDiscountRepository>();
            services.AddTransient<IEmployeeMessageRepository, EmployeeMessageRepository>();
            services.AddTransient<IGuestUserMessageRepository, GuestUserMessageRepository>();
            services.AddTransient<IOrderDiscountRepository, OrderDiscountRepository>();
            services.AddTransient<IOrderMessageRepository, OrderMessageRepository>();
            services.AddTransient<IOrderReturnMessageRepository, OrderReturnMessageRepository>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductDiscountRepository, ProductDiscountRepository>();
            services.AddTransient<IProductFeatureRepository, ProductFeatureRepository>();
            services.AddTransient<IProductOrderReturnRepository, ProductOrderReturnRepository>();
            services.AddTransient<IProductSupplierRepository, ProductSupplierRepository>();
            services.AddTransient<ISupplierImageRepository, SupplierImageRepository>();
            services.AddTransient<IUserDiscountRepository, UserDiscountRepository>();
            services.AddTransient<IUserFavoriteRepository, UserFavoriteRepository>();
            services.AddTransient<IUserMessageRepository, UserMessageRepository>();
            services.AddTransient<IProductCartRepository, ProductCartRepository>();
            services.AddTransient<IOrderProductRepository, OrderProductRepository>();
            services.AddTransient<IConversationRepository, ConversationRepository>();
            services.AddTransient<IConversationMessageRepository, ConversationMessageRepository>();
            services.AddTransient<IUserConversationRepository, UserConversationRepository>();
            //services.AddTransient<IChatRoomRepository, ChatRoomRepository>();

            

            

            services.AddScoped<CustomAuthenticator>();
            services.AddScoped<IAccessBusiness, AccessBusiness>();
            services.AddScoped<IAddressBusiness, AddressBusiness>();
            services.AddScoped<ICarrierBusiness, CarrierBusiness>();
            services.AddScoped<ICartBusiness, CartBusiness>();
            services.AddScoped<ICategoryBusiness, CategoryBusiness>();
            services.AddScoped<IImageBusiness, ImageBusiness>();
            services.AddScoped<IEmployeeBusiness, EmployeeBusiness>();
            services.AddScoped<IProductBusiness, ProductBusiness>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IConnectionBusiness, ConnectionBusiness>();
            services.AddScoped<IAccountApplication, AccountApplication>();
            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IContactUsBusiness, ContactUsBusiness>();
            services.AddScoped<ICountryBusiness, CountryBusiness>();
            services.AddScoped<ICurrencyBusiness, CurrencyBusiness>();
            services.AddScoped<IDeliveryBusiness, DeliveryBusiness>();
            services.AddScoped<IDiscountBusiness, DiscountBusiness>();
            services.AddScoped<IFeatureBusiness, FeatureBusiness>();
            services.AddScoped<IGenderBusiness, GenderBusiness>();
            services.AddScoped<IGuestUserBusiness, GuestUserBusiness>();
            services.AddScoped<ILocationBusiness, LocationBusiness>();
            services.AddScoped<IMessageBusiness, MessageBusiness>();
            services.AddScoped<IOpSystemBusiness, OpSystemBusiness>();
            services.AddScoped<IOrderBusiness, OrderBusiness>();
            services.AddScoped<IOrderReturnBusiness, OrderReturnBusiness>();
            services.AddScoped<IPageBusiness, PageBusiness>();
            services.AddScoped<IProductBusiness, ProductBusiness>();
            services.AddScoped<IProjectActionBusiness, ProjectActionBusiness>();
            services.AddScoped<IProjectControllerBusiness, ProjectControllerBusiness>();
            services.AddScoped<IRoleBusiness, RoleBusiness>();
            services.AddScoped<ISupplierBusiness, SupplierBusiness>();
            services.AddScoped<ITaxBusiness, TaxBusiness>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IWebBrowserBusiness, WebBrowserBusiness>();
            services.AddScoped<ICategoryDiscountBusiness, CategoryDiscountBusiness>();
            services.AddScoped<ICountryDiscountBusiness, CountryDiscountBusiness>();
            services.AddScoped<IEmployeeDiscountBusiness, EmployeeDiscountBusiness>();
            services.AddScoped<IEmployeeMessageBusiness, EmployeeMessageBusiness>();
            services.AddScoped<IGuestUserMessageBusiness, GuestUserMessageBusiness>();
            services.AddScoped<IOrderDiscountBusiness, OrderDiscountBusiness>();
            services.AddScoped<IOrderMessageBusiness, OrderMessageBusiness>();
            services.AddScoped<IOrderReturnMessageBusiness, OrderReturnMessageBusiness>();
            services.AddScoped<IProductCategoryBusiness, ProductCategoryBusiness>();
            services.AddScoped<IProductDiscountBusiness, ProductDiscountBusiness>();
            services.AddScoped<IProductFeatureBusiness, ProductFeatureBusiness>();
            services.AddScoped<IProductOrderReturnBusiness, ProductOrderReturnBusiness>();
            services.AddScoped<IProductSupplierBusiness, ProductSupplierBusiness>();
            services.AddScoped<IUserDiscountBusiness, UserDiscountBusiness>();
            services.AddScoped<IUserFavoriteBusiness, UserFavoriteBusiness>();
            services.AddScoped<IUserMessageBusiness, UserMessageBusiness>();
            services.AddScoped<ICategoryFeatureBusiness, CategoryFeatureBusiness>();
            services.AddScoped<IOrderProductBusiness, OrderProductBusiness>();
            services.AddScoped<IConversationBusiness, ConversationBusiness>();
            services.AddScoped<IConversationMessageBusiness, ConversationMessageBusiness>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICookieHelper, CookieHelper>();
            services.AddScoped<ISessionHelper, SessionHelper>();





        }
    }
}
