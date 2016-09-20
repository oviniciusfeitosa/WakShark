using System.Threading;
using Common.Lib;
using Common;
using System.Drawing;
using Model;
using Model.Base;

namespace Service
{
    public class Coleta
    {
        private int _qtdColetas = 0;
        private int _areaColetaPercent = 30;
        public bool isAtivarModoBaixoConsumo { get; set; }

        #region Singleton
        private static Coleta objColeta;

        public static Coleta obterInstancia()
        {

            if (Coleta.objColeta == null)
            {
                Coleta.objColeta = new Coleta();
            }
            return Coleta.objColeta;
        }
        #endregion

        private void _ampliarAreaColeta()
        {
            if (_areaColetaPercent <= 80)
            {
                _areaColetaPercent += 10;
            }
        }

        private void _redefinirAreaColeta()
        {
            _areaColetaPercent = 20;
        }

        private Rectangle definirRetanguloAreaColeta()
        {
            Size bounds = Proporcao.obterProporcao();

            return new Rectangle(
                                (bounds.Width / 4) - ((bounds.Width / 2 * _areaColetaPercent / 100) / 2),
                                (bounds.Height / 2) - ((bounds.Height * _areaColetaPercent / 100) / 2),
                                (bounds.Width / 2 * _areaColetaPercent / 100),
                                (bounds.Height * _areaColetaPercent / 100)
            );
        }


        public bool coletar(ARecurso objRecurso, AAcao objAAcao)
        {
            bool retorno = false;
            this.validarInicioColeta(isAtivarModoBaixoConsumo);

            Model.Match match = new Model.Match();

            while (match.Semelhanca < 0.633d)
            {
                match = ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(objRecurso.Imagem, Imagem.EnumRegiaoImagem.COMPLETO, definirRetanguloAreaColeta());

                if (match.Semelhanca >= 0.633d)
                {
                    retorno = executarAcao(match, objRecurso, objAAcao);
                    //retorno = true;
                    break;
                }
                else if (_areaColetaPercent > 89)
                {
                    break;
                }
                else
                {
                    _ampliarAreaColeta();
                }
            }
            _redefinirAreaColeta();

            return retorno;
        }

        public void validarInicioColeta(bool isAtivarModoBaixoConsumo)
        {
            this.validarInicioBatalha();
            if (isAtivarModoBaixoConsumo)
            {
                //Verificando janelas/convites a cada 5 coletas e ao final de cada batalha, aqui estava aumentando muito o tempo de coleta.
                this._qtdColetas++;
                if (this._qtdColetas % 5 == 0)
                {
                    this.validarFechamentoMensagens();
                }
            }
            else
            {
                this.validarFechamentoMensagens();
            }
        }

        public void validarInicioBatalha()
        {
            System.Drawing.Bitmap bmpBatalha = ImagemCaptura.obterInstancia().obterImagemTelaComo8bitesPorPixel(Imagem.EnumRegiaoImagem.COMPLETO, true);
            if (Common.ColorHelper.HexConverter(bmpBatalha.GetPixel(bmpBatalha.Width / 2, 100)) == "#000000"
                && Common.ColorHelper.HexConverter(bmpBatalha.GetPixel(bmpBatalha.Width / 2, 110)) == "#000000"
                && Common.ColorHelper.HexConverter(bmpBatalha.GetPixel(bmpBatalha.Width / 2, 120)) == "#000000")
            {
                System.Windows.Forms.SendKeys.SendWait(" ");
                Batalha.obterInstancia().iniciar(Batalha.EnumTiposBatalha.AntiBOT);
            }
            bmpBatalha.Dispose();
        }

        public void validarFechamentoMensagens()
        {
            Rectangle areaBusca = new Rectangle(50, 50, Proporcao.Width - 50, Proporcao.Height - 50);
            Model.Match objMatch = ImagemBusca.obterInstancia().buscarImagemPorTemplate(Acao.obterInstancia().obterAcao("Fechar").Imagem, Imagem.EnumRegiaoImagem.COMPLETO, areaBusca);
            if (objMatch.Semelhanca > 0) Win32.clicarBotaoEsquerdo(objMatch.Location.X + 5, objMatch.Location.Y + 5);
        }

        private bool executarAcao(Match objMatch, ARecurso objRecurso, AAcao objAAcao)
        {
            try
            {
                Win32.clicarBotaoDireito(objMatch.Location.X, objMatch.Location.Y);
                Thread.Sleep(600);

                if (objMatch.Location.X > 100 && objMatch.Location.Y > 60)
                {
                    Rectangle areaBusca = new Rectangle(objMatch.Location.X - 100, objMatch.Location.Y - 60, 200, 200);
                    Bitmap telaOriginal = ImagemCaptura.obterInstancia().obterImagemTela(true);
                    if (areaBusca.Width + areaBusca.X < telaOriginal.Width && areaBusca.Height + areaBusca.Y < telaOriginal.Height)
                    {
                        objMatch = ImagemBusca.obterInstancia().buscarImagemPorTemplate(objAAcao.Imagem, Imagem.EnumRegiaoImagem.COMPLETO, areaBusca);
                        if (objMatch.Semelhanca > 0)
                        {
                            Win32.clicarBotaoEsquerdo(objMatch.Location.X + 5, objMatch.Location.Y + 5);
                            Thread.Sleep(2000);
                            Thread.Sleep(objRecurso.Tempo);
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (System.Exception objException)
            {
                throw new System.Exception(objException.ToString());
            }
        }
    }
}
