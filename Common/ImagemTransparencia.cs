using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Common.Lib.Win32;

namespace Common
{
    public class ImagemTransparencia
    {
        #region Singleton
        private static ImagemTransparencia objImagemTransparencia;

        public static ImagemTransparencia obterInstancia()
        {
            if (ImagemTransparencia.objImagemTransparencia == null)
            {
                ImagemTransparencia.objImagemTransparencia = new ImagemTransparencia();
            }
            return ImagemTransparencia.objImagemTransparencia;
        }
        #endregion

        public int valorTransparencia = 0;

        public int obterValorTransparenciaPorHorario()
        {
            // "Romance Standard Time" (GMT+01:00) Brussels, Copenhagen, Madrid, Paris
            DateTime horarioaAtual = DateTime.Now;
            TimeZoneInfo tempoDeZonaFranca = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");
            DateTime horarioConvertido = TimeZoneInfo.ConvertTime(horarioaAtual, TimeZoneInfo.Local, tempoDeZonaFranca);

            int horaAtual = Int32.Parse(horarioConvertido.ToString("HH"));
            int valorMaximoTransparencia = 160;

            int[] variacoesTransparenciaPorHorario = new int[24];
            for (int hora = 0; hora < 24; hora++)
            {
                if (hora >= 12) variacoesTransparenciaPorHorario[hora] = (valorMaximoTransparencia / 12) * (hora - 12);
                else variacoesTransparenciaPorHorario[hora] = (valorMaximoTransparencia / 12) * (hora);
            };

            return variacoesTransparenciaPorHorario[horaAtual];
        }

        public void definirValorTransparenciaPorHorario()
        {
            this.valorTransparencia = this.obterValorTransparenciaPorHorario();
        }
    }
}
