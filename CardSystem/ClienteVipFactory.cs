namespace CardSystem
{
    public class ClienteVipFactory : ICartaoBeneficioFactory
    {
        public Cartao CriarCartao(string nome)
        {
            return CartaoCreator.Criar(TipoCartao.CartaoBlackMetal, nome);
        }

        public PlanoBeneficio CriarPlanoBeneficio()
        {
            return PlanoBeneficioCreator.Criar(TipoPlano.BlackExclusive);
        }
    }
}
