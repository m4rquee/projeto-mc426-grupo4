# Projeto MC426 Grupo4
Projeto para a disciplina de Engenharia de software no segundo semestre de 2020

Neste projeto o nosso grupo fará um jogo cujo objetivo é criar uma maneira de conscientizar a população sobre o Corona Vírus de uma maneira divertida e descontraída.
O objetivo do jogador será defender a população de ser totalmente afetada pelo vírus.

# Requisitos para executar o projeto
O nosso projeto foi feito na Unity 2019.3.8f1, então para conseguir executá-lo ou fazer uma build será necessário ter essa versão instalada.
Aqui vão os passos para conseguir rodar na Unity o jogo:
1. Baixe o [repositório](https://gitlab.com/munhozotavio/projeto-mc426-grupo4/) e vá para a branch "master"
2. Baixe o [Unity Hub](https://unity3d.com/pt/get-unity/download)
3. Execute o Unity Hub, vá em "Installs" e adicione a versão da Unity do projeto
    - Na hora de instalar é necessário ter suporte a Windows/Linux/Mac, depende da plataforma que você estiver
4. Depois de instalar, entre na aba "Projects" e adicione o projeto da pasta "MC426" que está dentro do repositório
5. Clique no projeto para abrí-lo e espere a Unity importar o projeto corretamente
6. No Unity, vá na aba "Project", pesquise por "Menu" e clique 2 vezes no arquivo "Menu.scene"
7. Clique no botão de "Play" no topo central da Unity

# Buildando o projeto
Como o nosso projeto está bem simples, a única coisa necessária para buildá-lo é ir em "File->Build Settings...", clicar no botão "Build" e selecionar uma pasta (de preferência não sendo a projeto) para ser colocado os arquivos gerados pela build.

# Atualizações sobre projeto
- Vídeo resumindo a primeira sprint [aqui](https://youtu.be/LNGpTxkcrHk).

# Descrição da arquitetura:
![Architecture](/architecture.png)

O uml proposto para esse projeto tem 3 componentes principais: Menu, Stage e Stage Selector, que são basicamente as 3 scenes que o projeto está dividido.
 - O componente menu é a primeira cena que o jogador vai ver quando o jogo for carregado, ela é responsável por redirecionar o jogador para o Stage Selector, assim como fechar o jogo ou abrir o menu de opções.
 - O componente stage selector é a cena intermediária, a qual deve redirecionar o Stage escolhido. Essa cena também é responsável por carregar o arquivo "save" para mostrar corretamente as fases habilitadas pelo usuário.
 - Por fim, o componente stage é a cena final e a que o jogador vai passar mais tempo, é a cena do jogo. O componente é responsável por gerenciar os principais objetos do jogo, como as torres e os monstros. Esta cena tem como função englobar os componentes do jogo e torná-los em uma fase jogável.