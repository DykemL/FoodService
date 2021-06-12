using FoodService.Models.DbEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodService.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<LocalImage> Images { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public void Backup(
            string pgDumpPath,
            string outFile,
            string host,
            string port,
            string database,
            string user,
            string password)
        {
            string dumpCommand = $"\"{pgDumpPath}\" -Fc -h {host} -p {port} -d {database} -U {user}";
            string passFileContent = $"{host}:{port}:{database}:{user}:{password}";

            string batFilePath = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".bat");

            string passFilePath = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".conf");

            try
            {
                string batchContent = "";
                batchContent += "@" + "set PGPASSFILE=" + passFilePath + "\n";
                batchContent += "@" + dumpCommand + "  > " + "\"" + outFile + "\"" + "\n";

                File.WriteAllText(
                    batFilePath,
                    batchContent,
                    Encoding.ASCII);

                File.WriteAllText(
                    passFilePath,
                    passFileContent,
                    Encoding.ASCII);

                if (File.Exists(outFile))
                    File.Delete(outFile);

                ProcessStartInfo oInfo = new(batFilePath);
                oInfo.UseShellExecute = false;
                oInfo.CreateNoWindow = true;

                using (Process proc = Process.Start(oInfo))
                {
                    proc.WaitForExit();
                    proc.Close();
                }
            }
            finally
            {
                if (File.Exists(batFilePath))
                    File.Delete(batFilePath);

                if (File.Exists(passFilePath))
                    File.Delete(passFilePath);
            }
        }

        public void Restore(
            string pgRestorePath,
            string inputFile,
            string host,
            string port,
            string database,
            string user,
            string password)
        {
            string dumpCommand = $"\"{pgRestorePath}\" -h {host} -p {port} -d {database} -U {user} -c -v \"{inputFile}\"";
            string passFileContent = $"{host}:{port}:{database}:{user}:{password}";

            string batFilePath = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".bat");

            string passFilePath = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".conf");

            try
            {
                string batchContent = "";
                batchContent += "@" + "set PGPASSFILE=" + passFilePath + "\n";
                batchContent += "@" + dumpCommand;

                File.WriteAllText(
                    batFilePath,
                    batchContent,
                    Encoding.ASCII);

                File.WriteAllText(
                    passFilePath,
                    passFileContent,
                    Encoding.ASCII);

                ProcessStartInfo oInfo = new(batFilePath);
                oInfo.UseShellExecute = false;
                oInfo.CreateNoWindow = true;

                using (Process proc = Process.Start(oInfo))
                {
                    proc.WaitForExit();
                    proc.Close();
                }
            }
            finally
            {
                if (File.Exists(batFilePath))
                    File.Delete(batFilePath);

                if (File.Exists(passFilePath))
                    File.Delete(passFilePath);
            }
        }
    }
}
