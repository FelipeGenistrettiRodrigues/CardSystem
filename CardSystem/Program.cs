using System;

namespace CardSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== INICIANDO SISTEMA DE CARTÕES E BENEFÍCIOS ===\n");

            try
            {

                ContaPessoa contaFelipe = ContaPessoa.CriarConta("Felipe", TipoCartao.CartaoBlackMetal);
                contaFelipe.ExibirResumo();

                ContaPessoa contaCamila = ContaPessoa.CriarConta("Camila", TipoCartao.CartaoDebitoComum);
                contaCamila.ExibirResumo();

                ContaPessoa contaEmpresa = ContaPessoa.CriarConta("Empresa LTDA", TipoCartao.CartaoCreditoCorporativo);
                contaEmpresa.ExibirResumo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no sistema: {ex.Message}");
            }

            Console.WriteLine("================================================");
            Console.ReadLine(); 
        }
    }
}