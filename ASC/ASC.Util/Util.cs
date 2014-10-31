using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace AscWeb.Util
{
    public class Util
    {
        private static byte[] chave = { };
        private static byte[] iv = { 12, 34, 56, 78, 90, 102, 114, 126 };

        public static string CriptografarQueryString(string valor, string chaveCriptografia)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; byte[] input;
            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();

                input = Encoding.UTF8.GetBytes(valor); chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));
                cs = new CryptoStream(ms, des.CreateEncryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string DescriptografarQueryString(string valor, string chaveCriptografia)
        {
            DESCryptoServiceProvider des;
            MemoryStream ms;
            CryptoStream cs; byte[] input;

            try
            {
                des = new DESCryptoServiceProvider();
                ms = new MemoryStream();

                input = new byte[valor.Length];
                input = Convert.FromBase64String(valor.Replace(" ", "+"));

                chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8));

                cs = new CryptoStream(ms, des.CreateDecryptor(chave, iv), CryptoStreamMode.Write);
                cs.Write(input, 0, input.Length);
                cs.FlushFinalBlock();

                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetSubDomain(Uri url)
        {
            string host = url.Host;
            if (host.Split('.').Length > 1)
            {
                if (host.StartsWith("www"))
                {
                    host = host.Remove(0, 4);
                }
                int index = host.IndexOf(".");
                return host.Substring(0, index);
            }

            return null;
        }
        public static string ObterCaminhoIni(string arquivo)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
            return path = String.Format("{0}\\{1}", path, arquivo);
        }
        public static string ObterCaminho(string folder)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, folder);
            return path = String.Format("{0}", path);
        }

        public static void ExtrairZip(string caminhoArquivoZip, string caminhoDestino)
        {
            //Chilkat.Zip zip = new Chilkat.Zip();

            //// Anything begins the 30-day trial
            //bool unlocked = zip.UnlockComponent("30-day trial");
            //if (!unlocked)
            //{
            //    //MessageBox.Show(zip.LastErrorText);
            //    return;
            //}

            //bool success = zip.OpenZip(caminhoArquivoZip);
            //if (!success)
            //{
            //    // MessageBox.Show(zip.LastErrorText);
            //    return;
            //}


            //// Unzip to a specific directory.  Unzip returns the number of
            //// files and directories created.
            //long count = zip.Unzip(caminhoDestino);
            //if (count == -1)
            //{
            //    //    MessageBox.Show(zip.LastErrorText);
            //}
            //else
            //{
            //    //  MessageBox.Show("Unzipped!");
            //}
        }
        public static int CriptografarSenha(string senha)
        {
            int result = 0;
            for (int i = 0; i < senha.Length; i++)
            {
                result = result * 128 + (int)senha[i] ^ 85;
            }
            return result;
        }
        public static void WriterFile(string arquivo, string texto)
        {
            StreamWriter streamWriter = new StreamWriter(arquivo, true);
            streamWriter.WriteLine(texto);
            streamWriter.Close();
            streamWriter.Dispose();
        }
        public static string ReaderFile(string arquivo)
        {
            StreamReader streamReader = new StreamReader(arquivo);
            StringBuilder sb = new StringBuilder();
            while (!streamReader.EndOfStream)
            {
                string linha = streamReader.ReadLine();
                sb.AppendLine(linha);
            }
            streamReader.Dispose();
            streamReader.Close();
            return sb.ToString();
        }

        public static int ConverterParaAnoMes(DateTime data)
        {
            return Convert.ToInt32(data.ToString("yyyyMM"));
        }

        //public static List<DateTime> GetIntervalTimeActualMonth(Periodicidade periodicidade)
        //{
        //    if (periodicidade == Periodicidade.None)
        //        return null;

        //    if (periodicidade == Periodicidade.Diario)
        //    {
        //        return new List<DateTime>()
        //        {
        //           DateTime.Now.Date,
        //           DateTime.Now.Date
        //        };

        //    }

        //    int mes = DateTime.Now.Month;
        //    int periodo = Convert.ToInt32(periodicidade);


        //    double x = (mes + (periodo - 1)) / periodo; // FORMULA PARA DESCOBRIR O MES INICIAL DO PERIODO VIGENTE
        //    double result = Math.Floor(x) * periodo - (periodo - 1); // FORMULA PARA DESCOBRIR O MES INICIAL DO PERIODO VIGENTE

        //    int mesInicial = Convert.ToInt32(result);

        //    DateTime dataInicial = new DateTime(DateTime.Now.Year, mesInicial, 1);
        //    DateTime dataFinal = dataInicial.AddMonths(periodo).AddDays(-1);

        //    return new List<DateTime>()
        //    {
        //    dataInicial,
        //    dataFinal
        //        };

        //}
        //public static List<DateTime> GetIntervalTime(Periodicidade periodicidade, Mes _mes)
        //{
        //    if (periodicidade == Periodicidade.None)
        //        return null;

        //    if (periodicidade == Periodicidade.Diario)
        //    {
        //        return new List<DateTime>()
        //        {
        //           DateTime.Now.Date,
        //           DateTime.Now.Date
        //        };

        //    }

        //    int mes = Convert.ToInt32(_mes);
        //    int periodo = Convert.ToInt32(periodicidade);

        //    double x = (mes + (periodo - 1)) / periodo;
        //    double result = Math.Floor(x) * periodo - (periodo - 1);
        //    int mesInicial = Convert.ToInt32(result);

        //    DateTime dataInicial = new DateTime(DateTime.Now.Year, mesInicial, 1);
        //    DateTime dataFinal = dataInicial.AddMonths(periodo).AddDays(-1);

        //    return new List<DateTime>()
        //    {
        //    dataInicial,
        //    dataFinal
        //        };

        //}

        //public static int GetQuantidadeDiasNoMes(int ano, Mes mes)
        //{
        //    return DateTime.DaysInMonth(ano, Convert.ToInt32(mes));
        //}
        //public static int GetQuantidadeDiasNoMes(int ano, int mes)
        //{
        //    return DateTime.DaysInMonth(ano, mes);
        //}

      


        #region Gerar senha aleatoria

        public static string GerarSenhaAleatoria()
        {
            string carac = "abcdefhijkmnopqrstuvxwyz123456789";
            char[] letras = carac.ToCharArray();
            Embaralhar(ref letras, 5);
            string senha = new String(letras).Substring(0, 8);
            return senha;
        }
        private static void Embaralhar(ref char[] array, int vezes)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 1; i <= vezes; i++)
            {
                for (int x = 1; x <= array.Length; x++)
                {
                    Trocar(ref array[rand.Next(0, array.Length)],
                    ref array[rand.Next(0, array.Length)]);
                }
            }
        }

        private static void Trocar(ref char arg1, ref char arg2)
        {
            char strTemp = arg1;
            arg1 = arg2;
            arg2 = strTemp;
        }

        #endregion
    }
}
