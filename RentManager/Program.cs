using RentManager.Data;
using RentManager.Licensing;
using RentManager.Presentation.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Infrastructure;

namespace RentManager
{
    internal static class Program
    {
        private const string ChaveCliente = "CLIENTE_JOAO_001";

        [STAThread]
        static void Main()
        {
            // ── CAPTURA DE ERROS GLOBAIS ──────────────────────────────
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // ─────────────────────────────────────────────────────────

            ApplicationConfiguration.Initialize();
            QuestPDF.Settings.License = LicenseType.Community;

            bool licencaOk = Task.Run(async () =>
             await LicenseManager.ValidarAsync(ChaveCliente)).Result;

            if (!licencaOk)
                return;

            var services = new ServiceCollection();
            services.AddDbContext<RentManagerDataBase>(options =>
            {
                options.UseMySql(
                    "server=localhost;database=rentmanagerdb;user=RentManager_user;password=Modoxclasher2004!",
                    new MySqlServerVersion(new Version(9, 7, 0)),
                    b => b.MigrationsAssembly("RentManager.Migrations"));
            });

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
            services.AddTransient<FiltroRecibosForm>();

            ServiceLocator.Provider = services.BuildServiceProvider();

            using (var scope = ServiceLocator.Provider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<RentManagerDataBase>();
                try
                {
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao criar tabelas:\n{ex.Message}\n\nInner: {ex.InnerException?.Message}",
                        "Erro Migration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Application.Run(ServiceLocator.Provider.GetRequiredService<MenuForm>());
        }

        // ── ERRO NA THREAD PRINCIPAL (maioria dos crashes de WinForms) ──
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            GravarLog(e.Exception);
            MessageBox.Show(
                $"Ocorreu um erro inesperado:\n\n{e.Exception.Message}\n\n" +
                "O erro foi registrado no arquivo de log.\n" +
                "Por favor, informe ao suporte.",
                "Erro Inesperado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        // ── ERRO EM OUTRAS THREADS (background tasks, async, etc.) ──────
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
                GravarLog(ex);
        }

        // ── GRAVA O ERRO EM ARQUIVO DE LOG ──────────────────────────────
        private static void GravarLog(Exception ex)
        {
            try
            {
                string pastaLog = Path.Combine(
     Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
     "RentManager", "Logs");

                Directory.CreateDirectory(pastaLog);

                string arquivoLog = Path.Combine(pastaLog,
                    $"erro_{DateTime.Now:yyyy-MM-dd}.txt");

                string conteudo =
                    $"========================================\n" +
                    $"Data/Hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                    $"Erro: {ex.Message}\n" +
                    $"Tipo: {ex.GetType().FullName}\n" +
                    $"StackTrace:\n{ex.StackTrace}\n";

                if (ex.InnerException != null)
                    conteudo += $"\nInner Exception: {ex.InnerException.Message}\n" +
                                $"StackTrace Inner:\n{ex.InnerException.StackTrace}\n";

                File.AppendAllText(arquivoLog, conteudo, System.Text.Encoding.UTF8);
            }
            catch
            {
                // Se falhar ao gravar o log, não faz nada
            }
        }
    }
}