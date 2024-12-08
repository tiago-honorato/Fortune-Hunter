#include <stdio.h>
#include <stdlib.h>

#define TAM 9999

int Frente, Tras, Lista[TAM];

void Lista_Construtor(){
    Frente = 0;
    Tras = -1;
}

int Lista_Vazia(){
    return Tras == -1;
}

int Lista_Cheia(){
    return Tras == TAM - 1;
}

int Lista_Tamanho(){
    return Tras + 1;
}

int Lista_Inserir_Inicio(int Valor){
    if(Lista_Cheia()){
        return 0;
    } else {
        for(int i = Tras + 1; i > Frente; i--){
            Lista[i] = Lista[i - 1];
        }
        Lista[Frente] = Valor;
        Tras++;
        return 1;
    }
}

int Lista_Inserir_Fim(int Valor){
    if(Lista_Cheia()){
        return 0;
    } else {
        Tras++;
        Lista[Tras] = Valor;
        return 1;
    }
}

int Lista_Inserir_Meio(int Valor, int Posicao){
    if(Lista_Cheia()){
        return 0;
    } else {
        if(Posicao >= Frente && Posicao <= Tras + 1){
            for(int i = Tras + 1; i > Posicao; i--){
                Lista[i] = Lista[i - 1];
            }
            Lista[Posicao] = Valor;
            Tras++;
            return 1;
        } else {
            return 0;
        }
    }
}

int Lista_Remover_Inicio(int *Valor){
    if(Lista_Vazia()){
        return 0;
    } else {
        *Valor = Lista[Frente];
        for(int i = Frente; i < Tras; i++){
            Lista[i] = Lista[i + 1];
        }
        Tras--;
        return 1;
    }
}

int Lista_Remover_Fim(int *Valor){
    if(Lista_Vazia()){
        return 0;
    } else {
        *Valor = Lista[Tras];
        Tras--;
        return 1;
    }
}

int Lista_Remover_Meio(int *Valor, int Posicao){
    if(Lista_Vazia()){
        return 0;
    } else {
        if(Posicao >= Frente && Posicao <= Tras){
            *Valor = Lista[Posicao];
            for(int i = Posicao; i < Tras; i++){
                Lista[i] = Lista[i + 1];
            }
            Tras--;
            return 1;
        } else {
            return 0;
        }
    }
}

int Lista_pegar_Inicio(int *Valor){
    if(Lista_Vazia()){
        return 0;
    } else {
        *Valor = Lista[Frente];
        return 1;
    }
}

int Lista_pegar_Fim(int *Valor){
    if(Lista_Vazia()){
        return 0;
    } else {
        *Valor = Lista[Tras];
        return 1;
    }
}

int Lista_Busca_por_Valor(int Valor, int *Posicao){
    if(Lista_Vazia()){
        return 0;
    } else {
        for(int i = Frente; i <= Tras; i++){
            if(Lista[i] == Valor){
                *Posicao = i;
                return 1;
            }
        }
        return 0;
    }
}

int Lista_Busca_por_Posicao(int *Valor, int Posicao){
    if(Lista_Vazia()){
        return 0;
    } else {
        if(Posicao >= Frente && Posicao <= Tras){
            *Valor = Lista[Posicao];
            return 1;
        } else {
            return 0;
        }
    }
}

void Lista_Exibir(){
    if(Lista_Vazia()){
        printf("Lista vazia.\n");
    } else {
        printf("\nLista: ");
        for(int i = Frente; i <= Tras; i++){
            printf("%d ", Lista[i]);
        }
        printf("\n");
    }
}

int main() {
    Lista_Construtor();
    int opcao, valor, posicao;

    do {
        printf("\n");
        printf("Escolha uma opcao (1 a 12):\n");
        printf("-------------------\n");
        printf("1.Inserir inicio da lista\n");
        printf("2.Inserir meio da lista\n");
        printf("3.Inserir final da lista\n");
        printf("4.Remover inicio da lista\n");
        printf("5.Remover meio da lista\n");
        printf("6.Remover final da lista\n");
        printf("7.Procurar por indice\n");
        printf("8.Procurar por valor\n");
        printf("9.Procurar inicio da lista\n");
        printf("10.Procurar final da lista\n");
        printf("11.Mostrar lista\n");
        printf("12.Sair e mostrar lista final\n");
        printf("-------------------\n");

        printf("\nEscolha uma opcao (0 para sair): ");
        scanf("%d", &opcao);

        switch(opcao) {
            case 0:
                printf("Ate logo :)\n");
                break;
            case 1:
                printf("Digite o valor a ser inserido: ");
                scanf("%d", &valor);
                if (Lista_Inserir_Inicio(valor)) {
                    printf("Valor inserido com sucesso.\n");
                } else {
                    printf("Lista cheia.\n");
                }
                break;
            case 2:
                printf("Digite o valor a ser inserido: ");
                scanf("%d", &valor);
                printf("Digite a posicao: ");
                scanf("%d", &posicao);
                if (Lista_Inserir_Meio(valor, posicao)) {
                    printf("Inserido com sucesso\n");
                } else {
                    printf("Lista cheia ou posicao invalida.\n");
                }
                break;
            case 3:
                printf("Digite o valor a ser inserido: ");
                scanf("%d", &valor);
                if (Lista_Inserir_Fim(valor)) {
                    printf("Valor inserido com sucesso.\n");
                } else {
                    printf("Lista cheia.\n");
                }
                break;
            case 4:
                if (Lista_Remover_Inicio(&valor)) {
                    printf("Valor removido do inicio: %d\n", valor);
                } else {
                    printf("Lista vazia.\n");
                }
                break;
            case 5:
                printf("Digite a posicao para remover: ");
                scanf("%d", &posicao);
                if (Lista_Remover_Meio(&valor, posicao)) {
                    printf("Valor removido: %d\n", valor);
                } else {
                    printf("Posicao invalida ou lista vazia.\n");
                }
                break;
            case 6:
                if (Lista_Remover_Fim(&valor)) {
                    printf("Valor removido do final: %d\n", valor);
                } else {
                    printf("Lista vazia.\n");
                }
                break;
            case 7:
                printf("Digite a posicao para buscar: ");
                scanf("%d", &posicao);
                if (Lista_Busca_por_Posicao(&valor, posicao)) {
                    printf("Valor na posicao %d: %d\n", posicao, valor);
                } else {
                    printf("Posicao invalida ou lista vazia.\n");
                }
                break;
            case 8:
                printf("Digite o valor para buscar: ");
                scanf("%d", &valor);
                if (Lista_Busca_por_Valor(valor, &posicao)) {
                    printf("Valor encontrado na posicao: %d\n", posicao);
                } else {
                    printf("Valor nao encontrado na lista.\n");
                }
                break;
            case 9:
                if (Lista_pegar_Inicio(&valor)) {
                    printf("Valor no inicio: %d\n", valor);
                } else {
                    printf("Lista vazia.\n");
                }
                break;
            case 10:
                if (Lista_pegar_Fim(&valor)) {
                    printf("Valor no final: %d\n", valor);
                } else {
                    printf("Lista vazia.\n");
                }
                break;
            case 11:
                Lista_Exibir();
                break;
            case 12:
                Lista_Exibir();
                opcao = 0;
                break;
            default:
                printf("Opcao inexistente.\n");
        }
    } while (opcao != 0);

    return 0;
}
