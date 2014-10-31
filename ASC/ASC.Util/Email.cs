using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace AscWeb.Util
{
    public class Email
    {
        private string assunto;

        public string Assunto
        {
            get { return assunto; }
            set { assunto = value; }
        }
        private string destinatario;

        public string Destinatario
        {
            get { return destinatario; }
            set { destinatario = value; }
        }
        private string mensagem;

        public string Mensagem
        {
            get { return mensagem; }
            set { mensagem = value; }
        }

        private List<string> cc;

        public List<string> CC { get; set; }

        public Email(string assunto, string destinatario, string mensagem, List<string> lstcc)
        {
            this.assunto = assunto;
            this.destinatario = destinatario;
            this.mensagem = mensagem;
            this.cc = lstcc;
        }

        public Email(string assunto, string destinatario, string mensagem)
        {
            this.assunto = assunto;
            this.destinatario = destinatario;
            this.mensagem = mensagem;
        }
       
        public Email()
        {
        }

        public void EnviarEmail(string host, int porta, string remetente, string nomeExibicao, string login, string senha, bool requerAut)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(new MailAddress(Destinatario));
            
            if(CC != null && CC.Any())
            foreach (var item in CC)
            {
                mm.CC.Add(item);   
            }            
            mm.Subject = Assunto;
            mm.Body = Mensagem;
            mm.From = new MailAddress(remetente, nomeExibicao);
            mm.Priority = MailPriority.Normal;
            mm.IsBodyHtml = true;
            
            SmtpClient smtp = new SmtpClient();

            smtp.Host = host;
            smtp.EnableSsl = requerAut;            
            smtp.Port = porta;
            smtp.Credentials = new NetworkCredential(login, senha);
            
            smtp.Send(mm);
            mm.Dispose();
        }

        public void EnviarEmailAtualizacao(string host, int porta, string remetente, List<string> copias, string nomeExibicao, string login, string senha, bool requerAuto)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(new MailAddress(Destinatario));
            if (copias != null)
            {
                foreach (string cc in copias)
                {
                    if (!string.IsNullOrEmpty(cc))
                        mm.CC.Add(cc);
                }
            }
            mm.Subject = Assunto;
            mm.Body = Mensagem;
            mm.From = new MailAddress(remetente, nomeExibicao);
            mm.Priority = MailPriority.Normal;
            mm.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = host;
            smtp.EnableSsl = requerAuto;
            smtp.Port = porta;
            smtp.Credentials = new NetworkCredential(login, senha);

            smtp.Send(mm);
            mm.Dispose();
        }

        public void EnviarEmailFotoRejeitada(string host, int porta, string remetente, string nomeExibicao, string login, string senha, bool requerAut)
        {
            MailMessage mm = new MailMessage();
            mm.To.Add(new MailAddress(Destinatario));
            mm.Subject = Assunto;
            mm.Body = Mensagem;
            mm.From = new MailAddress(remetente, nomeExibicao);
            mm.Priority = MailPriority.Normal;
            mm.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();

            smtp.Host = host;
            smtp.EnableSsl = requerAut;
            smtp.Port = porta;
            smtp.Credentials = new NetworkCredential(login, senha);

            smtp.Send(mm);
            mm.Dispose();
        }
    }
}
