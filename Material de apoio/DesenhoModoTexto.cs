using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text;

namespace MeuBichinhoVirtual
{
    //exibe uma imagem na tela

    public class Program
    {
        static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            // Cria um novo Bitmap com a largura e altura desejadas
            Bitmap resizedImage = new Bitmap(width, height);

            // Desenha a imagem original no novo Bitmap usando as dimensões desejadas
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }

            return resizedImage;
        }

        static string ConvertToAscii(Bitmap image)
        {
            // Caracteres ASCII usados para representar a imagem
            char[] asciiChars = { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '@' };

            StringBuilder asciiArt = new StringBuilder();

            // Percorre os pixels da imagem e converte cada um em um caractere ASCII correspondente
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int grayScale = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int asciiIndex = grayScale * (asciiChars.Length - 1) / 255;
                    char asciiChar = asciiChars[asciiIndex];
                    asciiArt.Append(asciiChar);
                }
                asciiArt.Append(Environment.NewLine);
            }

            return asciiArt.ToString();
        }

        static void ExibirImagem(string imagePath, int width, int height)
        {
            // Caminho para a imagem que deseja exibir
            //string imagePath = @"C:\Users\Danilo Filitto\Downloads\Panda.jpg";

            // Carrega a imagem
            Bitmap image = new Bitmap(imagePath);

            // Redimensiona a imagem para a largura e altura desejadas
            int consoleWidth = width;
            int consoleHeight = height;
            Bitmap resizedImage = ResizeImage(image, consoleWidth, consoleHeight);

            // Converte a imagem em texto ASCII
            string asciiArt = ConvertToAscii(resizedImage);

            // Exibe o texto ASCII no console
            Console.WriteLine(asciiArt);

            
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Meu Bichinho virtual");
            // Caminho para a imagem que deseja exibir
            string imagePath = @"C:\Users\Danilo Filitto\Downloads\Panda.jpg";
            ExibirImagem(imagePath, 30, 20);
            // Aguarda o usuário pressionar uma tecla antes de encerrar o programa
            Console.ReadKey();
        }
    }
}
