using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using AscWeb.Util;

namespace AscWeb.Util
{
    public static class SessionHelpers
    {

        public enum GlobalKey
        {
            /// <summary>
            /// Int: 5
            /// </summary>
            Idassociado,
            /// <summary>
            /// String: MARCOS
            /// </summary>
            NomeUsuario,
            /// <summary>
            /// int: 10
            /// </summary>
            Idusuario,
            /// <summary>
            /// GetUsuarioLogado
            /// </summary>
            usuarioLogado,
            /// <summary>
            /// Valor total do convite
            /// </summary>
            ValorPagamento

        }
        #region Private

        private static object Get(HttpSessionState Session, String Key)
        {
            return Session[Key];
        }

        private static void Set(HttpSessionState Session, String Key, object Value)
        {
            Session[Key] = Value;
        }

        private static bool Exists(HttpSessionState Session, String Key)
        {
            return Session[Key] != null;
        }



        #endregion

        #region Getters setters GlobalKey
        //HttpSessionState
        public static object Get(this HttpSessionState Session, GlobalKey Key)
        {
            return Get(Session, Key.ToString());
        }

        /// <summary>
        /// Tenta pegar o valor da session, caso exista
        /// </summary>
        /// <param name="Session"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static object TryGet(this HttpSessionState Session, GlobalKey Key)
        {
            if (Exists(Session, Key.ToString()))
            {
                return Get(Session, Key.ToString());
            }
            else
            {
                //throw new SessionExpiredException();
                throw new Exception();
            }
        }

        public static void Set(this HttpSessionState Session, GlobalKey Key, object Value)
        {
            Set(Session, Key.ToString(), Value);
        }

        public static bool Exists(this HttpSessionState Session, GlobalKey Key)
        {
            return Exists(Session, Key.ToString());
        }



        #endregion
    }
}
