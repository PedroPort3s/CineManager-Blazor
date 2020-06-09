using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogoPalitoBlazor.Controller
{
    public class PalitoController
    {
        public string ganhou = string.Empty;
        public void PrimeiraJogada(ref int qntPalito, out short jogadaMaquina)
        {
            jogadaMaquina = 0;

            if (qntPalito == 30 || qntPalito == 26 || qntPalito == 22)
            {
                jogadaMaquina = 1;
                qntPalito -= (jogadaMaquina);
            }
            else if (qntPalito == 29 || qntPalito == 28 || qntPalito == 25
                || qntPalito == 24 || qntPalito == 21 || qntPalito == 20)
            {
                jogadaMaquina = 3;
                qntPalito -= (jogadaMaquina);
            }
            else if (qntPalito == 27 || qntPalito == 23)
            {
                jogadaMaquina = 2;
                qntPalito -= (jogadaMaquina);
            }
            else
            {
                throw new Exception("O valor não está entre 20 e 30");
            }
        }

        public void ContinuarJogo(int retirada, ref int qntPalitos, out string msg, out short retiradaMaquina)
        {
            retiradaMaquina = 0;
            if (retirada <= 0)
                throw new Exception("Numero Obrigatorio!!");
            else
            {
                short retirar = Convert.ToInt16(retirada);
                if (retirar != 2 && retirar != 3 && retirar != 1)
                    throw new Exception("Valor não aceitavel, deve estar entre 3, 2 e 1");
                else
                {
                    msg = string.Empty;
                    if (retirar > qntPalitos)
                        throw new Exception("Palitos Insuficientes");
                    else
                    {
                        // Usuario perde
                        if (qntPalitos == 5)
                        {
                            qntPalitos = qntPalitos - retirar; // Resto - Valor inserido pelo usuario

                            msg = "Voce retirou" + retirar + " palitos" + Environment.NewLine;
                            msg += "Restam " + qntPalitos + " palitos" + Environment.NewLine;

                            if (qntPalitos == 4)
                            {
                                retiradaMaquina = 3;
                                qntPalitos -= retiradaMaquina;
                            }
                            if (qntPalitos == 3)
                            {
                                retiradaMaquina = 2;
                                qntPalitos -= retiradaMaquina;
                            }
                            if (qntPalitos == 2)
                            {
                                retiradaMaquina = 1;
                                qntPalitos -= retiradaMaquina;
                            }
                            if (qntPalitos == 1)
                            {
                                retiradaMaquina = 1;
                                qntPalitos -= retiradaMaquina;
                                ganhou = "MAQUINA";
                            }
                        }
                        else // Usuario ganha
                        {
                            qntPalitos = qntPalitos - retirar;

                            msg = "Voce retirou" + retirar + " palitos" + Environment.NewLine;
                            msg += "Restam " + qntPalitos + " palitos" + Environment.NewLine;

                            retirada = 0;

                            if (retirar == 3)
                            {
                                retiradaMaquina = 1;
                                qntPalitos -= retiradaMaquina;
                            }
                            else if (retirar == 2)
                            {
                                retiradaMaquina = 2;
                                qntPalitos -= retiradaMaquina;
                            }
                            else if (retirar == 1)
                            {
                                retiradaMaquina = 3;
                                qntPalitos -= retiradaMaquina;
                            }

                            if (qntPalitos < 1)// Jogador é o último a retirar os palitos
                                ganhou = "USUARIO";
                        }
                    }
                }
            }
        }

    }
}
