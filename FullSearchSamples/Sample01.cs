using FullSearchSamples.Services.Impl;
using FullSearchSamples.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FullSearchSamples
{
    internal class Sample01
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services => {

                    #region Configure EF DBContext Service (CardStorageService Database)

                    services.AddDbContext<DocumentDbContext>(options =>
                    {
                        options.UseSqlServer(@"data source=XOMA\SQLEXPRESS;initial catalog=DocumentsDatabase;MultipleActiveResultSets=True;App=EntityFramework;Trusted_Connection=True;");
                    });

                    #endregion

                    #region Configure Repositories

                    services.AddTransient<IDocumentRepository, DocumentRepository>();

                    #endregion


                })
                .Build();

            // Сохраним документы в БД
            host.Services.GetRequiredService<IDocumentRepository>().LoadDocuments();


        }
    }
}