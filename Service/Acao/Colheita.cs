using Common;
using Common.Lib;
using Service.Base;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Service.Acao
{
    public class Colheita : AViewModelColeta
    {
        public override bool executarAcao()
        {
            try
            {

                Random objRandomNumber = new Random();
                Win32.clicarBotaoDireito(objMatch.Location.X + objRandomNumber.Next(2, 8), objMatch.Location.Y + objRandomNumber.Next(2, 8));
                Thread.Sleep(600);

                if (objMatch.Location.X > 100 && objMatch.Location.Y > 60)
                {
                    Rectangle areaBusca = new Rectangle(objMatch.Location.X - 100, objMatch.Location.Y - 60, 200, 200);
                    Bitmap telaOriginal = ImagemCaptura.obterInstancia().obterImagemTela(true);
                    if (areaBusca.Width + areaBusca.X < telaOriginal.Width && areaBusca.Height + areaBusca.Y < telaOriginal.Height)
                    {
                        objMatch = ImagemBusca.obterInstancia().buscarImagemPorTemplate(objABotaoAcao.Imagem, Imagem.EnumRegiaoImagem.COMPLETO, areaBusca);
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
