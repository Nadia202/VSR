using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МДК01._01_ВСР
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WriteLine("Введите количество клиентов: ");
            int col_kl = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите минимальное время прибытия нового клиета после предыдущего: ");
            int m1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите максимальное время прибытия нового клиента после предыдущего: ");
            int m2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите минимальное время обслуживания: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите максимальное время обслуживания: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            double[] mas1 = new double[col_kl + 2];
            double[] mas2 = new double[col_kl];
            mas1[0] = 0;
            mas1[col_kl + 1] = 0;
            double t_v = 0;
            double n_o = 0;
            double k_o = 0;
            double v_prost = 0;
            double sum1 = 0;
            double sum2 = 0;
            Random random = new Random();
            Console.Write("Покупатель\tВрем после\tВремя\t\tТекущее\t\t\tНачало\t\tКонец\t\tВремя пребывания\tВремя простоя\n");
            Console.Write("          \tприбытия\tобслуживания\tмодельное время в\tобслуживания\tобслуживания\tклиента у\t\tбанкомата в\n");
            Console.Write("          \tпредыдущего\t\t\tмомент прибытия\t\t\t\t\t\tбанкомата\t\tв ожидании клиента\n");
            Console.Write("          \tклиента\t\t\t\tклиента\n");
            for (int i = 1; i < col_kl; i++)
            {
                mas1[i] = random.Next(m1, m2);
                sum1 += mas1[i];
            }
            for (int j = 0; j < col_kl; j++)
            {
                mas2[j] = random.Next(n1, n2);
                sum2 += mas2[j];
                t_v = t_v + mas1[j] / 100.0;
                k_o = n_o + mas2[j] / 100.0;
                double v_preb = (k_o - t_v) * 100;
                Console.Write("{0}\t\t{1}\t\t{2}\t\t{3}\t\t\t{4}\t\t{5}\t\t{6:0}\t\t\t{7:0}\n", j + 1, mas1[j], mas2[j], t_v, n_o, k_o, v_preb, v_prost);
                if (t_v + mas1[j + 1] / 100.0 > k_o)
                {
                    n_o = t_v + mas1[j + 1] / 100.0;
                }
                else
                {
                    n_o = k_o;
                }
                v_prost = (n_o - k_o) * 100;
            }
            double tz = sum1 / col_kl;
            double to = sum2 / col_kl;
            double l = 1 / tz;
            double h = 1 / to;
            double p = Math.Pow(1 + l / h, -1);
            Console.WriteLine("Среднее время между заявками: {0:0.00}", tz);
            Console.WriteLine("Интенсивность потока заявок: {0:0.00}", l);
            Console.WriteLine("Среднее время обслуживания: {0:0.00}", to);
            Console.WriteLine("Интенсивность потока заявок: {0:0.00}", h);
            double f = 0;
            for (int i = 1; i <= col_kl; i++)
            {
                f += i;
            }
            Console.WriteLine("Абсолютная пропускная способность системы: {0:0.00}", l * (1 - Math.Pow(l / h, col_kl) * p / f));
            Console.WriteLine("Относительная пропускная способость: {0:0.00}", 1 - Math.Pow(l / h, col_kl) * p / f);
            Console.WriteLine("Вероятность отказа: {0:0.00}", Math.Pow(l / h, col_kl) * p / f);
            Console.ReadKey();

        }
    }
}
