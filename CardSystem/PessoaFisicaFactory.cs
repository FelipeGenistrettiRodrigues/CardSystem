namespace CardSystem
{
    public class PessoaFisicaFactory : ICartaoBeneficioFactory
    {
        public Cartao CriarCartao(string nome)
        {
            return CartaoCreator.Criar(TipoCartao.CartaoDebitoComum, nome);
        }

        public PlanoBeneficio CriarPlanoBeneficio()
        {
            return PlanoBeneficioCreator.Criar(TipoPlano.PlanoBasicoDebito);
        }
    }
}
