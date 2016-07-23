using System;

namespace Service
{
    public class Recurso : IDisposable
    {

        public String[] obterTiposRecurso()
        {
            return new[] {
                "",
                "Cereais",
                "Minerais",
                "Animais"
            };
        }

        public string[] obterRecursos(string tipoRecursos)
        {
            string[] arrayRecursos = null;
            switch (tipoRecursos)
            {
                case "Cereais":
                    arrayRecursos = new string[] { "Trigo", "Cevada", "Aveia" };
                    break;
                case "Minerais":
                    arrayRecursos = new string[] {  };
                    break;
                case "Animais":
                    arrayRecursos = new string[] {  };
                    break;
                default:
                    break;
            }

            return arrayRecursos;
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
