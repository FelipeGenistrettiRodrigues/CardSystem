namespace CardSystem
{
    public interface ICartaoBeneficioFactory
    {
        Cartao CriarCartao(string nome);
        PlanoBeneficio CriarPlanoBeneficio();
    }
}
