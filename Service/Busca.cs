using System.Threading;
using Common.Lib;
using Common;
using System.Drawing;
using Model;
using Model.Base;
using Service.Base;
using Model.BotaoAcao;

namespace Service
{
    public class Busca
    {
        private int _quantidadeColetas = 0;
        private int _percentualAreaBusca = 30;
        public bool isAtivarModoBaixoConsumo { get; set; }

        #region Singleton
        private static Busca objColeta;

        public static Busca obterInstancia()
        {

            if (Busca.objColeta == null)
            {
                Busca.objColeta = new Busca();
            }
            return Busca.objColeta;
        }
        #endregion

        private void _ampliarAreaColeta()
        {
            if (_percentualAreaBusca <= 80)
            {
                _percentualAreaBusca += 10;
            }
        }

        private void _redefinirAreaBusca()
        {
            _percentualAreaBusca = 20;
        }

        private Rectangle obterRetanguloAreaColeta()
        {
            Size bounds = Proporcao.obterProporcao();

            return new Rectangle(
                                (bounds.Width / 4) - ((bounds.Width / 2 * _percentualAreaBusca / 100) / 2),
                                (bounds.Height / 2) - ((bounds.Height * _percentualAreaBusca / 100) / 2),
                                (bounds.Width / 2 * _percentualAreaBusca / 100),
                                (bounds.Height * _percentualAreaBusca / 100)
            );
        }


        public bool buscar(AViewModelColeta objAViewModelColeta)
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
                else if (_percentualAreaBusca > 89)
                {
                    break;
                }
                else
                {
                    _ampliarAreaColeta();
                }
            }
            _redefinirAreaBusca();

            return retorno;
        }

        public void validarInicioColeta(bool isAtivarModoBaixoConsumo)
        {
            this.validarInicioBatalha();
            if (isAtivarModoBaixoConsumo)
            {
                //Verificando janelas/convites a cada 5 coletas e ao final de cada batalha, aqui estava aumentando muito o tempo de coleta.
                this._quantidadeColetas++;
                if (this._quantidadeColetas % 5 == 0)
                {
                    this.tratarRecusaDeGrupo();
                    this.tratarCliqueBotaoFechar();
                    this.validarFechamentoMensagens();
                }
            }
            else
            {
                this.tratarRecusaDeGrupo();
                this.tratarCliqueBotaoFechar();
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
            Model.Match objMatch = ImagemBusca.obterInstancia().buscarImagemPorTemplate((new BotaoFecharX()).Imagem, Imagem.EnumRegiaoImagem.COMPLETO, areaBusca);
            if (objMatch.Semelhanca > 0) Win32.clicarBotaoEsquerdo(objMatch.Location.X + 5, objMatch.Location.Y + 5);
        }
        
        public void tratarRecusaDeGrupo()
        {
            Rectangle areaBusca = new Rectangle(60, 20, Proporcao.Width - 60, Proporcao.Height - 20);
            Model.Match objMatch = ImagemBusca.obterInstancia().buscarImagemPorTemplate((new BotaoNao()).Imagem, Imagem.EnumRegiaoImagem.COMPLETO, areaBusca);
            if (objMatch.Semelhanca > 0) Win32.clicarBotaoEsquerdo(objMatch.Location.X + 15, objMatch.Location.Y + 5);
        }

        public void tratarCliqueBotaoFechar()
        {
            Rectangle areaBusca = new Rectangle(57, 24, Proporcao.Width - 57, Proporcao.Height - 24);
            Model.Match objMatch = ImagemBusca.obterInstancia().buscarImagemPorTemplate((new BotaoFechar()).Imagem, Imagem.EnumRegiaoImagem.COMPLETO, areaBusca);
            if (objMatch.Semelhanca > 0) Win32.clicarBotaoEsquerdo(objMatch.Location.X + 15, objMatch.Location.Y + 5);
        }
    }
}
