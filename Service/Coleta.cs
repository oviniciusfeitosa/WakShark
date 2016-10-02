using System.Threading;
using Common.Lib;
using Common;
using System.Drawing;
using Model;
using Model.Base;
using Service.Base;

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

        private Rectangle obterRetanguloAreaColeta()
        {
            Size bounds = Proporcao.obterProporcao();

            return new Rectangle(
                                (bounds.Width / 4) - ((bounds.Width / 2 * _areaColetaPercent / 100) / 2),
                                (bounds.Height / 2) - ((bounds.Height * _areaColetaPercent / 100) / 2),
                                (bounds.Width / 2 * _areaColetaPercent / 100),
                                (bounds.Height * _areaColetaPercent / 100)
            );
        }


        public bool coletar(AViewModelColeta objAViewModelColeta)
        {
            bool retorno = false;
            this.validarInicioColeta(isAtivarModoBaixoConsumo);

            objAViewModelColeta.objMatch = new Model.Match();

            while (objAViewModelColeta.objMatch.Semelhanca < 0.633d)
            {
                foreach (string caminhoImagem in objAViewModelColeta.objRecurso.ListaImagens)
                {
                    objAViewModelColeta.objMatch = ImagemBusca.obterInstancia().buscarImagemPorTemplateRotacionado(caminhoImagem, Imagem.EnumRegiaoImagem.COMPLETO, obterRetanguloAreaColeta());
                    if (objAViewModelColeta.objMatch.Semelhanca > 0) break;
                }


                if (objAViewModelColeta.objMatch.Semelhanca >= 0.633d)
                {
                    retorno = objAViewModelColeta.executarAcao();
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
            Rectangle areaBusca = new Rectangle(200, 200, Proporcao.Width / 2, Proporcao.Height - 200);
            Model.Match objMatchIniciarBatalha = ImagemBusca.obterInstancia().buscarImagemPorTemplate(BotaoAcao.obterInstancia().obterBotaoAcao("IniciarBatalha").Imagem, Imagem.EnumRegiaoImagem.COMPLETO, areaBusca);


            bool isIniciarBatalha = false;
            if (objMatchIniciarBatalha.Semelhanca > 0) isIniciarBatalha = true;
            else
            {
                Model.Match objMatchPassarTurno = ImagemBusca.obterInstancia().buscarImagemPorTemplate(BotaoAcao.obterInstancia().obterBotaoAcao("PassarTurno").Imagem, Imagem.EnumRegiaoImagem.COMPLETO, areaBusca);
                if (objMatchPassarTurno.Semelhanca > 0) isIniciarBatalha = true;
            }
            if (isIniciarBatalha)
            {
                System.Windows.Forms.SendKeys.SendWait(" ");
                Batalha.obterInstancia().iniciar(Batalha.EnumTiposBatalha.AntiBOT);
            }
        }

        public void validarFechamentoMensagens()
        {
            Rectangle areaBusca = new Rectangle(50, 50, Proporcao.Width - 50, Proporcao.Height - 50);
            Model.Match objMatch = ImagemBusca.obterInstancia().buscarImagemPorTemplate(BotaoAcao.obterInstancia().obterBotaoAcao("Fechar").Imagem, Imagem.EnumRegiaoImagem.COMPLETO, areaBusca);
            if (objMatch.Semelhanca > 0) Win32.clicarBotaoEsquerdo(objMatch.Location.X + 5, objMatch.Location.Y + 5);
        }
    }
}
