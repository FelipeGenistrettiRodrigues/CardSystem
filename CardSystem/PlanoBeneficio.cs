using System;

namespace CardSystem
{
    public enum TipoPlano
    {
        PlanoBasicoDebito,
        PlanoCorporativoPremium,
        BlackExclusive
    }

    public abstract class PlanoBeneficio
    {
        public TipoPlano TipoPlano { get; set; }
        public decimal Cashback { get; set; }
        public bool AcessoSalaVip { get; set; }
        public bool SeguroViagem { get; set; }
        public decimal CustoMensal { get; set; }

        protected PlanoBeneficio(TipoPlano tipoPlano, decimal cashback, bool acessoSalaVip, bool seguroViagem, decimal custoMensal)
        {
            TipoPlano = tipoPlano;
            Cashback = cashback;
            AcessoSalaVip = acessoSalaVip;
            SeguroViagem = seguroViagem;
            CustoMensal = custoMensal;
        }
    }

    public class PlanoBasicoDebito : PlanoBeneficio
    {
        private const decimal CustoMensalPlano = 0.0m;

        public PlanoBasicoDebito()
            : base(TipoPlano.PlanoBasicoDebito, cashback: 0.0m, acessoSalaVip: false, seguroViagem: false, custoMensal: CustoMensalPlano)
        {
        }
    }

    public class PlanoCorporativoPremium : PlanoBeneficio
    {
        private const decimal CustoMensalPlano = 1.0m;

        public PlanoCorporativoPremium()
            : base(TipoPlano.PlanoCorporativoPremium, cashback: 1.0m, acessoSalaVip: true, seguroViagem: false, custoMensal: CustoMensalPlano)
        {
        }
    }

    public class BlackExclusive : PlanoBeneficio
    {
        private const decimal CustoMensalPlano = 2.0m;

        public BlackExclusive()
            : base(TipoPlano.BlackExclusive, cashback: 3.0m, acessoSalaVip: true, seguroViagem: true, custoMensal: CustoMensalPlano)
        {
        }
    }

    public static class PlanoBeneficioCreator
    {
        public static PlanoBeneficio Criar(TipoPlano tipoPlano)
        {
            return tipoPlano switch
            {
                TipoPlano.PlanoBasicoDebito => new PlanoBasicoDebito(),
                TipoPlano.PlanoCorporativoPremium => new PlanoCorporativoPremium(),
                TipoPlano.BlackExclusive => new BlackExclusive(),
                _ => throw new ArgumentException("Tipo de plano de benefício inválido")
            };
        }
    }
}