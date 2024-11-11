#Solvace Tech Case - Developer Position

##Introdução

Bem-vindo ao teste técnico para a vaga de desenvolvedor na Solvace. Este teste foi projetado para avaliar suas habilidades técnicas, capacidade de resolver problemas e aderência às melhores práticas de desenvolvimento. Ao completar este teste, você demonstrará sua proficiência nas tecnologias e abordagens que utilizamos, ajudando-nos a identificar candidatos alinhados com nossos valores e missão.

##Instruções Gerais

	1.	Clone este repositório para sua máquina local.
	2.	Crie uma branch local, a partir da "master", com o nome techcase/<seu-nome-sobrenome>. Exemplo: techcase/John-Carter.
	3.	Resolva todas as questões abaixo na sua branch.
	4.	Faça commit/push e abra um Pull Request (PR) para a branch release-candidate.
	5.	Anexe o link do seu PR na resposta deste e-mail para enviar o teste.

## to create a new migration
in project Solvace.TechCase.Repository dotnet ef migrations --startup-project Solvace.TechCase.API add <YOUR MIGRATION NAME HERE>

## to apply last migration
in project Solvace.TechCase.Repository dotnet ef --startup-project Solvace.TechCase.API database update