using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DomainModel.Models.Context
{
    public class ShikaShopContext:DbContext
    {
        public ShikaShopContext(DbContextOptions<ShikaShopContext> opt):base(opt)
        {

            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //اینجا کانفیگوریشن ها اد میشود مثل
            //modelBuilder.ApplyConfiguration<Category>(new CategoryConfigurations());
            modelBuilder.Entity<Connection>();
            modelBuilder.Entity<Role>().HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x=>x.RoleId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Product>().HasMany(x => x.OrderProducts).WithOne(x => x.Product).HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.ApplyConfiguration<Order>(new OrderConfiguration());
            modelBuilder.ApplyConfiguration<Product>(new ProductConfigurations());
            modelBuilder.Entity<ChatRoom>().HasOne(x => x.recaivingUser)
                .WithMany(x => x.recaivingUserChatRoom).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDiscount> CategoryDiscounts { get; set; }
        public DbSet<CategoryFeature> CategoryFeatures { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<ContactUs> ContactUsEnumerable { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryDiscount> CountryDiscounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDiscount> EmployeeDiscounts { get; set; }
        public DbSet<EmployeeMessage> EmployeeMessages { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<GuestUser> GuestUsers { get; set; }
        public DbSet<GuestUserMessage> GuestUserMessages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<OpSystem> OpSystems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderReturn> OrderReturns { get; set; }
        public DbSet<OrderDiscount> OrderDiscounts { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<OrderMessage> OrderMessages { get; set; }
        public DbSet<OrderTax> OrderTaxes { get; set; }
        public DbSet<OrderReturnMessage> OrderReturnMessages { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCart> ProductCarts { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<ProductOrderReturn> ProductOrderReturns { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierImage> SupplierImages { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDiscount> UserDiscounts { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<WebBrowser> WebBrowsers { get; set; }
        public DbSet<ProjectAction> ProjectActions { get; set; }
        public DbSet<ProjectArea> ProjectAreas { get; set; }
        public DbSet<ProjectController> ProjectControllers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAction> RoleActiones { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<ConversationMessage> ConversationMessages { get; set; }
        public DbSet<UserConversation> UserConversations { get; set; }
        public DbSet<ChatRoom> ChatRoom { get; set; }
        public DbSet<Chat> Chat { get; set; }

    }
}
