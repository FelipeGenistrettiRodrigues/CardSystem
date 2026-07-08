# 💳 CardSystemApp - Abstract Factory Pattern com C#

Este repositório foi desenvolvido com o objetivo de demonstrar a aplicação prática e purista do padrão de projeto criacional **Abstract Factory**, utilizando **C#** e as novidades do **.NET 10**. 

O projeto simula um domínio bancário real de emissão de cartões e planos de benefícios amarrados por categorias (famílias de objetos), garantindo o total desacoplamento do código e blindagem contra erros de associação de regras de negócio.

---

## 🎯 O Problema de Negócio

Em sistemas bancários tradicionais, diferentes perfis de clientes exigem a criação de produtos financeiros específicos que andam sempre juntos. Por exemplo:
* Um cliente **Varejo** deve receber um cartão de débito simples e um plano básico sem custos.
* Um cliente **VIP** deve receber um cartão Black com limite alto e benefícios de sala VIP e seguro viagem.

Se deixarmos essa lógica de associação espalhada pelo sistema usando estruturas condicionais (`if/else` ou `switch`) em qualquer lugar, corremos o risco de gerar combinações inválidas por erro humano — como associar por engano um benefício Black a um cliente de conta básica.

---

## 🚀 A Solução com Abstract Factory

O padrão **Abstract Factory** resolve esse problema ao fornecer uma interface mãe (`ICartaoBeneficioFactory`) que define os métodos de criação de produtos compatíveis. As fábricas concretas (`PessoaFisicaFactory`, `PessoaJuridicaFactory`, `ClienteVipFactory`) implementam essa interface e assumem a responsabilidade exclusiva de instanciar a combinação correta de objetos.

### Benefícios de Engenharia alcançados neste projeto:
* **Desacoplamento Total (SOLID - SRP & OCP):** A classe principal `ContaPessoa` não faz a menor ideia de qual classe concreta de cartão ou plano está utilizando. Se amanhã o banco lançar uma categoria "Gold", basta criar uma nova fábrica e um novo cartão, sem alterar uma única linha do código existente.
* **Segurança de Design:** Torna-se matematicamente impossível misturar produtos de famílias diferentes.
* **Encapsulamento de Criação:** Uso de um *Static Factory Method* (`ContaPessoa.CriarConta`) que funciona como um "porteiro" elegante para centralizar a inicialização do ecossistema.

---

## 🏗️ Estrutura do Projeto

O sistema está estruturado de forma limpa em arquivos separados:

* **`Cartao.cs`**: Classe abstrata mãe e suas variantes concretas (`CartaoDebitoComum`, `CartaoCreditoCorporativo`, `CartaoBlackMetal`). Centraliza o controle de propriedades como Limite e Nome.
* **`PlanoBeneficio.cs`**: Classe abstrata mãe e os planos correspondentes contendo regras de cashback, anuidades e seguros.
* **`ICartaoBeneficioFactory.cs`**: A interface que define a assinatura para a criação da família de produtos.
* **`Fábricas Concretas`**: Classes que assinam a interface e injetam as instâncias certas (`PessoaFisicaFactory`, `PessoaJuridicaFactory`, `ClienteVipFactory`).
* **`ContaPessoa.cs`**: A classe cliente que consome as fábricas via injeção de dependência implícita no construtor.

---

## 💻 Como Rodar o Projeto

1. Certifique-se de ter o **SDK do .NET 10** instalado em sua máquina.
2. Clone o repositório:
   ```bash
   git clone https://github.com/FelipeGenistrettiRodrigues/CardSystem
