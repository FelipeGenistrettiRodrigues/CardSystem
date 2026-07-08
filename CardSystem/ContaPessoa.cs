namespace CardSystem
{
    public class ContaPessoa
    {
        private readonly ICartaoBeneficioFactory _factory;
        private readonly Cartao _cartao;
        private readonly PlanoBeneficio _planoBeneficio;

        public ContaPessoa(ICartaoBeneficioFactory factory, string nome)
        {
            _factory = factory;
            _cartao = factory.CriarCartao(nome);
            _planoBeneficio = factory.CriarPlanoBeneficio();
        }

        public static ContaPessoa CriarConta(string nome, TipoCartao tipoCartao)
        {
            return tipoCartao switch
            {
                TipoCartao.CartaoDebitoComum => new ContaPessoa(new PessoaFisicaFactory(), nome),
                TipoCartao.CartaoCreditoCorporativo => new ContaPessoa(new PessoaJuridicaFactory(), nome),
                TipoCartao.CartaoBlackMetal => new ContaPessoa(new ClienteVipFactory(), nome),

                _ => throw new ArgumentException("Tipo de cartão/conta inválido")
            };
        }

        // Método auxiliar didático para você testar e ver o resultado no console
        public void ExibirResumo()
        {
            Console.WriteLine($"--- RESUMO DA CONTA ---");
            Console.WriteLine($"Titular: {_cartao.Nome}");
            Console.WriteLine($"Cartão: {_cartao.Tipo} (Limite: {_cartao.Limite:C})");
            Console.WriteLine($"Plano: {_planoBeneficio.TipoPlano} (Custo Mensal: {_planoBeneficio.CustoMensal:C})");
            Console.WriteLine($"Benefícios -> Cashback: {_planoBeneficio.Cashback}%, Sala VIP: {_planoBeneficio.AcessoSalaVip}, Seguro Viagem: {_planoBeneficio.SeguroViagem}");
            Console.WriteLine("-----------------------\n");
        }
    }
}