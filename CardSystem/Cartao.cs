using System;

namespace CardSystem
{
    public enum TipoCartao
    {
        CartaoDebitoComum,
        CartaoCreditoCorporativo,
        CartaoBlackMetal
    }

    public abstract class Cartao
    {
        public TipoCartao Tipo { get; set; }
        public string Nome { get; set; }
        public int Limite { get; protected set; }

        protected Cartao(TipoCartao tipoCartao, string nome, int limite)
        {
            Tipo = tipoCartao;
            Nome = nome;
            Limite = limite;
        }

        public virtual void SetLimite(int novoLimite)
        {
            Limite = novoLimite;
        }
    }

    // ==========================================
    // CLASSES FILHAS
    // ==========================================

    public class CartaoDebitoComum : Cartao
    {
        private const int LimitePadrao = 1000;

        // Removido o parâmetro TipoCartao do construtor, pois a própria classe já sabe o seu tipo
        public CartaoDebitoComum(string nome)
            : base(TipoCartao.CartaoDebitoComum, nome, LimitePadrao)
        {
        }

        public override void SetLimite(int novoLimite)
        {
            if (novoLimite > 2000)
            {
                throw new ArgumentException("Cartão de débito comum não pode ter limite maior que R$ 2000");
            }
            base.SetLimite(novoLimite);
        }
    }

    public class CartaoCreditoCorporativo : Cartao
    {
        private const int LimitePadrao = 50000;

        public CartaoCreditoCorporativo(string nome)
            : base(TipoCartao.CartaoCreditoCorporativo, nome, LimitePadrao)
        {
        }
    }

    public class CartaoBlackMetal : Cartao
    {
        private const int LimitePadrao = 1000000;

        public CartaoBlackMetal(string nome)
            : base(TipoCartao.CartaoBlackMetal, nome, LimitePadrao)
        {
        }
    }

    // ==========================================
    // CREATOR (FACTORY)
    // ==========================================

    public static class CartaoCreator
    {
        public static Cartao Criar(TipoCartao tipoCartao, string nome)
        {
            return tipoCartao switch
            {
                TipoCartao.CartaoDebitoComum => new CartaoDebitoComum(nome),
                TipoCartao.CartaoCreditoCorporativo => new CartaoCreditoCorporativo(nome),
                TipoCartao.CartaoBlackMetal => new CartaoBlackMetal(nome),
                _ => throw new ArgumentException("Tipo de cartão inválido")
            };
        }
    }
}