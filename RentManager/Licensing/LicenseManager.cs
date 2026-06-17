using System;
using System.IO;
using System.Management;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentManager.Licensing
{
    public static class LicenseManager
    {
        private const string UrlVerificacao = "http://177.7.49.150:5000/licenca/verificar";

        private const int MaxDiasSemInternet = 3;

        private static readonly string CacheDir =
            Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "RentManager");
        private static readonly string CacheFile =
            Path.Combine(CacheDir, "lic.dat");

        // ════════════════════════════════════════════════════════════
        // MÉTODO PRINCIPAL
        // ════════════════════════════════════════════════════════════
        public static async Task<bool> ValidarAsync(string chaveCliente)
        {
            string hardwareId = ObterHardwareId();

            var resultadoOnline = await VerificarOnlineAsync(chaveCliente, hardwareId);

            if (resultadoOnline.HasValue)
            {
                SalvarCache(new CacheLicenca
                {
                    Ativa = resultadoOnline.Value,
                    ChaveCliente = chaveCliente,
                    HardwareId = hardwareId,
                    UltimaVerificacao = DateTime.UtcNow
                });

                if (!resultadoOnline.Value)
                {
                    MostrarBloqueado("Sua licença foi desativada ou esta máquina não está autorizada.\nEntre em contato com o suporte.");
                    return false;
                }

                return true;
            }

            // Sem internet — usa cache
            var cache = LerCache();

            if (cache == null)
            {
                MostrarBloqueado(
                    "Não foi possível verificar a licença.\n" +
                    "Conecte à internet na primeira utilização.");
                return false;
            }

            // Verifica se é a mesma máquina do cache
            if (cache.HardwareId != hardwareId)
            {
                MostrarBloqueado("Esta máquina não está autorizada a usar o sistema.");
                return false;
            }

            var diasSemInternet = (DateTime.UtcNow - cache.UltimaVerificacao).TotalDays;

            if (diasSemInternet > MaxDiasSemInternet)
            {
                MostrarBloqueado(
                    $"Sem conexão há {(int)diasSemInternet} dias.\n" +
                    "Conecte à internet para continuar.");
                return false;
            }

            if (!cache.Ativa)
            {
                MostrarBloqueado("Sua licença foi desativada.\nEntre em contato com o suporte.");
                return false;
            }

            return true;
        }

        // ════════════════════════════════════════════════════════════
        // GERA UM ID ÚNICO DA MÁQUINA
        // Baseado no processador + placa mãe — não muda mesmo
        // reinstalando o Windows
        // ════════════════════════════════════════════════════════════
        public static string ObterHardwareId()
        {
            try
            {
                string cpu = ObterWmi("Win32_Processor", "ProcessorId");
                string placa = ObterWmi("Win32_BaseBoard", "SerialNumber");
                string disco = ObterWmi("Win32_DiskDrive", "SerialNumber");

                string combinado = $"{cpu}-{placa}-{disco}";

                // Gera um hash do hardware — fica como uma string curta
                using var sha = SHA256.Create();
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(combinado));
                return Convert.ToHexString(bytes)[..16]; // pega só os primeiros 16 caracteres
            }
            catch
            {
                return "UNKNOWN";
            }
        }

        private static string ObterWmi(string classe, string propriedade)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher(
                    $"SELECT {propriedade} FROM {classe}");

                foreach (var obj in searcher.Get())
                {
                    var valor = obj[propriedade]?.ToString()?.Trim();
                    if (!string.IsNullOrWhiteSpace(valor))
                        return valor;
                }
            }
            catch { }

            return "N/A";
        }

        // ════════════════════════════════════════════════════════════
        // VERIFICAÇÃO ONLINE — envia chave + hardware ID
        // ════════════════════════════════════════════════════════════
        private static async Task<bool?> VerificarOnlineAsync(string chave, string hardwareId)
        {
            try
            {
                using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };
                var url = $"{UrlVerificacao}?chave={Uri.EscapeDataString(chave)}&hardwareId={Uri.EscapeDataString(hardwareId)}";
                var response = await http.GetAsync(url);

                if (!response.IsSuccessStatusCode) return null;

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<LicencaResponse>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return result?.Ativa;
            }
            catch
            {
                return null;
            }
        }

        // ════════════════════════════════════════════════════════════
        // CACHE LOCAL CRIPTOGRAFADO
        // ════════════════════════════════════════════════════════════
        private static void SalvarCache(CacheLicenca cache)
        {
            try
            {
                Directory.CreateDirectory(CacheDir);
                var json = JsonSerializer.Serialize(cache);
                var bytes = Encoding.UTF8.GetBytes(json);
                var criptografado = ProtectedData.Protect(
                    bytes, null, DataProtectionScope.LocalMachine);
                File.WriteAllBytes(CacheFile, criptografado);
            }
            catch { }
        }

        private static CacheLicenca? LerCache()
        {
            try
            {
                if (!File.Exists(CacheFile)) return null;
                var criptografado = File.ReadAllBytes(CacheFile);
                var bytes = ProtectedData.Unprotect(
                    criptografado, null, DataProtectionScope.LocalMachine);
                return JsonSerializer.Deserialize<CacheLicenca>(
                    Encoding.UTF8.GetString(bytes));
            }
            catch { return null; }
        }

        // ════════════════════════════════════════════════════════════
        // HELPERS
        // ════════════════════════════════════════════════════════════
        private static void MostrarBloqueado(string mensagem)
        {
            MessageBox.Show(
                mensagem + "\n\nTelefone: (19) 99488-2709" + "\n Email:systems.bytecode@gmail.com",
                "Acesso Bloqueado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private class LicencaResponse
        {
            public bool Ativa { get; set; }
        }

        private class CacheLicenca
        {
            public bool Ativa { get; set; }
            public string ChaveCliente { get; set; } = "";
            public string HardwareId { get; set; } = "";
            public DateTime UltimaVerificacao { get; set; }
        }
    }
}