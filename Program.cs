using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArvoreBinaria
{
    public class Fila
    {
        public Fila() // Construtor
        {
            info = null;
            next = null;
        }
        public void Enfila(Arvore n, ref Fila START, ref Fila END)
        {
            this.info = n;
            if (START == null)
                START = END = this;
            else
            {
                END.next = this;
                END = this;
            }
        }
        public Arvore Desenfila(ref Fila START)
        {
            START = this.next;
            return this.info;
        }
        public Arvore info;
        Fila next;
    }

    public class Arvore
    {
        public Arvore() // Construtor
        {
            info = 0;
            sae = sad = null;
        }
        public void Insere(int n, ref Arvore RAIZ)
        {
            Arvore temp, subarv;
            this.info = n;
            if (RAIZ == null)
                RAIZ = this;
            else
            {
                temp = RAIZ;
                while (temp != null)
                {
                    subarv = temp;
                    if (n <= temp.info)
                    {
                        temp = temp.sae;
                        if (temp == null) subarv.sae = this;
                    }
                    else
                    {
                        temp = temp.sad;
                        if (temp == null) subarv.sad = this;
                    }
                }
            }
        }
        public void MostraArvorePreOrdem()
        {
            Console.Write("{0} ", this.info);
            if (this.sae != null) (this.sae).MostraArvorePreOrdem();
            if (this.sad != null) (this.sad).MostraArvorePreOrdem();
        }
        public void MostraArvoreOrdemSimetrica()
        {
            if (this.sae != null) (this.sae).MostraArvoreOrdemSimetrica();
            Console.Write("{0} ", this.info);
            if (this.sad != null) (this.sad).MostraArvoreOrdemSimetrica();
        }
        public void MostraArvorePosOrdem()
        {
            if (this.sae != null) (this.sae).MostraArvorePosOrdem();
            if (this.sad != null) (this.sad).MostraArvorePosOrdem();
            Console.Write("{0} ", this.info);
        }
        public void MostraArvoreEmNivel()
        {
            Arvore arv = this;
            START = END = null;
            Fila ff = new Fila();
            ff.Enfila(arv, ref START, ref END);

            while (START != null)
            {
                arv = START.info;
                START.Desenfila(ref START);

                Console.Write(" {0} ", arv.info);
                if (arv.sae != null) { ff = new Fila(); ff.Enfila(arv.sae, ref START, ref END); }
                if (arv.sad != null) { ff = new Fila(); ff.Enfila(arv.sad, ref START, ref END); }
            }
            Console.ReadKey();
        }
        Fila START, END;
        public int info;
        Arvore sae;
        Arvore sad;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Arvore RAIZ = null;
            Arvore arv = new Arvore();
            int n, i, escolha;
            do
            {
                Console.Clear();
                Console.WriteLine(" Menu Principal");
                Console.WriteLine("(1) - Insere um elemento na Árvore");
                Console.WriteLine("(2) - Pesquisa um elemento na Árvore");
                Console.WriteLine("(3) - Lista Arvore - Pré-Ordem");
                Console.WriteLine("(4) - Lista Arvore - Ordem Simétrica");
                Console.WriteLine("(5) - Lista Arvore - Pos-Ordem");
                Console.WriteLine("(6) - Lista Arvore - Em Nível");
                Console.WriteLine("(7) - Calcula Maior Nivel");
                Console.WriteLine("(8) - Para SAIR");
                escolha = int.Parse(Console.ReadKey(true).KeyChar.ToString());

                switch (escolha)
                {
                    case 1: // Insere um elemento na Arvore
                        Console.Clear();
                        arv = new Arvore();
                        Console.Write("Entre com um numero : ");
                        n = int.Parse(Console.ReadLine());
                        arv.Insere(n, ref RAIZ);
                        break;

                    case 2: //Work in Progress...
                        break;
                     
                    case 3: //Lista Arvore - Pré-Ordem
                        Console.Clear();
                        RAIZ.MostraArvorePreOrdem();
                        Console.ReadKey();
                        break;

                    case 4: //Lista Arvore - Ordem Simétrica
                        Console.Clear();
                        RAIZ.MostraArvoreOrdemSimetrica();
                        Console.ReadKey();
                        break;

                    case 5: //Lista Arvore - Pós Ordem
                        Console.Clear();
                        RAIZ.MostraArvorePosOrdem();
                        Console.ReadKey();
                        break;

                    case 6: //Lista Arvore - Em nível
                        Console.Clear();
                        RAIZ.MostraArvoreEmNivel();
                        Console.ReadKey();
                        break;

                    case 7: //Work in progress...
                        break;
                }
            } while (escolha != 8);
        }
    }
}
