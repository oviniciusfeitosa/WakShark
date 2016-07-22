using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelTela = Model.Tela;
using ServiceRecurso = Service.Recurso;

namespace Service
{
    public class CapturadorPixel
    {

        public static ModelTela objModelTelaInicial;

        public static void armazenarCapturaComoTemplate(ModelTela objModelTela, string localizacao)
        {
            string conteudoCaptura = String.Empty;

            if(CapturadorPixel.objModelTelaInicial == null)
            {
                CapturadorPixel.objModelTelaInicial = objModelTela;
                conteudoCaptura = "if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal, objModelTela.eixoVertical, \"" + objModelTela.pixel + "\")) return false;";
            }
            else
            {
                int diferencaEixoHorizontal = objModelTela.eixoHorizontal - CapturadorPixel.objModelTelaInicial.eixoHorizontal;
                string operadorEixoHorizontal = String.Empty;
                if (diferencaEixoHorizontal >= 0)
                {
                    operadorEixoHorizontal = "+";
                }

                int diferencaEixoVertical = objModelTela.eixoVertical - CapturadorPixel.objModelTelaInicial.eixoVertical;
                string operadorEixoVertical = String.Empty;
                if (diferencaEixoVertical >= 0)
                {
                    operadorEixoVertical = "+";
                }

                conteudoCaptura = "if (!Service.TelaPixel.obterInstancia().isPixelEncontrado(objModelTela.eixoHorizontal" + operadorEixoHorizontal + diferencaEixoHorizontal + ", objModelTela.eixoVertical" + operadorEixoVertical + diferencaEixoVertical + ", \"" + objModelTela.pixel + "\")) return false;";
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(localizacao, true))
            {
                file.WriteLine(conteudoCaptura);
            }
        }

        public static void armazenarLogCaptura(ModelTela objModelTela, string tituloCaptura, string localizacaoLog)
        {
            string logCaptura = "{ ";
            logCaptura += "Titulo: '" + tituloCaptura + "',";
            logCaptura += "Horario: '" + System.DateTime.Now.ToString("dd/mm/yyyy HH:mm:ss") + "',";
            logCaptura += "Cor_hex: '" + (objModelTela.pixel) + "',";
            logCaptura += "Eixo_Vertical: '" + objModelTela.eixoVertical + "',";
            logCaptura += "Eixo_Horizontal: '" + objModelTela.eixoHorizontal + "'";
            logCaptura += " }";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@localizacaoLog + "_log_.txt", true))
            {
                file.WriteLine(logCaptura + ",");
            }
        }
    }
}
