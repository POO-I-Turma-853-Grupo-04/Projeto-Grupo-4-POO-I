# Conteúdo
- [Introdução](#Introdução)  
- [Objetivo](#Objetivo)  
- [Detalhamento do projeto](#Detalhamento-do-projeto)  
    - [Como ele funciona](#como-ele-funciona)  
    - [Diagrama UML](#diagrama-UML)  
    - [Organização das tarefas](#organização-das-tarefas)  

# Introdução

O projeto foi uma atividade final do módulo de POO I (Programação Orientada a Objetos I | C#) do Grupo 04 da Turma 853 | Web Full Stack da Let's Code.

O grupo 04 foi composto por: 

| Nome | Linkedin | Github |
| --- | --- | --- |
| Beatriz Tavernaro | https://www.linkedin.com/in/beatriz-tavernaro | https://github.com/beatavernaro |
| Fabio Yamashita | https://www.linkedin.com/in/fabioksyamashita | https://github.com/fabioyamashita |
| Felipe Ferreira de Andrade | https://www.linkedin.com/in/felipe-fandrade | https://github.com/felipefand |

# Objetivo

Neste projeto, criamos uma aplicação que faz uma simulação de empréstimo para o cliente, oferecendo algumas opções de valores, taxas e prazos.

# Detalhamento do projeto

## Como ele funciona

### A Aplicação

A aplicação terá as seguintes etapas:
1. O cliente poderá escolher dentre as seguintes opções:
    - Consultar Taxas
    - Iniciar processo de empréstimo
    - Sair do Sistema
2. Assim que entrar no sistema de empréstimo, pediremos algumas informações pessoais (Obs.: Todas com validações de entrada)
    - Nome completo
    - CPF | 55555555592 (11 dígitos) ou 555.555.555-92
    - Telefone (com DDD) (11954536582)
3. Confirmação dos dados acima
4. Confirmando, pediremos os dados sobre a garantia do cliente (Obs.: Todas com validações de entrada)
     - Qual o tipo de Garantia (Veículo ou imóvel)
     - Valor da garantia
     - Para Veículos:
        - Modelo
        - Placa | FDS-1512 ou BRA5G52
     - Para Imóveis
        - CEP | 10456120 (8 dígitos)
        - Endereço
5. Confirmação dos dados acima
6. Mostraremos os valores mínimos e máximos de empréstimo possíveis. O usuário digitará um valor.
7. As opções de parcelamento serão mostradas na tela. O usuário digitará uma parcela desejada.
8. Confirmação da contratação do empréstimo
9. Caso positivo, o contrato final será gerado.
10. Por fim, será pedido uma confirmação de assinatura para o usuário.

### Por trás da aplicação

Para os cálculos de empréstimo, consideramos as seguintes taxas de juros para cada tipo de garantia dada:
- Veículo: 1,49% a.m.
- Imóvel: 0,99% a.m.

Para calcular o valor final da dívida, utilizamos a seguinte fórmula:  

![\dpi{110}\bg{white}P&space;=&space;PV&space;*&space;\frac&space;{(i&space;&plus;&space;1)^{n}&space;*&space;i}{(i&space;&plus;&space;1)^{n}&space;-&space;i}](https://latex.codecogs.com/png.image?\dpi{110}\bg{white}P&space;=&space;PV&space;*&space;\frac&space;{(i&space;&plus;&space;1)^{n}&space;*&space;i}{(i&space;&plus;&space;1)^{n}&space;-&space;i}) 

Mais conteúdos em breve...

## Descrição das classes

Em breve...

## Diagrama UML

Construímos um diagrama UML para representar nossas classes do projeto e como elas estão relacionadas entre si. Utilizamos a plataforma do [Flowchart Maker & Online Diagram Software](https://app.diagrams.net/).

O Diagrama UML está disponível em: https://app.diagrams.net/#G1E8E7aAq8NhngZuvtxMTNAuN726aCIZsV

## Organização das tarefas

Utilizamos a ferramenta "Projects" do próprio Github para organizarmos as tarefas que cada um foi responsável. Além disso, implementamos um método de trabalho em que o código só seria incrementado na 'main' com a revisão de algum outro colaborador.

O link do Projeto está disponível em: https://github.com/orgs/POO-I-Turma-853-Grupo-04/projects/1
