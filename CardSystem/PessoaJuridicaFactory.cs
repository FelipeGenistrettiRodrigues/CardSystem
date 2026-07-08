namespace CardSystem
{
    public class PessoaJuridicaFactory : ICartaoBeneficioFactory
    {
        public Cartao CriarCartao(string nome)
        {
            return CartaoCreator.Criar(TipoCartao.CartaoCreditoCorporativo, nome);
        }

        public PlanoBeneficio CriarPlanoBeneficio()
        {
            return PlanoBeneficioCreator.Criar(TipoPlano.PlanoCorporativoPremium);
        }
    }
}
