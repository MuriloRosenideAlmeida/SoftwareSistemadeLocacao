using EstruturaFesta.Data;
using EstruturaFesta.Presentation.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace EstruturaFesta
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // 1️⃣ Cria o Host (container de dependências)
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            // DbContext
            services.AddDbContext<EstruturaDataBase>(options =>
            {
                options.UseMySql(
                    "server=localhost;database=DataBaseEstrutura;user=root;password=Modoxclasher2004!",
                    new MySqlServerVersion(new Version(8, 0, 40)));
            });

            // Forms
            services.AddTransient<MenuForm>();
            services.AddTransient<TelaPedidoForm>();
            services.AddTransient<BuscarProdutosForm>();
            services.AddTransient<CadastroProdutosForm>();
            services.AddTransient<CadastroClientesForm>();
            services.AddTransient<FiltroClienteForm>();
            services.AddTransient<FiltroClientePedidoForm>();
            services.AddTransient<FiltroPedidosForm>();
            services.AddTransient<FiltroProdutoForm>();
            services.AddTransient<QuebraProdutoForm>();

            ServiceLocator.Provider = services.BuildServiceProvider();

            Application.Run(ServiceLocator.Provider.GetRequiredService<MenuForm>());
        }
    }
}
