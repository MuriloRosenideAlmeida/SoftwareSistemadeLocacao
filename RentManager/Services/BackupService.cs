using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentManager.Services
{
    public static class BackupService
    {
        private const string UrlServidor = "http://177.7.49.150:5000/backup/receber";

        // ── Dados do MySQL local do cliente ──────────────────────────
        private const string MySqlHost = "localhost";
        private const string MySqlPorta = "3306";
        private const string MySqlUsuario = "RentManager_user"; 
        private const string MySqlSenha = "Modoxclasher2004!";
        private const string MySqlBanco = "rentmanagerdb";      

        // ── Quantos backups locais manter ────────────────────────────
        private const int MaxBackupsLocais = 10;

        private static string PastaBackupLocal =>
     Path.Combine(
         Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
         "RentManager", "Backup");

        private static readonly string PastaTemp =
            Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "RentManager", "Temp");

        // ════════════════════════════════════════════════════════════
        // MÉTODO PRINCIPAL — chamado ao fechar o MenuForm
        // ════════════════════════════════════════════════════════════
        public static async Task RealizarBackupAsync(string chaveCliente)
        {
            try
            {
                Directory.CreateDirectory(PastaTemp);
                Directory.CreateDirectory(PastaBackupLocal);

                var dataHoje = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
                var nomeArquivo = $"backup_{chaveCliente}_{dataHoje}";
                var caminhoSql = Path.Combine(PastaTemp, nomeArquivo + ".sql");
                var caminhoZip = Path.Combine(PastaTemp, nomeArquivo + ".zip");
                var destinoLocal = Path.Combine(PastaBackupLocal, nomeArquivo + ".zip");

                // ── LOG DE DIAGNÓSTICO ────────────────────────────────
                string mysqldump = LocalizarMysqldump();
                GravarLog($"mysqldump encontrado em: {(string.IsNullOrEmpty(mysqldump) ? "NÃO ENCONTRADO" : mysqldump)}");

                // ── PASSO 1: Gera o .sql ──────────────────────────────
                bool sqlGerado = GerarSqlComMysqldump(caminhoSql);
                GravarLog($"SQL gerado: {sqlGerado}");

                if (!sqlGerado)
                {
                    GravarLog("Backup cancelado — falha ao gerar SQL.");
                    return;
                }

                // ── PASSO 2: Comprime em .zip ─────────────────────────
                ComprimirParaZip(caminhoSql, caminhoZip);
                GravarLog("ZIP criado com sucesso.");

                // ── PASSO 3: Salva local (sempre) ─────────────────────
                File.Copy(caminhoZip, destinoLocal, overwrite: true);
                GravarLog($"Backup salvo em: {destinoLocal}");

                // ── PASSO 4: Tenta enviar para nuvem (opcional) ────────
                if (!string.IsNullOrWhiteSpace(UrlServidor))
                {
                    await EnviarParaServidorAsync(caminhoZip, chaveCliente, dataHoje);
                    GravarLog("Envio para servidor concluído.");
                }

                // ── PASSO 5: Limpa backups antigos locais ─────────────
                LimparBackupsAntigos();
            }
            catch (Exception ex)
            {
                GravarLog($"ERRO no backup: {ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                LimparPastaTemp();
            }
        }

        // ════════════════════════════════════════════════════════════
        // GRAVA LOG DE DIAGNÓSTICO
        // ════════════════════════════════════════════════════════════
        private static void GravarLog(string mensagem)
        {
            try
            {
                Directory.CreateDirectory(PastaBackupLocal);
                string arquivoLog = Path.Combine(PastaBackupLocal, "log_backup.txt");
                File.AppendAllText(arquivoLog,
                    $"{DateTime.Now:dd/MM/yyyy HH:mm:ss} — {mensagem}\n",
                    System.Text.Encoding.UTF8);
            }
            catch { }
        }

        // ════════════════════════════════════════════════════════════
        // GERA O .SQL COM MYSQLDUMP
        // ════════════════════════════════════════════════════════════
        private static bool GerarSqlComMysqldump(string caminhoSql)
        {
            string caminhoMysqldump = LocalizarMysqldump();
            if (string.IsNullOrEmpty(caminhoMysqldump)) return false;

            var argumentos =
                $"-h {MySqlHost} " +
                $"-P {MySqlPorta} " +
                $"-u {MySqlUsuario} " +
                $"-p{MySqlSenha} " +
                $"--single-transaction " +
                $"--routines " +
                $"--triggers " +
                $"{MySqlBanco}";

            var processo = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = caminhoMysqldump,
                    Arguments = argumentos,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            processo.Start();
            string conteudoSql = processo.StandardOutput.ReadToEnd();
            string erroSql = processo.StandardError.ReadToEnd();
            processo.WaitForExit();

            if (!string.IsNullOrWhiteSpace(erroSql))
                GravarLog($"Erro do mysqldump: {erroSql}");

            if (string.IsNullOrWhiteSpace(conteudoSql) || processo.ExitCode != 0)
                return false;

            File.WriteAllText(caminhoSql, conteudoSql, System.Text.Encoding.UTF8);
            return true;
        }

        // ════════════════════════════════════════════════════════════
        // LOCALIZA O MYSQLDUMP EM QUALQUER DISCO E VERSÃO
        // ════════════════════════════════════════════════════════════
        private static string LocalizarMysqldump()
        {
            // ── Relativo ao próprio instalador (funciona em qualquer máquina) ──
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"mysql\bin\mysqldump.exe");
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\mysql\bin\mysqldump.exe");

            var caminhosDiretos = new[]
            {
                @"C:\Program Files (x86)\RentManager\mysql\bin\mysqldump.exe",
                @"D:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
                @"D:\Program Files\MySQL\MySQL Server 8.4\bin\mysqldump.exe",
                @"D:\Program Files\MySQL\MySQL Server 5.7\bin\mysqldump.exe",
                @"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
                @"C:\Program Files\MySQL\MySQL Server 8.4\bin\mysqldump.exe",
                @"C:\Program Files (x86)\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
                @"C:\xampp\mysql\bin\mysqldump.exe",
            };

            foreach (var caminho in caminhosDiretos)
                if (File.Exists(caminho)) return caminho;

            foreach (var disco in DriveInfo.GetDrives())
            {
                if (disco.DriveType != DriveType.Fixed) continue;

                var pastasMysql = new[]
                {
                    Path.Combine(disco.RootDirectory.FullName, @"Program Files\MySQL"),
                    Path.Combine(disco.RootDirectory.FullName, @"Program Files (x86)\MySQL"),
                };

                foreach (var pastaMysql in pastasMysql)
                {
                    if (!Directory.Exists(pastaMysql)) continue;

                    foreach (var subpasta in Directory.GetDirectories(pastaMysql))
                    {
                        var candidato = Path.Combine(subpasta, @"bin\mysqldump.exe");
                        if (File.Exists(candidato)) return candidato;
                    }
                }
            }

            return string.Empty;
        }

        // ════════════════════════════════════════════════════════════
        // COMPRIME O .SQL EM .ZIP
        // ════════════════════════════════════════════════════════════
        private static void ComprimirParaZip(string caminhoSql, string caminhoZip)
        {
            if (File.Exists(caminhoZip)) File.Delete(caminhoZip);

            using var zip = ZipFile.Open(caminhoZip, ZipArchiveMode.Create);
            zip.CreateEntryFromFile(caminhoSql, Path.GetFileName(caminhoSql),
                CompressionLevel.Optimal);
        }

        // ════════════════════════════════════════════════════════════
        // ENVIA PARA O SERVIDOR
        // ════════════════════════════════════════════════════════════
        private static async Task EnviarParaServidorAsync(
            string caminhoZip, string chaveCliente, string data)
        {
            try
            {
                using var http = new HttpClient { Timeout = TimeSpan.FromMinutes(5) };
                using var arquivo = File.OpenRead(caminhoZip);
                using var form = new MultipartFormDataContent();

                var conteudoArquivo = new StreamContent(arquivo);
                conteudoArquivo.Headers.ContentType =
                    new MediaTypeHeaderValue("application/zip");

                form.Add(conteudoArquivo, "arquivo", Path.GetFileName(caminhoZip));
                form.Add(new StringContent(chaveCliente), "chaveCliente");
                form.Add(new StringContent(data), "data");

                await http.PostAsync(UrlServidor, form);
            }
            catch (Exception ex)
            {
                GravarLog($"Erro ao enviar para servidor: {ex.Message}");
            }
        }

        // ════════════════════════════════════════════════════════════
        // MANTÉM APENAS OS ÚLTIMOS 10 BACKUPS LOCAIS
        // ════════════════════════════════════════════════════════════
        private static void LimparBackupsAntigos()
        {
            try
            {
                var arquivos = Directory.GetFiles(PastaBackupLocal, "*.zip");
                Array.Sort(arquivos);
                int excedentes = arquivos.Length - MaxBackupsLocais;
                for (int i = 0; i < excedentes; i++)
                    File.Delete(arquivos[i]);
            }
            catch { }
        }

        // ════════════════════════════════════════════════════════════
        // LIMPA PASTA TEMPORÁRIA
        // ════════════════════════════════════════════════════════════
        private static void LimparPastaTemp()
        {
            try
            {
                if (Directory.Exists(PastaTemp))
                    Directory.Delete(PastaTemp, recursive: true);
            }
            catch { }
        }

        // ════════════════════════════════════════════════════════════
        // MODO DE TESTE
        // ════════════════════════════════════════════════════════════
        public static void TestarBackupLocal(string chaveCliente)
        {
            try
            {
                Directory.CreateDirectory(PastaTemp);
                Directory.CreateDirectory(PastaBackupLocal);

                var dataHoje = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
                var nomeArquivo = $"backup_{chaveCliente}_{dataHoje}";
                var caminhoSql = Path.Combine(PastaTemp, nomeArquivo + ".sql");
                var caminhoZip = Path.Combine(PastaTemp, nomeArquivo + ".zip");
                var destinoLocal = Path.Combine(PastaBackupLocal, nomeArquivo + ".zip");

                string mysqldump = LocalizarMysqldump();

                if (string.IsNullOrEmpty(mysqldump))
                {
                    MessageBox.Show(
                        "mysqldump.exe não encontrado.\n" +
                        "Verifique se o MySQL Server está instalado.",
                        "Backup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool ok = GerarSqlComMysqldump(caminhoSql);
                if (!ok)
                {
                    MessageBox.Show(
                        "Erro ao gerar o backup.\n" +
                        "Verifique usuário e senha do MySQL.\n\n" +
                        "Consulte o arquivo Backup\\log_backup.txt para detalhes.",
                        "Backup", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ComprimirParaZip(caminhoSql, caminhoZip);
                File.Copy(caminhoZip, destinoLocal, overwrite: true);
                LimparBackupsAntigos();

                MessageBox.Show(
                    $"Backup gerado com sucesso!\n\nSalvo em:\n{destinoLocal}",
                    "Backup OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Backup",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LimparPastaTemp();
            }
        }
    }
}