using LibraryManagementSystem.Repository.Implemention;
using LibraryManagementSystem.Repository.Interfaces;
using LibraryManagementSystem.Service.Implementation;
using LibraryManagementSystem.Service.Interfaces;

namespace LibraryManagementSystem.Helper
{
    public static class Extension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAuthorService), typeof(AuthorService));
            services.AddScoped(typeof(IBookService), typeof(BookService));
            services.AddScoped(typeof(ICategoryService), typeof(CategoryService));
            services.AddScoped(typeof(ILoanService), typeof(LoanService));
            services.AddScoped(typeof(IMemberService), typeof(MemberService));
            services.AddScoped(typeof(IAuthService), typeof(AuthService));
           
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();

            //services.AddScoped<IBookRepository, BookRepository>();
        }

    }
}
