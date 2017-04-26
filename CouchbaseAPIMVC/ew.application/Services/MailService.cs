using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ew.application.Services
{
    public class MailService
    {
        private SmtpClient _smtpServer;
        public MailService(string smtpServer, int smtpPort, bool enableSSL, string username, string password)
        {
            _smtpServer = new SmtpClient(smtpServer, smtpPort);
            _smtpServer.Port = smtpPort;
            _smtpServer.Credentials = new System.Net.NetworkCredential(username, password);
            _smtpServer.EnableSsl = enableSSL;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mailToAddress">cách nhau bằng dấu phẩy</param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="filesToAttach"></param>
        /// <returns></returns>
        public bool Send(string mailFrom, string mailTo, string mailBccs, string subject, string body, IEnumerable<string> filesToAttach = null)
        {
            ew.common.EwhLogger.Common.Debug("Call Send mail");

            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(mailFrom);
            mail.To.Add(mailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            if(!string.IsNullOrEmpty(mailBccs)) mail.Bcc.Add(mailBccs);
            try
            {
                ew.common.EwhLogger.Common.Debug("Send mail");
                _smtpServer.Send(mail);
                return true;
            }catch(Exception ex)
            {
                ew.common.EwhLogger.Common.Debug(ex);
                return false;
            }
        }
        

        #region internal class
        public sealed class Token
        {
            private readonly string _key;
            private readonly string _value;
            private readonly bool _neverHtmlEncoded;

            public Token(string key, string value) :
                this(key, value, false)
            {

            }
            public Token(string key, string value, bool neverHtmlEncoded)
            {
                this._key = key;
                this._value = value;
                this._neverHtmlEncoded = neverHtmlEncoded;
            }

            /// <summary>
            /// Token key
            /// </summary>
            public string Key { get { return _key; } }
            /// <summary>
            /// Token value
            /// </summary>
            public string Value { get { return _value; } }
            /// <summary>
            /// Indicates whether this token should not be HTML encoded
            /// </summary>
            public bool NeverHtmlEncoded { get { return _neverHtmlEncoded; } }

            public override string ToString()
            {
                return string.Format("{0}: {1}", Key, Value);
            }
        }
        public class MessageTemplatesSettings
        {
            /// <summary>
            /// Gets or sets a value indicating whether to replace message tokens according to case invariant rules
            /// </summary>
            public bool CaseInvariantReplacement { get; set; }

            /// <summary>
            /// Gets or sets a color1 in  hex format ("#hhhhhh") to use in workflow message formatting
            /// </summary>
            public string Color1 { get; set; }

            /// <summary>
            /// Gets or sets a color2 in  hex format ("#hhhhhh") to use in workflow message formatting
            /// </summary>
            public string Color2 { get; set; }

            /// <summary>
            /// Gets or sets a color3 in  hex format ("#hhhhhh") to use in workflow message formatting
            /// </summary>
            public string Color3 { get; set; }

        }
        public partial interface ITokenizer
        {
            /// <summary>
            /// Replace all of the token key occurences inside the specified template text with corresponded token values
            /// </summary>
            /// <param name="template">The template with token keys inside</param>
            /// <param name="tokens">The sequence of tokens to use</param>
            /// <param name="htmlEncode">The value indicating whether tokens should be HTML encoded</param>
            /// <returns>Text with all token keys replaces by token value</returns>
            string Replace(string template, IEnumerable<Token> tokens, bool htmlEncode);
        }
        public partial class Tokenizer : ITokenizer
        {
            private readonly StringComparison _stringComparison;

            /// <summary>
            /// Ctor
            /// </summary>
            /// <param name="settings">Message templates settings</param>
            public Tokenizer(MessageTemplatesSettings settings)
            {
                _stringComparison = settings.CaseInvariantReplacement ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            }

            /// <summary>
            /// Replace all of the token key occurences inside the specified template text with corresponded token values
            /// </summary>
            /// <param name="template">The template with token keys inside</param>
            /// <param name="tokens">The sequence of tokens to use</param>
            /// <param name="htmlEncode">The value indicating whether tokens should be HTML encoded</param>
            /// <returns>Text with all token keys replaces by token value</returns>
            public string Replace(string template, IEnumerable<Token> tokens, bool htmlEncode)
            {
                if (string.IsNullOrWhiteSpace(template))
                    throw new ArgumentNullException("template");

                if (tokens == null)
                    throw new ArgumentNullException("tokens");

                foreach (var token in tokens)
                {
                    string tokenValue = token.Value;
                    //do not encode URLs
                    if (htmlEncode && !token.NeverHtmlEncoded)
                        tokenValue = HttpUtility.HtmlEncode(tokenValue);
                    template = Replace(template, String.Format(@"%{0}%", token.Key), tokenValue);
                }
                return template;

            }

            private string Replace(string original, string pattern, string replacement)
            {
                if (_stringComparison == StringComparison.Ordinal)
                {
                    return original.Replace(pattern, replacement);
                }

                int count, position0, position1;
                count = position0 = position1 = 0;
                int inc = (original.Length / pattern.Length) * (replacement.Length - pattern.Length);
                var chars = new char[original.Length + Math.Max(0, inc)];
                while ((position1 = original.IndexOf(pattern, position0, _stringComparison)) != -1)
                {
                    for (int i = position0; i < position1; ++i)
                        chars[count++] = original[i];
                    for (int i = 0; i < replacement.Length; ++i)
                        chars[count++] = replacement[i];
                    position0 = position1 + pattern.Length;
                }
                if (position0 == 0) return original;
                for (int i = position0; i < original.Length; ++i)
                    chars[count++] = original[i];
                return new string(chars, 0, count);

            }
        }
        #endregion
    }
}
